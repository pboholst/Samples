using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchBox02
{
    public partial class FormTwo : Form
    {
        public FormTwo()
        {
            InitializeComponent();
            testSearch();
        }

        public void testSearch()
        {
            // Create the list to use as the custom source. 
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                            {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May January",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                            });

            // Create and initialize the text box.
            var comboBox = new ComboBox
            {
                AutoCompleteCustomSource = source,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.CustomSource,
                Location = new Point(5, 5),
                Width = panel1.Width - 10,
                Visible = true
            };
            panel1.Height = comboBox.Height + 10;

            for (int i = 0; i < source.Count; i++)
            {
                comboBox.Items.Add(source[i]);
            }
            //comboBox.Items.Add(source[0]);

            // Add the text box to the form.
            panel1.Controls.Add(comboBox);
        }
    }
}
