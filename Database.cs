using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceNCook
{
    [Serializable()]
    class Database
    {
        #region attributes
        public List<Item> allItems { get; private set; }
        #endregion

        #region constructor
        public Database()
        {
            allItems = new List<Item>();
        }
        #endregion

        #region methods
        public bool addItem(Item item)
        {
            //add items in ascending order of name, avoid duplicated names
            int i = 0;
            for(i = 0; i < allItems.Count; i++)
            {
                int compare = String.Compare(item.name, allItems.ElementAt(i).name, true);
                if (compare > 0)
                    continue;
                else if (compare == 0)
                    return false;
                else
                    break;
            }
            allItems.Insert(i, item);
            return true;
        }

        public Item getItem(string name) //returns null if item is not found
        {
            for(int i = 0; i < allItems.Count; i++)
            {
                if (allItems.ElementAt(i).name.Equals(name))
                    return allItems.ElementAt(i);
                if (String.Compare(allItems.ElementAt(i).name, name) > 0)
                    break;
            }
            return null;
        }

        public List<Item> getTableForVisualization(int type, int size, int beginAfter)
        {
            List<Item> items = new List<Item>();
            for(int i = 0; i < allItems.Count; i++)
            {
                if (allItems.ElementAt(i).typeItem == type)
                {
                    if (beginAfter > 0)
                    {
                        beginAfter--;
                        continue;
                    }
                    items.Add(allItems.ElementAt(i));
                    if (items.Count == size)
                        break;
                }
            }
            return items;
        }

        public bool changeItemName(Item item, string name)
        {
            name = Item.checkString(name, Item.MAX_NAME_LENGTH);
            //check if name is same as old
            if (item.name.Equals(name))
            {
                return true;
            }
            //empty string
            if (name.Trim().Equals(""))
            {
                return false;
            }
            //check if name already exists in such database
            for(int i = 0; i < allItems.Count; i++)
            {
                if (allItems.ElementAt(i).name.Equals(name))
                    return false;
                if (String.Compare(name, allItems.ElementAt(i).name) < 0)
                    break;
            }
            //ready to change name
            allItems.Remove(item);
            item.setName(name);
            int pos = 0;
            for(pos = 0; pos < allItems.Count; pos++)
            {
                if (String.Compare(name, allItems.ElementAt(pos).name) < 0)
                    break;
            }
            allItems.Insert(pos, item);
            return true;
        }
        #endregion
    }
}
