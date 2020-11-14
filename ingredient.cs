using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceNCook
{
    [Serializable()]
    class Ingredient : Item 
    {
        #region attributes
        public float quantity { get; private set; }
        public string unit { get; private set; }
        #endregion

        #region constructor
        public Ingredient(string name): base(name) //create item with default config
        {
            this.quantity = 1;
            this.unit = "un";
            this.typeItem = Controller.INGREDIENTS;
        }

        public Ingredient(Item item, string new_name) : base(item, new_name) //create an item copy of another
        {
            this.quantity = ((Ingredient)item).quantity;
            this.unit = ((Ingredient)item).unit;
        }
        public Ingredient(string name, float price, string description, string picPath, float quantity, string unit) : base(name, price, description, picPath)
        {
            if (quantity < 0)
                this.quantity = 0;
            else
                this.quantity = quantity;
            this.unit = unit;
            this.typeItem = Controller.INGREDIENTS;
        }
        #endregion

        #region methods
        public float setQuantity(float quantity)
        {
            if (quantity < 0)
            {
                return -1;
            }
            this.quantity = quantity;
            return quantity;
        }
        public void setUnit(string unit)
        {
            this.unit = unit;
        }

        public override float priceItem(string size, float quantity)
        {
            return (quantity / this.quantity) * this.price;
        }
        #endregion
    }
}
