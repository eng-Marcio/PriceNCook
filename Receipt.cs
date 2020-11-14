using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNCook
{
    [Serializable()]
    class Receipt: Item
    {
        #region attributes
        public float yield { get; private set; }
        public string unit { get; private set; }

        //ingredients for the receipt
        public List<string> sizes { get; private set; }
        public List<Item> itemsForReceipt { get; private set; }
        public List<List<float>> quantities { get; private set; }
        #endregion

        #region constructor
        public Receipt(string name) : base(name) //create item with default config
        {
            this.yield = 1;
            this.unit = "un";
            sizes = new List<string> { "tm_un" };         //
            itemsForReceipt = new List<Item>();           // fill with empty lists
            quantities = new List<List<float>>();         //
            quantities.Add(new List<float>());            //
            this.typeItem = Controller.RECEIPTS;
        }

        public Receipt(Item item, string new_name) : base(item, new_name) //create an item copy of another
        {
            this.yield = ((Receipt)item).yield;
            this.unit = ((Receipt)item).unit;
            this.sizes = new List<string>(((Receipt)item).sizes);
            this.itemsForReceipt = new List<Item>(((Receipt)item).itemsForReceipt);
            this.quantities = new List<List<float>>();
            for(int i = 0; i < ((Receipt)item).quantities.Count; i++)
            {
                this.quantities.Add(new List<float>(((Receipt)item).quantities.ElementAt(i)));
            }
        }
        public Receipt(string name, float price, string description, string picPath, float quantity) : base(name, price, description, picPath)
        {
            if (quantity < 0)
                this.yield = 0;
            else
                this.yield = quantity;
            sizes = new List<string> { "tm_un" };         //
            itemsForReceipt = new List<Item>();           // fill with empty lists
            quantities = new List<List<float>>();         //
            quantities.Add(new List<float>());            //
            this.typeItem = Controller.RECEIPTS;
        }
        #endregion

        #region methods
        public float setQuantity(float quantity)
        {
            if (quantity < 0)
            {
                return -1;
            }
            this.yield = quantity;
            return this.yield;
        }

        public void setUnit(string unit)
        {
            this.unit = unit;
        }

        public override float priceItem(string size, float quantity)
        {
            List<float> quantities = this.quantities.ElementAt(sizes.IndexOf(size));
            float res = 0;
            for(int i = 0; i < itemsForReceipt.Count; i++)
            {
                res += itemsForReceipt.ElementAt(i).priceItem(null, quantities.ElementAt(i));
            }
            this.price = res;
            res = (quantity / this.yield) * res;
            return res;
        }
        #endregion
    }
}
