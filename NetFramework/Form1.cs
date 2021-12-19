using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NetFramework.Import;

namespace NetFramework
{

    public partial class Form1 : Form
    {
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void WriteToFile([MarshalAs(UnmanagedType.LPStr)] string path);
        #region DllImport
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReadFromFile([MarshalAs(UnmanagedType.LPStr)] string path);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPlateSize();
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsApple(int idx);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetFruit(ref FruitImport fruit, int idx);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetApple(ref AppleImport apple, int idx);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppleAdd(ref AppleImport apple);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FruitAdd(ref FruitImport fruit);
        [DllImport("mfclib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearPlate();
        #endregion

        public Salad salad;
        public static Form1 MainForm;
        public static void ShowError(string text)
            => MessageBox.Show(text);

        public Form1()
        {
            InitializeComponent();
            MainForm = this;
            salad = new Salad();
            //AppleImport apple = new AppleImport()
            //{
            //    Name = "yabloko",
            //    Amount = 12,
            //    Price = 1.23,
            //    Color = "green",
            //    Seed = 5,
            //    Trees = 1222
            //};
            //AddApple(ref apple);

            ////WriteToFile("store.dat");
            ////ReadFromFile("store.dat");

            //if(IsApple(0))
            //{
            //    var importedApple = new AppleImport();
            //    GetApple(ref importedApple, 0);
            //    salad.Fruits.Add(Salad.ConvertImportAppleToApple(importedApple));
            //}
        }

        // add new fruit to listbox & salad fruits
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();

            int amount = -1;
            if (int.TryParse(textBox2.Text, out amount) == false)
            {
                ShowError("Enter correct amount");
            }

            double price = -1;
            if(double.TryParse(textBox3.Text, out price) == false)
            {
                ShowError("Enter correct price");
                return;
            }

            Fruit fruit = new Fruit(name, amount, price);
            salad.Fruits.Add(fruit);

            listBox1.Items.Add(fruit.ToString());
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        // add new apple to listbox & salad fruits
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();

            int amount = -1;
            if (int.TryParse(textBox2.Text, out amount) == false)
            {
                ShowError("Enter correct amount");
            }

            double price = -1;
            if (double.TryParse(textBox3.Text, out price) == false)
            {
                ShowError("Enter correct price");
                return;
            }

            string color = textBox4.Text.Trim();
            int seed = -1;
            if(int.TryParse(textBox5.Text, out seed) == false)
            {
                ShowError("Enter correct seed");
                return;
            }

            int trees = -1;
            if(int.TryParse(textBox6.Text, out trees) == false)
            {
                ShowError("Enter correct trees");
                return;
            }

            Apple apl = new Apple(name, color, amount, price, seed, trees);
            salad.Fruits.Add(apl);
            listBox1.Items.Add(apl.ToString());
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                ShowError("Select any fruit in listbox");
                return;
            }
            EditForm.FruitID = listBox1.SelectedIndex;
            EditForm editForm = new EditForm();
            editForm.StartPosition = FormStartPosition.CenterScreen;
            MainForm.Enabled = false;
            editForm.Show();
        }


        public void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach(var fr in salad.Fruits)
            {
                listBox1.Items.Add(fr.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // saving plate
            ClearPlate();
            foreach(var fr in salad.Fruits)
            {
                if (fr is Apple)
                {
                    AppleImport apl = Salad.ConvertAppleToImportApple(fr as Apple);
                    AppleAdd(ref apl);
                }
                else
                {
                    FruitImport frt = Salad.ConvertFruitToImportFruit(fr);
                    FruitAdd(ref frt);
                }
            }

            WriteToFile("savedHERE.dat");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReadFromFile("savedHERE.dat");
            WriteToFile("savedFromLoaded.dat");
            int plateSize = GetPlateSize();
            for (int i = 0; i < plateSize; i++)
            {
                if(IsApple(i))
                {
                    AppleImport apl = new AppleImport();
                    GetApple(ref apl, i);
                    salad.Fruits.Add(Salad.ConvertImportAppleToApple(apl));
                }
                else
                {
                    FruitImport frt = new FruitImport();
                    GetFruit(ref frt, i);
                    salad.Fruits.Add(Salad.ConvertImportFruitToFruit(frt));
                }
            }

            UpdateListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            salad.Fruits.Clear();
            ClearPlate();
            UpdateListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
            {
                ShowError("Select anything from listbox");
                return;
            }
            salad.Fruits.RemoveAt(listBox1.SelectedIndex);
            UpdateListBox();
        }
    }
}
