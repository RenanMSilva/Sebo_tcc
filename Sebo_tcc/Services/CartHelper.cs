﻿using Sebo_tcc.Models;
using System.Text.Json;

namespace Sebo_tcc.Services
{
    public class CartHelper
    {
        public static Dictionary<int, int> GetCartDictionary(HttpRequest request, HttpResponse response)
        {
            string cookieValue = request.Cookies["shopping_cart"] ?? "";

            try
            {
                var cart = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(cookieValue));
                Console.WriteLine("[CartHelper] cart=" + cookieValue + " -> " + cart);
                var dictionary = JsonSerializer.Deserialize<Dictionary<int, int>>(cart);
                if (dictionary != null)
                {
                    return dictionary;
                }
            }
            catch(Exception)
            {
            }

            if (cookieValue.Length > 0)
            {
                // this cookie is not valid => delete it
                response.Cookies.Delete("shopping_cart");
            }

            return new Dictionary<int, int>();
        }


        public static int GetCartSize(HttpRequest request, HttpResponse response)
        {
            int cartSize = 0;

            var cartDictionary = GetCartDictionary(request, response);
            foreach (var keyValuePair in cartDictionary)
            {
                cartSize += keyValuePair.Value;
            }

            return cartSize;
        }

        public static List<SaleItemModel> GetCartItems(HttpRequest request, HttpResponse response
            , ApplicationDbContext _context)
        {
            var cartItems = new List<SaleItemModel>();

            var cartDictionary = GetCartDictionary(request, response);
            foreach (var pair in cartDictionary)
            {
                int productId = pair.Key;
                int quantity = pair.Value;
                var product = _context.Books.Find(productId);
                if (product == null) continue;

                var item = new SaleItemModel
                {
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Item = product,
                };

                cartItems.Add(item);
            }

            return cartItems;
        }


        public static decimal GetSubtotal(List<SaleItemModel> cartItems)
        {
            decimal subtotal = 0;

            foreach (var item in cartItems)
            {
                var teste_valor = item.UnitPrice;
                var teste_valor2 = item.Quantity;
                subtotal += item.Quantity * item.UnitPrice;
            }

            return subtotal;
        }
    }
}
