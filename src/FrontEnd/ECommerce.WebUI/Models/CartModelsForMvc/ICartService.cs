using ECommerce.WebUI.Models.ShoppingTools;

namespace ECommerce.WebUI.Models.CartModelsForMvc
{
    public interface ICartService
    {
        //AddItem
        public void AddItem(CartModel item);

        //UpdateItem
        public void UpdateItem(int key, short quantity);

        //DeleteItem
        public void DeleteItem(int key);


    }

}
