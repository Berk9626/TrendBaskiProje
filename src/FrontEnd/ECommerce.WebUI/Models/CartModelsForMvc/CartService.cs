using ECommerce.WebUI.Models.ShoppingTools;
using System.Collections.Generic;

namespace ECommerce.WebUI.Models.CartModelsForMvc
{
    public class CartService : ICartService
    {
        public Dictionary<int, CartModel> MyCart = new Dictionary<int, CartModel>();
        public void AddItem(CartModel item)
        {
            if (MyCart.ContainsKey(item.Id))
            {
                MyCart[item.Id].Quantity += 1;
                return;
            }
            MyCart.Add(item.Id, item);
        }

        public void UpdateItem(int key, short quantity)
        {
            if (MyCart.ContainsKey(key))
            {
                MyCart[key].Quantity = quantity;
                return;
            }
        }

        //public void DeleteItem(int key)
        //{
        //    if (MyCart.ContainsKey(key))
        //    {
        //        var findcart = MyCart[key];
        //        findcart.Remove(key);
        //        return;
        //    }
        //}

        public void DeleteItem(int key)
        {
            if (MyCart[key].Quantity > 1)
            {
                MyCart[key].Quantity--;
                return;
            }

            MyCart.Remove(key);
        }
    }
}
