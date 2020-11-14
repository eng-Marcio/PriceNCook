using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNCook
{
    [Serializable()]
    public abstract class Item
    {
        #region attributes
        public string name { get; private set; }
        public float price { get; set; }
        public string description { get; private set; }

        public string picPath { get; private set; }
        public DateTime creationDate { get; private set; }
        public DateTime lastChange { get; private set; }
        public int typeItem { get; internal set; }


        public const int MAX_NAME_LENGTH = 100;
        public const int MAX_DESCRIPTION_LENGTH = 500;
        #endregion

        #region constructor
        public Item(string name) //create item with default config
        {
            this.name = name;
            this.price = 0;
            this.description = "";
            this.picPath = "defaultPic.jpg";
            this.creationDate = DateTime.Today;
            this.lastChange = DateTime.Today;
        }

        public Item(Item item, string new_name) //create an item copy of another
        {
            this.name = new_name;
            this.price = item.price;
            this.description = item.description;
            this.picPath = item.picPath;
            this.creationDate = DateTime.Today;
            this.lastChange = DateTime.Today;
            this.typeItem = item.typeItem;
        }
        public Item(string name, float price, string description, string picPath)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.picPath = picPath;
            this.creationDate = DateTime.Today;
            this.lastChange = DateTime.Today;
        }

        #endregion

        #region methods
        public string setName(string name)
        {
            this.name = checkString(name, Item.MAX_NAME_LENGTH);
            this.lastChange = DateTime.Today;
            return this.name;
        }
        public float setPrice(decimal price)
        {
            if(price < 0)
            {
                return -1;
            }
            this.price = (float)Math.Round(price, 2); //round on cents decimal
            this.lastChange = DateTime.Today;
            return this.price;
        }
        public string setDescription(string description)
        {
            this.description = checkString(description, Item.MAX_DESCRIPTION_LENGTH);
            this.lastChange = DateTime.Today;
            return this.description;
        }

        public void setPicPath()
        {
            this.picPath = "defaultPic.jpg";
        }

        public void setPicPath(string path)
        {
            this.picPath = path;
        }

        public static string checkString(string str, int maxLength)
        {
            str = str.TrimStart();
            if(str.Length > maxLength)
            {
                return str.Substring(0, maxLength);
            }
            return str;
        }

        public abstract float priceItem(string size, float quantity);

        #endregion
    }
}
