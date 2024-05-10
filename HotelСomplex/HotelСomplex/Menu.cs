using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelСomplex
{
    public partial class Menu : Form
    {
        Call_DB Call_db = new Call_DB();
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {guest_load(); room_load(); staff_load(); prof_load();}
        public void guest_load()
        {DataSet dataSet = Call_db.Request("SELECT * FROM Guests");
            for(int i = 0; i < dataSet.Tables[0].Rows.Count; i++) 
            {comboBox1.Items.Add(dataSet.Tables[0].Rows[i][1].ToString());}
        }
        public void room_load()
        {DataSet dataSet = Call_db.Request("SELECT * FROM Rooms");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {comboBox2.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());}
        }
        public void staff_load()
        {DataSet dataSet = Call_db.Request("SELECT * FROM Staff");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {comboBox3.Items.Add(dataSet.Tables[0].Rows[i][1].ToString());}
        }
        public void prof_load()
        {DataSet dataSet = Call_db.Request("SELECT * FROM Profession");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {comboBox4.Items.Add(dataSet.Tables[0].Rows[i][1].ToString());}
        }
        private void button1_Click(object sender, EventArgs e)
        {select_table("SELECT * FROM Guests");}
        private void button2_Click(object sender, EventArgs e)
        {select_table("SELECT * FROM Rooms");}
        private void button3_Click(object sender, EventArgs e)
        {select_table("SELECT * FROM Staff");}
        private void button4_Click(object sender, EventArgs e)
        {select_table("SELECT * FROM Profession");}
        public void select_table(string querys)
        {
            DataSet ds = Call_db.Request(querys);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0 
               && textBox2.Text.Length > 0
               && textBox3.Text.Length > 0
               && textBox4.Text.Length > 0) 
            {
                Call_db.Request("INSERT INTO Guests" +
                    "(`surnames`," +
                    "`namess`," +
                    "`father_namess`," +
                    "`id_room`) VALUES" +
                    $"('{textBox2.Text}'," +
                    $"'{textBox1.Text}'," +
                    $"'{textBox4.Text}'," +
                    $"'{textBox3.Text}')");

                DataSet ds = Call_db.Request("SELECT * FROM Guests");
                dataGridView1.DataSource = ds.Tables[0];
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Items.Clear();
                guest_load();
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0
               && textBox8.Text.Length > 0)
            {
                Call_db.Request("INSERT INTO Rooms" +
                    "(`floor`," +
                    "`beds`) VALUES" +
                    $"('{textBox7.Text}'," +
                    $"'{textBox8.Text}')");

                DataSet ds = Call_db.Request("SELECT * FROM Rooms");
                dataGridView1.DataSource = ds.Tables[0];
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox2.Items.Clear();
                room_load();
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0
               && textBox10.Text.Length > 0
               && textBox5.Text.Length > 0
               && textBox6.Text.Length > 0)
            {
                Call_db.Request("INSERT INTO Staff" +
                    "(`surnames`," +
                    "`namess`," +
                    "`father_namess`," +
                    "`post`) VALUES" +
                    $"('{textBox9.Text}'," +
                    $"'{textBox10.Text}'," +
                    $"'{textBox6.Text}'," +
                    $"'{textBox5.Text}')");

                DataSet ds = Call_db.Request("SELECT * FROM Staff");
                dataGridView1.DataSource = ds.Tables[0];
                textBox9.Text = "";
                textBox10.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox3.Items.Clear();
                staff_load();
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Length > 0)
            {
                Call_db.Request("INSERT INTO Profession" +
                    "(`namess`) VALUES" +
                    $"('{textBox11.Text}')");

                DataSet ds = Call_db.Request("SELECT * FROM Profession");
                dataGridView1.DataSource = ds.Tables[0];
                textBox11.Text = "";
                comboBox4.Items.Clear();
                prof_load();
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Length > 0)
            {
                Call_db.Request($"DELETE FROM Guests WHERE surnames = '{comboBox1.Text}'");
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                guest_load();
                select_table("SELECT * FROM Guests");
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length > 0)
            {
                Call_db.Request($"DELETE FROM Rooms WHERE id = {comboBox2.Text}");
                comboBox2.Text = "";
                comboBox2.Items.Clear();
                room_load();
                select_table("SELECT * FROM Rooms");
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text.Length > 0)
            {
                Call_db.Request($"DELETE FROM Staff WHERE surnames = '{comboBox3.Text}'");
                comboBox3.Text = "";
                comboBox3.Items.Clear();
                staff_load();
                select_table("SELECT * FROM Staff");
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text.Length > 0)
            {
                Call_db.Request($"DELETE FROM Profession WHERE namess = '{comboBox4.Text}'");
                comboBox4.Text = "";
                comboBox4.Items.Clear();
                prof_load();
                select_table("SELECT * FROM Profession");
            }
            else
            {
                MessageBox.Show("Вы оставили поля пустыми");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
