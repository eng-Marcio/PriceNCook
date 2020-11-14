using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNCook
{
    [Serializable()]
    class Order : Item
    {
        #region attributes
        public List<Item>items { get; private set; }
        public List<string> sizes { get; private set; }
        public List<float> quantities { get; private set; }
        #endregion

        #region constructor
        public Order(string name, bool isProduct) : base(name) //create item with default config
        {
            if (isProduct)
            {
                this.typeItem = Controller.PRODUCTS;
            }
            else
            {
                this.typeItem = Controller.ORDERS;
            }
            items = new List<Item>();
            sizes = new List<string>();
            quantities = new List<float>();
        }

        public Order(Item item, string new_name) : base(item, new_name) //create an item copy of another
        {
            this.typeItem = item.typeItem;
            this.items = new List<Item>(((Order)item).items);
            this.sizes = new List<string>(((Order)item).sizes);
            this.quantities = new List<float>(((Order)item).quantities);
        }
        public Order(string name, float price, string description, string picPath, bool isProduct) : base(name, price, description, picPath)
        {
            if(isProduct)
            {
                this.typeItem = Controller.PRODUCTS;
            }
            else
            {
                this.typeItem = Controller.ORDERS;
            }
            items = new List<Item>();
            sizes = new List<string>();
            quantities = new List<float>();
        }
        #endregion

        #region methods
        public override float priceItem(string size, float quantity)
        {
            float res = 0;

            for(int i = 0; i < items.Count; i++)
            {
                res += items.ElementAt(i).priceItem(sizes.ElementAt(i), quantities.ElementAt(i));
            }
            this.price = res;
            return res;
        }
        #endregion
    }
}
