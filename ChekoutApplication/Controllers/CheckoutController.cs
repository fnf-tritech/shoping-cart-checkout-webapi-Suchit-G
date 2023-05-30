using ChekoutApplication.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChekoutApplication.Models;

namespace ChekoutApplication.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly Dictionary<char,Item> priceTable;

        public CheckoutController() 
        {
            priceTable = new Dictionary<char, Item>

            {
                {'A',new Item{Price=50,OfferQuantity=3,OfferPrice=130}},
                {'B',new Item{Price=30,OfferQuantity=2,OfferPrice=45} },
                {'C',new Item{Price=20} },
                {'D',new Item{Price=15} }

            };

        }
        [HttpGet("{items}")]
        public int CalculateTotalPrice(string items)
        {
            int totalPrice = Calculate(items);
            return totalPrice;
        }
        private int Calculate(string items)
        {
            Dictionary<char, int> itemCounts = new Dictionary<char, int>();

            foreach (char item in items)
            {
                if (priceTable.ContainsKey(item))
                {
                    if (itemCounts.ContainsKey(item))
                        itemCounts[item]++;
                    else
                        itemCounts[item] = 1;
                }
                else
                {
                    return 0;
                }
            }
            int totalPrice = 0;
            foreach (var item in itemCounts)
            {
                totalPrice += CalculateItemPrice(item.Key, item.Value);
            }

            return totalPrice;
        }
        private int CalculateItemPrice(char item, int quantity)
        {
            int totalPrice = 0;
            if (priceTable.TryGetValue(item, out Item itemDetails))
            {
                int offerQuantity = itemDetails.OfferQuantity;
                int offerPrice = itemDetails.OfferPrice;

                int regularPriceItems = quantity % offerQuantity;
                int offerItems = quantity / offerQuantity;

                totalPrice = offerItems * offerPrice + regularPriceItems * itemDetails.Price;
            }
            return totalPrice;
        }
        
    }

}

