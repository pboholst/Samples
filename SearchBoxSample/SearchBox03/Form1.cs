using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Need to implement key down press on list focus() on it 
 * and back to text if alphabet is pressed focus() switch
 * 
 */
namespace SearchBox03
{
    public partial class Form1 : Form
    {
        List<MyData> allSavedJobFunctions = new List<MyData>();
        public Form1()
        {
            InitializeComponent();

            allSavedJobFunctions.Add(new MyData("Address Deletion"));
            allSavedJobFunctions.Add(new MyData("Templates"));
            allSavedJobFunctions.Add(new MyData("CAPS Actionables"));
            allSavedJobFunctions.Add(new MyData("CAPS Batch"));
            allSavedJobFunctions.Add(new MyData("Web information"));
            allSavedJobFunctions.Add(new MyData("iiiiii"));

            dataGridView1.DataSource = allSavedJobFunctions;
            ListBoxInit();
        }
        Point p1 = new Point();

        ListBox listBox;
        private void ListBoxInit()
        {
            listBox = new ListBox
            {
                BackColor = SystemColors.ActiveCaption,
                Location = new Point(textBox1.Location.X, textBox1.Location.X - 10),
                Width = textBox1.Width,
                Height = textBox1.Height - 30,
                Visible = true
            };
            
            this.Controls.Add(listBox);
            //listBox.Items.Add("Address Deletion");
            //listBox.Items.Add("Templates");
            //listBox.Items.Add("CAPS Actionables");
            //listBox.Items.Add("CAPS Batch");
            //listBox.Items.Add("Web information");


        }
        int listBoxHeight = 13;
        int newListBoxHeight = 0;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            listBox.Items.Clear();
            if(textBox1.Text.Length > 0)
            {
                
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                List<MyData> showSearchList = new List<MyData>();
                

                for (int i = 0; i < allSavedJobFunctions.Count; i++)
                {
                    bool exist = allSavedJobFunctions[i].Desc.ToLower().ToString().Contains(textBox1.Text.ToLower());
                    if (exist == true)
                    {
                        //Console.WriteLine("Saved text contains it at index position" + allSavedJobFunctions[i].Desc.ToLower().IndexOf(textBox1.Text.ToLower()).ToString());
                        showSearchList.Add(allSavedJobFunctions[i]);
                        listBox.Items.Add(allSavedJobFunctions[i].Desc);
                    }
                }
                dataGridView1.DataSource = showSearchList;
                newListBoxHeight = 4 + (listBoxHeight * showSearchList.Count);
                listBox.Height = newListBoxHeight; // gotta incrament it 13
                //Console.WriteLine(newListBoxHeight + " listBox.Height: " + listBox.Height);
            }
            else
            {
                this.listBox.Height = textBox1.Height - 30;
            }

        }

    }


    public class MyData
    {
        private string desc;

        public MyData(string desc)
        {
            this.Desc = desc;
        }
        public string Desc { get => desc; set => desc = value; }
    }
}
