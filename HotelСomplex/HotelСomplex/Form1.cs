using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelСomplex
{
    public partial class Form1 : Form
    {
        Call_DB Call_db = new Call_DB();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "user1234";
            textBox2.Text = "277353";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Call_db.Open();
            if (Call_db.Select_user(textBox1.Text, textBox2.Text))
            {
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("Не верные данные для авторизации");
            }
            Call_db.Close();
        }
    }
}
