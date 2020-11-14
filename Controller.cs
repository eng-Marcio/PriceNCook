using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO.Compression;
using System.Threading.Tasks;

namespace PriceNCook
{
    class Controller
    {
        #region attributes
        private FrontEndControl frontEndControl;
        public Database database { get; private set; }


        //behavior control
        public List<Item> onSpot;

        public int CurrentBase = -1;
        public const int INGREDIENTS = 0;
        public const int RECEIPTS = 1;
        public const int PRODUCTS = 2;
        public const int ORDERS = 3;
        public const string mac = "20689D8090FD"; //"20689D8090FD"8091338B1E69
        //mac protection: simple way to garantee the software wont be copied without being licenced before

        #endregion
        #region constructor
        public Controller(FrontEndControl frontEnd)
        {
            if(!GetMACAddress().Equals(mac))
            {
                System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "mac.txt"), GetMACAddress());
                frontEnd.Close();
                System.Environment.Exit(0); //when unnexpected user is using the app, it automatic closes, as if it crashed
            }
            this.frontEndControl = frontEnd;
            initializeDatabase();
            backupParallel();
        }
        #endregion

        #region methods
        public List<Item> getDatabase(int baseSelected)
        {
            //if (baseSelected != CurrentBase)
            {
                //get new lists from database
                CurrentBase = baseSelected;
                onSpot = database.getTableForVisualization(CurrentBase, 10000, 0);
            }
            return onSpot; 
        }
        public List<Item> filterItems(string s)
        {
            if (s.Trim().Equals(""))
                return onSpot;
            string[] list = s.Split(' ');
            for(int i = 0; i < onSpot.Count; i++)
            {
                bool toDel = false;
                for(int j = 0; j < list.Length; j++)
                {
                    if(!onSpot.ElementAt(i).name.Contains(list[j]))
                    {
                        toDel = true;
                        break;
                    }
                }
                if(toDel)
                {
                    onSpot.RemoveAt(i);
                    i--;
                }
            }
            return onSpot;
        }

        #region IO
        public void initializeDatabase()
        {
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "data.bin")))
            {
                DialogResult r = MessageBox.Show("Dataset was not found on current directory. Do you wish to create a new dataset?", "Dataset not found", MessageBoxButtons.YesNo);
                if(r == DialogResult.Yes)
                {
                    //create new dataset for system
                    this.database = new Database();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                DeserializeDatabase();
            }
        }
        public void SerializeDatabase()
        {
            FileStream s = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "data.bin"), FileMode.Create);
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                format.Serialize(s, database);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                s.Close();
            }
        }
        public void DeserializeDatabase()
        {
            FileStream s = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "data.bin"), FileMode.Open);
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                this.database = (Database)format.Deserialize(s);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                s.Close();
            }
        }
        public Item getFirstIngredient()
        {
            List<Item> items = database.getTableForVisualization(Controller.INGREDIENTS, 1, 0);
            if (items.Count > 0)
                return items.ElementAt(0);
            return null;
        }

        public Item getItemByName(string name)
        {
            return database.getItem(name);
        }
        public void deleteItem(Item item)
        {
            database.allItems.Remove(item);
        }

        public string[] getAllItemNames(int[] fromBase)
        {
            List<string> res = new List<string>();
            for(int i = 0; i < database.allItems.Count; i++)
            {
                Item item = database.allItems.ElementAt(i);
                if(fromBase.Contains(item.typeItem))
                    res.Add(item.name);
                
            }
            return res.ToArray();
        }

        public string loadImage(string path)
        {
            if(!File.Exists(path))
            {
                return null;
            }
            string picPath = ImageProcessing.ProcessImages(path);
            return picPath;
        }
        private string GetMACAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }
        public void backupParallel()
        {
            Task.Run(() => backup());
        }
        public void backup()
        {
            DirectoryCopy(Path.Combine(Directory.GetCurrentDirectory(), "pictures"), Path.Combine(Path.GetTempPath(), "backupP_N_C/pictures/"), true);
            DirectoryCopy(Path.Combine(Directory.GetCurrentDirectory(), "pictures_small"), Path.Combine(Path.GetTempPath(), "backupP_N_C/pictures_small/"), true);
            FileStream s = new FileStream(Path.Combine(Path.GetTempPath(), "backupP_N_C/data.bin"), FileMode.Create);
            BinaryFormatter format = new BinaryFormatter();
            try
            {
                format.Serialize(s, database);
                s.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao fazer o backup do sistema");
            }
            int num = DateTime.Today.Day % 3; //system keeps 3 different backups for 3 different days based on the days' number, on this way, there will be 3 different former backups in case of loss
            string pathsource = Path.Combine(Path.GetTempPath(), "backupP_N_C/");
            string zipPath = Path.Combine(Directory.GetCurrentDirectory(), "backup" + num + ".zip");
            if(File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(pathsource, zipPath);
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        #endregion
        #endregion

    }
}
