using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetFramework
{
    public partial class EditForm : Form
    {
        public static int FruitID;
        public EditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string color = String.Empty;
            int amount = -1, seed = -1, trees = -1;
            double price = -1;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                color = textBox4.Text.Trim();
                if (int.TryParse(textBox2.Text.Trim(), out amount) == false)
                {
                    Form1.ShowError("Enter correct amount");
                    return;
                }
                if (double.TryParse(textBox3.Text.Trim(), out price) == false)
                {
                    Form1.ShowError("Enter correct price");
                    return;
                }
                if (int.TryParse(textBox5.Text.Trim(), out seed) == false)
                {
                    Form1.ShowError("Enter correct seed");
                    return;
                }
                if (int.TryParse(textBox6.Text.Trim(), out trees) == false)
                {
                    Form1.ShowError("Enter correct trees");
                    return;
                }
            }
            else
            {
                if (int.TryParse(textBox2.Text.Trim(), out amount) == false)
                {
                    Form1.ShowError("Enter correct amount");
                    return;
                }
                if (double.TryParse(textBox3.Text.Trim(), out price) == false)
                {
                    Form1.ShowError("Enter correct price");
                    return;
                }
            }


            // convert from fruit to apple
            if(Form1.MainForm.salad.Fruits[FruitID] is Fruit && checkBox1.CheckState == CheckState.Checked)
            {
                Form1.MainForm.salad.Fruits.RemoveAt(FruitID);
                Apple apple = new Apple(name, color, amount, price, seed, trees);
                Form1.MainForm.salad.Fruits.Add(apple);

            }
            // convert from apple to fruit
            else if(Form1.MainForm.salad.Fruits[FruitID] is Apple && checkBox1.CheckState == CheckState.Unchecked)
            {
                Form1.MainForm.salad.Fruits.RemoveAt(FruitID);
                Fruit fruit = new Fruit(name, amount, price);
                Form1.MainForm.salad.Fruits.Add(fruit);
            }
            else
            {
                if(Form1.MainForm.salad.Fruits[FruitID] is Apple)
                {
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Name = name;
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Amount = amount;
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Price = price;
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Color = color;
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Seed = seed;
                    (Form1.MainForm.salad.Fruits[FruitID] as Apple).Trees = trees;
                }
                else
                {
                    Form1.MainForm.salad.Fruits[FruitID].Name = name;
                    Form1.MainForm.salad.Fruits[FruitID].Amount = amount;
                    Form1.MainForm.salad.Fruits[FruitID].Price = price;

                }
            }

            this.Close();
            BeforeCloseForm(updateListBox: true);
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.MainForm.salad.Fruits[FruitID].Name;
            textBox2.Text = Form1.MainForm.salad.Fruits[FruitID].Amount.ToString();
            textBox3.Text = Form1.MainForm.salad.Fruits[FruitID].Price.ToString();

            if (Form1.MainForm.salad.Fruits[FruitID] is Apple)
            {
                ShowAppleFields();
                textBox4.Text = (Form1.MainForm.salad.Fruits[FruitID] as Apple).Color.ToString();
                textBox5.Text = (Form1.MainForm.salad.Fruits[FruitID] as Apple).Seed.ToString();
                textBox6.Text = (Form1.MainForm.salad.Fruits[FruitID] as Apple).Trees.ToString();
            }
            else HideAppleFields();
        }
        private void ShowAppleFields()
        {
            label4.Visible = label5.Visible = label6.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = true;
            checkBox1.CheckState = CheckState.Checked;
        }
        private void HideAppleFields()
        {
            label4.Visible = label5.Visible = label6.Visible = textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
            checkBox1.CheckState = CheckState.Unchecked;
        }
        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
            => BeforeCloseForm();

        private void BeforeCloseForm(bool updateListBox = false)
        {
            Form1.MainForm.Enabled = true;
            if (updateListBox)
                Form1.MainForm.UpdateListBox();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                ShowAppleFields();
            else HideAppleFields();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BeforeCloseForm();
            this.Close();
        }
    }
}
