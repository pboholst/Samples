using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchBox01
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
            allSavedJobFunctions.Add(new MyData("Web information"));

            dataGridView1.DataSource = allSavedJobFunctions;

        }
        //string[] savedText = { "Himalayan", "xerox" };

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            List<MyData> showSearchList = new List<MyData>();

            for (int i = 0; i < allSavedJobFunctions.Count; i++)
            {
                bool exist = allSavedJobFunctions[i].Desc.ToLower().ToString().Contains(textBox1.Text.ToLower());
                if (exist == true)
                {
                    Console.WriteLine("Saved text contains it at index position" + allSavedJobFunctions[i].Desc.ToLower().IndexOf(textBox1.Text.ToLower()).ToString());
                    showSearchList.Add(allSavedJobFunctions[i]);
                }
            }
            dataGridView1.DataSource = showSearchList;
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
