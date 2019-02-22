using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
 //Строка подключения
       public static SqlConnection con = new SqlConnection(@"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Zagorod_Nedvig;User ID=user_zagorod;Password = 123");

        public Form4()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
    //Проверка входа
            con.Open();
       SqlCommand com = new SqlCommand("Select Prava from Zagorod_Nedvig_Polzovatel where Login='"+ textBox1.Text + "' and Password='"+ textBox2.Text + "'", con);
    
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string prava = reader[0].ToString();
                if (prava == "R")
                {
                    reader.Close();
                    con.Close();
                    Form f1 = new Form1();
                    f1.Show();
                    this.Hide();                    
                    break;
                }
                else if (prava == "I")
                {
                    reader.Close();
                    con.Close();
                    Form f2 = new Form2();
                    f2.Show();
                    this.Hide();
                    break;
                }
                else if (prava == "S")
                {
                    reader.Close();
                    con.Close();
                    Form f3 = new Form3();
                    f3.Show();
                    this.Hide();
                    break;
                }
            }
            reader.Close();
           con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
