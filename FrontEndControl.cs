using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceNCook
{
    public partial class FrontEndControl : Form
    {
        #region attributes
        private Controller controller;

        private Item currentItem = null;
        public bool editing { get; private set; }
        #endregion

        #region constructor

        public FrontEndControl()
        {
            this.controller = new Controller(this);
            InitializeComponent();
            //databaseTable.Rows.Clear();
            databaseTable.Columns.Clear();
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Width = 30;
            databaseTable.Columns.Add(imageCol);
            databaseTable.Columns.Add("Nome", "Nome");
            databaseTable.Columns.Add("Preço (R$)", "Preço (R$)");
            changeEdition(false);
            updateDatabase(true);
        }

        #endregion

        #region eventHandlers
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    databaseBox.SelectedIndex = controller.CurrentBase;
                    return;
                }
                changeEdition(false);
            }
            controller.SerializeDatabase();
            MessageBox.Show("Alterações salvas com sucesso.", "Arquivo salvo.");
        }

        private void databaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseBox.SelectedIndex == controller.CurrentBase)
                return;
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    databaseBox.SelectedIndex = controller.CurrentBase;
                    return;
                }
                changeEdition(false);
            }
            updateDatabase(true);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            controller.getDatabase(controller.CurrentBase);
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            List<Item> searchedItems = controller.filterItems(searchBox.Text);
            if(searchedItems.Count > 0)
            {
                currentItem = searchedItems.ElementAt(0);
            }
            updateDatabase(false);
        }

        private void FrontEndControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            DialogResult r = MessageBox.Show("Você deseja salvar alterações antes de fechar o programa?", "Atenção", MessageBoxButtons.YesNoCancel);
            if (r == DialogResult.Cancel)
                e.Cancel = true;
            else if(r == DialogResult.Yes)
            {
                this.Visible = false;
                controller.SerializeDatabase();
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            currentItem = null;
            //name item
            string name = "0novo item";
            for (int i = 2; containsName(name); i++)
            {
                name = name.Substring(0, 10) + i;
            }

            //identify item type
            switch (controller.CurrentBase)
            {
                case Controller.INGREDIENTS:
                    currentItem = new Ingredient(name);
                    break;
                case Controller.RECEIPTS:
                    currentItem = new Receipt(name);
                    break;
                case Controller.PRODUCTS:
                    currentItem = new Order(name, true);
                    break;
                case Controller.ORDERS:
                    currentItem = new Order(name, false);
                    break;
            }
            controller.database.addItem(currentItem);
            changeEdition(true);
            //refresh view
            updateDatabase(true);
        }
        private void databaseTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showItem(false, e.RowIndex);
        }
        private void databaseTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showItem(true, e.RowIndex);
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            showItem(true, databaseTable.CurrentCell.RowIndex);
        }
        private void duplicateButton_Click(object sender, EventArgs e)
        {
            if (currentItem == null)
                return;
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            string name = currentItem.name;
            string comp = "";
            for (int i = 2; containsName(name + comp); i++)
            {
                comp = i.ToString();
            }
            name = name + comp;

            //identify item type
            switch (controller.CurrentBase)
            {
                case Controller.INGREDIENTS:
                    currentItem = new Ingredient(currentItem, name);
                    break;
                case Controller.RECEIPTS:
                    currentItem = new Receipt(currentItem, name);
                    break;
                case Controller.PRODUCTS:
                    currentItem = new Order(currentItem, name);
                    break;
                case Controller.ORDERS:
                    currentItem = new Order(currentItem, name);
                    break;
            }
            controller.database.addItem(currentItem);
            changeEdition(true);
            //refresh view
            updateDatabase(true);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentItem != null)
            {
                int index = controller.onSpot.IndexOf(currentItem);
                controller.deleteItem(currentItem);
                if ((controller.onSpot.Count == 1) || (index == 0))
                    currentItem = null;
                else
                {
                    index = Math.Min(index, controller.onSpot.Count - 1) - 1;
                    currentItem = controller.onSpot.ElementAt(index);
                }
                updateDatabase(true);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            changeEdition(false);
            getItemInfo(currentItem);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (!editing)
            {
                return;
            }
            OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string picPath = controller.loadImage(dialog.FileName);
                if (picPath == null)
                {
                    MessageBox.Show("O arquivo selecionado não é compatível.", "Erro ao abrir imagem.");
                }
                else
                {
                    if (!currentItem.picPath.Equals("defaultPic.jpg"))
                    {
                        File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "pictures", currentItem.picPath));
                        File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", currentItem.picPath));
                    }
                    currentItem.setPicPath(picPath);
                    Image img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures", picPath));
                    if(img == null)
                    {
                        currentItem.setPicPath();
                        MessageBox.Show("O arquivo selecionado não é compatível.", "Erro ao abrir imagem.");
                    }
                    else
                    {
                        pictureBox.Image = img;
                    }
                }
            }
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            Item item = controller.getFirstIngredient();
            if (item == null)
                return;
            if (currentItem.typeItem == Controller.RECEIPTS)
            {
                Receipt receipt = (Receipt)currentItem;
                //add item to list
                receipt.itemsForReceipt.Add(item);
                for (int i = 0; i < receipt.sizes.Count; i++)
                {
                    receipt.quantities.ElementAt(i).Add(0);
                }
                updateIngredientTable();
            }
            else if(currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
            {
                Order order = (Order)currentItem;
                //add item to list
                order.items.Add(item);
                order.sizes.Add("");
                order.quantities.Add(((Ingredient)item).quantity);
                updateIngredientTable();
            }
        }

        private void removeLineButtonClick(object sender, EventArgs e)
        {
            int index = ingredientTable.CurrentCell.RowIndex;
            if (index == -1)
                return;
            if (currentItem.typeItem == Controller.RECEIPTS)
            {
                Receipt receipt = (Receipt)currentItem;
                if (receipt.itemsForReceipt.Count == 0)
                    return;

                receipt.itemsForReceipt.RemoveAt(index);
                for (int i = 0; i < receipt.sizes.Count; i++)
                {
                    receipt.quantities.ElementAt(i).RemoveAt(index);
                }
                updateIngredientTable();
            }
            else if(currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
            {
                Order order = (Order)currentItem;
                if (order.items.Count == 0)
                    return;
                order.items.RemoveAt(index);
                order.sizes.RemoveAt(index);
                order.quantities.RemoveAt(index);
                updateIngredientTable();
            }
        }

        private void renameCollumnButton_Click(object sender, EventArgs e)
        {
            string res = Prompt.ShowDialog(true, null);
            int index = ingredientTable.CurrentCell.ColumnIndex - 2;
            if ((currentItem.typeItem == Controller.RECEIPTS) && (ingredientTable.Columns.Count > 2) && (index >= 0))
            {
                ((Receipt)currentItem).sizes.RemoveAt(index);
                ((Receipt)currentItem).sizes.Insert(index, res);
                updateIngredientTable();
            }
        }

        private void addCollumnButton_Click(object sender, EventArgs e)
        {
            string res = Prompt.ShowDialog(true, null);
            
            if(currentItem.typeItem == Controller.RECEIPTS)
            {
                //add collumn to receipts
                Receipt receipt = (Receipt)currentItem;
                receipt.sizes.Add(res);
                List<float> newColl = new List<float>();
                for(int i = 0; i < receipt.itemsForReceipt.Count; i++)
                {
                    newColl.Add(0);
                }
                receipt.quantities.Add(newColl);
                updateIngredientTable();
            }
        }
        

        private void removeCollumnButton_Click(object sender, EventArgs e)
        {
            int index = ingredientTable.CurrentCell.ColumnIndex - 2;
            if ((currentItem.typeItem == Controller.RECEIPTS) && (ingredientTable.Columns.Count > 2) && (index >= 0))
            {
                //remove collumn to receipts
                Receipt receipt = (Receipt)currentItem;
                receipt.sizes.RemoveAt(index);
                receipt.quantities.RemoveAt(index);
                updateIngredientTable();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            updateDatabase(true);
        }

        public void ingredientTableCellChanged(object sender, DataGridViewCellEventArgs e)
        {
            //changes in receipt base
            if (e.ColumnIndex == 0)
            {
                //change target item and its information
                string value = (string)ingredientTable.Rows[e.RowIndex].Cells[0].Value;
                Item targetItem = controller.getItemByName(value);
                if (targetItem != null)
                {
                    if (controller.CurrentBase == Controller.RECEIPTS)
                    {
                        Receipt receipt = (Receipt)currentItem;
                        receipt.itemsForReceipt.RemoveAt(e.RowIndex);
                        receipt.itemsForReceipt.Insert(e.RowIndex, targetItem);
                        ingredientTable.Rows[e.RowIndex].Cells[1].Value = ((Ingredient)targetItem).unit;
                    }
                    else if (currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
                    {
                        Order order = (Order)currentItem;
                        if (targetItem.typeItem == Controller.RECEIPTS)
                        {
                            if (((Receipt)targetItem).sizes.Count == 0)
                            {
                                MessageBox.Show("O item selecionado não possui informações", "Erro: item inválido");
                                ingredientTable.Rows[e.RowIndex].Cells[0].Value = order.items.ElementAt(e.RowIndex).name;
                                return;
                            }
                        }
                        order.items.RemoveAt(e.RowIndex);
                        order.sizes.RemoveAt(e.RowIndex);

                        order.items.Insert(e.RowIndex, targetItem);
                        if (targetItem.typeItem == Controller.RECEIPTS)
                        {
                            order.sizes.Insert(e.RowIndex, ((Receipt)targetItem).sizes.ElementAt(0));
                            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)ingredientTable.Rows[e.RowIndex].Cells[1];
                            cell.DataSource = ((Receipt)targetItem).sizes.ToArray();
                            cell.Value = order.sizes[e.RowIndex].ToString();
                        }
                        else
                        {
                            order.sizes.Insert(e.RowIndex, "");
                            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)ingredientTable.Rows[e.RowIndex].Cells[1];
                            cell.DataSource = new string[] { "" };
                            cell.Value = order.sizes[e.RowIndex].ToString();
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if (currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
                {
                    Order order = (Order)currentItem;
                    order.sizes.RemoveAt(e.RowIndex);
                    order.sizes.Insert(e.RowIndex, (string)ingredientTable.Rows[e.RowIndex].Cells[1].Value);
                }
            }
            else if (e.ColumnIndex > 1)
            {
                //manipulate quantity on list - first check if typed value is a valid number
                if (currentItem == null)
                    return;
                if (currentItem.typeItem == Controller.INGREDIENTS)
                    return;
                if (controller.CurrentBase == Controller.RECEIPTS)
                {
                    Receipt receipt = (Receipt)currentItem;
                    float value = 0;
                    if (float.TryParse((string)ingredientTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, out value))
                    {
                        receipt.quantities.ElementAt(e.ColumnIndex - 2).RemoveAt(e.RowIndex);
                        receipt.quantities.ElementAt(e.ColumnIndex - 2).Insert(e.RowIndex, value);
                    }
                    ingredientTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = receipt.quantities.ElementAt(e.ColumnIndex - 2).ElementAt(e.RowIndex).ToString();
                }
                if (currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
                {
                    Order order = (Order)currentItem;
                    if (e.ColumnIndex == 2) // quantity column
                    {
                        float value = 0;
                        if (float.TryParse((string)ingredientTable.Rows[e.RowIndex].Cells[2].Value, out value))
                        {
                            order.quantities.RemoveAt(e.RowIndex);
                            order.quantities.Insert(e.RowIndex, value);
                        }
                    }
                    ingredientTable.Rows[e.RowIndex].Cells[2].Value = order.quantities.ElementAt(e.RowIndex).ToString();
                }
            }
            if (currentItem.typeItem == Controller.ORDERS || currentItem.typeItem == Controller.PRODUCTS)
                priceOrder();
            else
            {
                Receipt receipt = (Receipt)currentItem;
                if (receipt.sizes.Count > 0)
                {
                    float value = receipt.priceItem(receipt.sizes.ElementAt(0), receipt.yield);
                    value = (float)Math.Round(value, 2);
                    priceBox.Value = (decimal)value;
                    int pos = controller.onSpot.IndexOf(currentItem);
                    databaseTable.Rows[pos].Cells[2].Value = value.ToString();
                }
            }
        }



        #endregion
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region methods
        public bool containsName(string name)
        {
            string[] allNames = controller.getAllItemNames(new int[] { 0, 1, 2, 3 }) ;
            return allNames.Contains(name);
        }
        public void showItem(bool edit, int index)
        {
            if (index == -1)
                return;
            if (editing)
            {
                bool s = saveCurrentItemInfo();
                if (!s)
                {
                    return;
                }
            }
            databaseTable.Rows[index].Selected = true;
            getItemInfo(controller.onSpot.ElementAt(index));
            changeEdition(edit);
            if (controller.CurrentBase != Controller.INGREDIENTS)
                updateIngredientTable();
        }
        public void updateDatabase(bool getItems)
        {
            //save collumn whidt
            int[] col_sizes = new int[databaseTable.Columns.Count];
            for (int i = 0; i < databaseTable.Columns.Count; i++)
            {
                col_sizes[i] = databaseTable.Columns[i].Width;
            }

            //build vizualization on database
            if ((databaseBox.SelectedIndex == Controller.INGREDIENTS) || (databaseBox.SelectedIndex == -1))
            {
                databaseTable.Columns[2].HeaderText = "Preço (R$)";
            }
            else
            {
                databaseTable.Columns[2].HeaderText = "Último Cálculo (R$)";
            }
            List<Item> onSpot = controller.onSpot;
            if(getItems)
                onSpot = controller.getDatabase(databaseBox.SelectedIndex);

            //fill table of items
            databaseTable.Rows.Clear();
            for (int i = 0; i < onSpot.Count; i++)
            {
                Image img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", onSpot.ElementAt(i).picPath));
                if(img == null)
                {
                    onSpot.ElementAt(i).setPicPath();
                    img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", onSpot.ElementAt(i).picPath));
                }
                object[] obj = new object[] { img, onSpot.ElementAt(i).name, (decimal)onSpot.ElementAt(i).price };
                databaseTable.Rows.Add(obj);
            }
            if (databaseTable.Rows.Count > 0)
            {
                bool change = true;
                if ((currentItem != null))
                {
                    if (currentItem.typeItem == controller.CurrentBase)
                    {
                        databaseTable.Rows[onSpot.IndexOf(currentItem)].Selected = true;
                        databaseTable.CurrentCell = databaseTable.Rows[onSpot.IndexOf(currentItem)].Cells[0];
                        getItemInfo(currentItem);
                        change = false;
                    }
                }
                if (change)
                {
                    databaseTable.Rows[0].Selected = true;
                    getItemInfo(onSpot.ElementAt(0));
                }
            }

            switch (databaseBox.SelectedIndex)
            {
                case Controller.RECEIPTS:
                    quantityLabel.Text = "Rendimento:";
                    splitContainer1.Panel2Collapsed = false;
                    databaseTable.Size = new Size(450, 639);//450, 639
                    componentLabel.Visible = true;
                    priceLabel.Visible = true;
                    priceBox.Visible = true;
                    quantityLabel.Visible = true;
                    quantityBox.Visible = true;
                    break;
                case Controller.PRODUCTS:
                    splitContainer1.Panel2Collapsed = false;
                    databaseTable.Size = new Size(450, 639);
                    componentLabel.Visible = true;
                    priceLabel.Visible = true;
                    priceBox.Visible = true;
                    quantityLabel.Visible = false;
                    quantityBox.Visible = false;
                    break;
                case Controller.ORDERS:
                    splitContainer1.Panel2Collapsed = false;
                    databaseTable.Size = new Size(450, 639);
                    componentLabel.Visible = true;
                    priceLabel.Visible = true;
                    priceBox.Visible = true;
                    quantityLabel.Visible = false;
                    quantityBox.Visible = false;
                    break;
                default:  //ingredients selected
                    quantityLabel.Text = "Quantidade:";
                    splitContainer1.Panel2Collapsed = true;
                    databaseTable.Size = new Size(960, 639);
                    componentLabel.Visible = false;
                    priceLabel.Visible = true;
                    priceBox.Visible = true;
                    quantityLabel.Visible = true;
                    quantityBox.Visible = true;
                    return;
            }
            if(databaseBox.SelectedIndex != Controller.INGREDIENTS)
            {
                updateIngredientTable();
            }
            //set back column whidts
            for (int i = 0; i < Math.Min(col_sizes.Length, databaseTable.Columns.Count); i++)
            {
                databaseTable.Columns[i].Width = col_sizes[i];
            }
        }

        public void updateIngredientTable()
        {
            //save collumn whidt
            int[] col_sizes = new int[ingredientTable.Columns.Count];
            for(int i = 0; i < ingredientTable.Columns.Count; i++)
            {
                col_sizes[i] = ingredientTable.Columns[i].Width;
            }
            if (controller.CurrentBase == Controller.INGREDIENTS)
                return;
            ingredientTable.Rows.Clear();
            ingredientTable.Columns.Clear();
            if (currentItem == null)
                return;
            if (currentItem.typeItem != controller.CurrentBase)
                return;
            //previously selected cell
            int x = 0;
            int y = 0;
            if(ingredientTable.CurrentCell != null)
            {
                x = ingredientTable.CurrentCell.ColumnIndex;
                y = ingredientTable.CurrentCell.RowIndex;
            }
            if(controller.CurrentBase == Controller.RECEIPTS)
            {
                Receipt receipt = (Receipt)currentItem;
                //add first item collumn with comboboxes and unit collumn
                DataGridViewComboBoxColumn itemCol = new DataGridViewComboBoxColumn();
                itemCol.DataSource = controller.getAllItemNames(new int[] { Controller.INGREDIENTS });
                itemCol.HeaderText = "Ingredientes";
                itemCol.DataPropertyName = "item";
                ingredientTable.Columns.Add(itemCol);
                ingredientTable.Columns.Add("unidade", "unidade");
                ingredientTable.Columns[1].ReadOnly = true;

                //add size collumns
                for (int i = 0; i < receipt.sizes.Count; i++)
                {
                    ingredientTable.Columns.Add(receipt.sizes.ElementAt(i), receipt.sizes[i]);
                }
                for(int i = 0; i < receipt.itemsForReceipt.Count; i++)
                {
                    //build line for table
                    string[] line = new string[receipt.sizes.Count + 2];
                    line[0] = receipt.itemsForReceipt.ElementAt(i).name;
                    line[1] = ((Ingredient)receipt.itemsForReceipt.ElementAt(i)).unit;
                    for(int j = 0; j < receipt.sizes.Count; j++)
                    {
                        line[j + 2] = receipt.quantities.ElementAt(j).ElementAt(i).ToString();
                    }
                    ingredientTable.Rows.Add(line);
                }
            }
            else
            {
                Order order = (Order)currentItem;
                //add first item collumn with comboboxes and unit collumn
                DataGridViewComboBoxColumn itemCol = new DataGridViewComboBoxColumn();
                itemCol.DataSource = controller.getAllItemNames(new int[] { Controller.INGREDIENTS, Controller.RECEIPTS });
                itemCol.HeaderText = "Itens";
                itemCol.DataPropertyName = "item";

                //add secondly sizes columns costumized by receipt sizes
                DataGridViewComboBoxColumn sizeColumn = new DataGridViewComboBoxColumn();
                sizeColumn.HeaderText = "Tamanho";
                sizeColumn.DataPropertyName = "tamanho";

                ingredientTable.Columns.Add(itemCol);
                ingredientTable.Columns.Add(sizeColumn);
                ingredientTable.Columns.Add("quantidade", "quantidade");
                ingredientTable.Columns.Add("valor", "valor");
                ingredientTable.Columns[3].ReadOnly = true;

                for (int i = 0; i < order.items.Count; i++)
                {
                    //build line for table
                    string[] line = new string[4];
                    line[0] = order.items.ElementAt(i).name;
                    line[1] = order.sizes.ElementAt(i);
                    line[2] = order.quantities.ElementAt(i).ToString();
                    ingredientTable.Rows.Add(line);

                    //build costumized datasource
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)ingredientTable.Rows[i].Cells[1];
                    if(order.items.ElementAt(i).typeItem == Controller.RECEIPTS)
                    {
                        cell.DataSource = ((Receipt)order.items.ElementAt(i)).sizes.ToArray();
                    }
                    else
                    {
                        cell.DataSource = new string[] { "" };
                    }
                }
                priceOrder();
            }

            //select row of table
            if((ingredientTable.Rows.Count > 0) && (ingredientTable.Columns.Count > 0))
            {
                x = Math.Min(Math.Max(0, x), ingredientTable.Columns.Count - 1);
                y = Math.Min(Math.Max(0, y), ingredientTable.Rows.Count - 1);
                ingredientTable.ClearSelection();
                ingredientTable.CurrentCell = ingredientTable.Rows[y].Cells[x];
            }
            //set back column whidts
            for(int i = 0; i < Math.Min(col_sizes.Length, ingredientTable.Columns.Count); i++)
            {
                ingredientTable.Columns[i].Width = col_sizes[i];
            }
        }
        public static Image GetImage(string path)
        {
            try
            {
                Image img;
                using (var bmpTemp = new Bitmap(path))
                {
                    img = new Bitmap(bmpTemp);
                }
                return img;
            }
            catch
            {
                return null;
            }
        }

        public void getItemInfo(Item item)
        {
            this.currentItem = item;
            nameBox.Text = item.name;
            Image img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures", item.picPath));
            if(img == null)
            {
                item.setPicPath();
                img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures", item.picPath));
            }
            pictureBox.Image = img;
            priceBox.Value = (decimal)item.price;
            dateCreation.Text = item.creationDate.ToString("dd/MM/yyyy");
            dateEdition.Text = item.lastChange.ToString("dd/MM/yyyy");
            descriptionBox.Text = currentItem.description;
            //quality specific properties
            if (currentItem.typeItem == Controller.INGREDIENTS)
            {
                quantityBox.Value = (decimal)((Ingredient)currentItem).quantity;
                unitCombobox.Text = ((Ingredient)currentItem).unit;
            }
            else if (currentItem.typeItem == Controller.RECEIPTS)
            {
                quantityBox.Value = (decimal)((Receipt)currentItem).yield;
                unitCombobox.Text = ((Receipt)currentItem).unit;
            }
        }
        public bool saveCurrentItemInfo()
        {
            bool succ = controller.database.changeItemName(currentItem, nameBox.Text);
            if (!succ)
            {
                MessageBox.Show("Erro: o nome " + nameBox.Text + " já existe no banco ou nome está vazio.");
                changeEdition(true);
                return false;
            }
            currentItem.setDescription(descriptionBox.Text);
            currentItem.setPrice(priceBox.Value);
            if (currentItem.typeItem == Controller.INGREDIENTS)
            {
                ((Ingredient)currentItem).setQuantity((float)quantityBox.Value);
                ((Ingredient)currentItem).setUnit(unitCombobox.Text);
            }
            else if (currentItem.typeItem == Controller.RECEIPTS)
            {
                ((Receipt)currentItem).setQuantity((float)quantityBox.Value);
                ((Receipt)currentItem).setUnit(unitCombobox.Text);
            }

            //replace information on item row
            Image img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", currentItem.picPath));
            if(img == null)
            {
                currentItem.setPicPath();
                img = GetImage(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small", currentItem.picPath));
            }
            object[] obj = new object[] { img, currentItem.name, (decimal)currentItem.price };
            int pos = controller.onSpot.IndexOf(currentItem);
            databaseTable.Rows.RemoveAt(pos);
            databaseTable.Rows.Insert(pos, obj);
            return true;
        }

        public void changeEdition(bool edit)
        {
            this.editing = edit;
            nameBox.Enabled = edit;
            priceBox.Enabled = edit && (controller.CurrentBase == Controller.INGREDIENTS);
            quantityBox.Enabled = edit;
            unitCombobox.Enabled = edit;
            descriptionBox.Enabled = edit;
            addLineButton.Visible = edit;
            removeLineButton.Visible = edit;
            addCollumnButton.Visible = edit && (controller.CurrentBase == Controller.RECEIPTS);
            removeCollumnButton.Visible = edit && (controller.CurrentBase == Controller.RECEIPTS);
            renameCollumnButton.Visible = edit && (controller.CurrentBase == Controller.RECEIPTS);
            ingredientTable.ReadOnly = !edit;
            if(ingredientTable.Columns.Count > 1)
            {
                if(controller.CurrentBase == Controller.RECEIPTS)
                    ingredientTable.Columns[1].ReadOnly = true;
                else
                    ingredientTable.Columns[3].ReadOnly = true;
            }
        }

        public void priceOrder()
        {
            if (!((controller.CurrentBase == Controller.ORDERS) || (controller.CurrentBase == Controller.PRODUCTS)))
                return;
            if (currentItem == null)
                return;
            if (currentItem.typeItem != controller.CurrentBase)
                return;
            if (databaseTable.Rows.Count == 0)
                return;
            
            Order order = (Order)currentItem;
            order.priceItem(null, 0);
            float totalPrice = (float)Math.Round(order.price, 2);
            priceBox.Value = (decimal)totalPrice;
            int pos = controller.onSpot.IndexOf(currentItem);
            databaseTable.Rows[pos].Cells[2].Value = totalPrice.ToString();
            //populate prices of items on ingredient table
            for (int i = 0; i < order.items.Count; i++)
            {
                if(ingredientTable.Rows.Count > (i))
                {
                    float value = 0;
                    if(order.items.ElementAt(i).typeItem == Controller.INGREDIENTS)
                    {
                        Ingredient ing = (Ingredient)order.items.ElementAt(i);
                        value = (order.quantities.ElementAt(i) / ing.quantity) * ing.price;
                    }
                    else
                    {
                        Receipt rec = (Receipt)order.items.ElementAt(i);
                        value = (order.quantities.ElementAt(i) / rec.yield) * rec.price;
                    }
                    ingredientTable.Rows[i].Cells[3].Value = Math.Round(value, 2);
                }
            }

            ////set result at last row
            //if(ingredientTable.Rows.Count == order.items.Count)
            //{
            //    ingredientTable.Rows.Add(new string[] { "", "", "", totalPrice.ToString() });
            //    ingredientTable.Rows[ingredientTable.Rows.Count - 1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18, GraphicsUnit.Pixel);
            //}
            //else
            //{
            //    ingredientTable.Rows[ingredientTable.Rows.Count - 1].Cells[3].Value = totalPrice.ToString();
            //}
        }



        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.backupParallel();
        }
    }
    public static class Prompt
    {
        public static string ShowDialog(bool getName, string[] collection)
        {
            
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Selecione a informação desejada:",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "tamanho:" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            ComboBox itemBox = new ComboBox() { Left = 50, Top = 50, Width = 400 };
            if(getName)
            {
                prompt.Controls.Add(textBox);
            }
            else
            {
                textLabel.Text = "item:";
                prompt.Controls.Add(itemBox);
                itemBox.Items.AddRange(collection);
            }
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            if(getName)
            {
                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
            else
            {
                return prompt.ShowDialog() == DialogResult.OK ? itemBox.Text : "";
            }
        }
    }
}
