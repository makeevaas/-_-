using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Width = 588;
            Form4.con.Open();
      //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv " +
                "from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id " +
                "where Otpravl_Na_Ispolnen is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";
            //Вывод в DataGrid1
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Otpravl_Na_Ispolnen," +
                "Ispolneno,Otpravl_Na_Soglosovanie,Soglasovano,Otpravl_Na_Korrect,otkaz " +
                "from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id " +
                "left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id order by Zagorod_Nedvig_Zayav.id", Form4.con);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Отправлено на исполнение";
            dataGridView1.Columns[6].HeaderText = "Исполнено";
            dataGridView1.Columns[7].HeaderText = "Отправлено на согласование";
            dataGridView1.Columns[8].HeaderText = "Согласовано";
            dataGridView1.Columns[9].HeaderText = "Отправлено на корректировку";
            dataGridView1.Columns[10].HeaderText = "Отказ";
            Form4.con.Close();
        }


        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
            linkLabel9.Font = new Font(linkLabel9.Font.Name, 10, FontStyle.Regular);
            linkLabel5.Font = new Font(linkLabel5.Font.Name, 10, FontStyle.Regular);
            linkLabel8.Font = new Font(linkLabel8.Font.Name, 10, FontStyle.Bold);
            linkLabel8.BackColor = SystemColors.ControlLight;
            linkLabel5.BackColor = SystemColors.ActiveBorder;
            linkLabel9.BackColor = SystemColors.ActiveBorder;
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = true;
            linkLabel5.Font = new Font(linkLabel5.Font.Name, 10, FontStyle.Regular);
            linkLabel8.Font = new Font(linkLabel8.Font.Name, 10, FontStyle.Regular);
            linkLabel9.Font = new Font(linkLabel9.Font.Name, 10, FontStyle.Bold);
            linkLabel9.BackColor = SystemColors.ControlLight;
            linkLabel5.BackColor = SystemColors.ActiveBorder;
            linkLabel8.BackColor = SystemColors.ActiveBorder;
        }



        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            linkLabel9.Font = new Font(linkLabel9.Font.Name, 10, FontStyle.Regular);
            linkLabel8.Font = new Font(linkLabel8.Font.Name, 10, FontStyle.Regular);
            linkLabel5.Font = new Font(linkLabel5.Font.Name, 10, FontStyle.Bold);
            linkLabel5.BackColor = SystemColors.ControlLight;
            linkLabel8.BackColor = SystemColors.ActiveBorder;
            linkLabel9.BackColor = SystemColors.ActiveBorder;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
    //Очистка документов если те были внесены
            Form4.con.Open();
            SqlCommand com = new SqlCommand("delete from Zagorod_Nedvig_Documents where id_zayavl=null", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            Form4.con.Close();
            this.Width = 588;
            panel2.Visible = false;
            label28.Visible = false;
            linkLabel2.Visible = true;
            textBox9.Clear();
     //Удаление файлов из папки
            if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length > 0)
            {

                string file = Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы\file001.jpg";
                File.Delete(file);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label25.Visible = false;
                textBox4.Visible = false;
                label31.Visible = false;
                textBox22.Visible = false;
                label32.Visible = true;
                textBox23.Visible = true;
            }
        }


        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label25.Visible = true;
                textBox4.Visible = true;
                label31.Visible = true;
                textBox22.Visible = true;
                label32.Visible = false;
                textBox23.Visible = false;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            linkLabel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WIA.CommonDialog CD = new
                  WIA.CommonDialog();
            Device Dev = null;
            try
            {
                Dev = CD.ShowSelectDevice(WiaDeviceType.ScannerDeviceType);
            }
            catch
            {
                MessageBox.Show("Ошибка!");
                return;
            }
            Item scanner = Dev.Items[1];

            ImageFile
            ImageFileImg = (ImageFile)scanner.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
            if (ImageFileImg != null)
            {
                ImageFile Img = (ImageFile)ImageFileImg;
                string FilePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы\file001.jpg";
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                Img.SaveFile(FilePath);
            }
            label34.Text = "1";
            MessageBox.Show("Готово!");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Width = 1343;
            panel2.Visible = true;
            label28.Visible = true;

            

            LinkLabelLinkClickedEventArgs ex = new LinkLabelLinkClickedEventArgs(linkLabel8.Links[0]);
            linkLabel8_LinkClicked(sender, ex);

     //Сформировать номер заявка

            int n_z = 1;
            Form4.con.Open();
            SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Zagorod_Nedvig_Zayav ORDER BY ID DESC", Form4.con);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                if (reader[0] + "" != "")
                {
                    n_z = Int32.Parse(reader[0] + "") + 1;
                }
            }
            textBox9.Text = n_z.ToString();
            reader.Close();
            Form4.con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Проверка на введенные поля
            //Покупатель
            if (textBox1.Text == "")
            {
                MessageBox.Show("Необходимо ввести ФИО покупателя");
                return;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Необходимо ввести Адрес регистрации покупателя");
                return;
            }
            if (textBox50.Text == "")
            {
                MessageBox.Show("Необходимо ввести Контактный телефон покупателя");
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Необходимо ввести Серию паспорта покупателя");
                return;
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Необходимо ввести Номер паспорта покупателя");
                return;
            }
            if (textBox8.Text == "")
            {
                MessageBox.Show("Необходимо ввести Код подразделения паспорта покупателя");
                return;
            }
            if (textBox10.Text == "")
            {
                MessageBox.Show("Необходимо ввести Кем выдан паспорт покупателя");
                return;
            }
            //Объект
            if (radioButton3.Checked)
            {
                //ок
            }
            else if (radioButton2.Checked)
            {
                //ок
            }
            else
            {
                MessageBox.Show("Необходимо выбрать объект!");
                return;
            }
            if (textBox14.Text == "")
            {
                MessageBox.Show("Необходимо ввести Кадастровый(условный) номер объекта недвижимого имущества");
                return;
            }
            if (textBox16.Text == "")
            {
                MessageBox.Show("Необходимо ввести Площадь объекта недвижимого имущества");
                return;
            }
            if (textBox15.Text == "")
            {
                MessageBox.Show("Необходимо ввести Адрес объекта недвижимого имущества");
                return;
            }
            if (radioButton3.Checked)
            {
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Необходимо ввести Кадастровый(условный) номер ЗУ объекта недвижимого имущества");
                    return;
                }
                if (textBox22.Text == "")
                {
                    MessageBox.Show("Необходимо ввести Кол-во этажей объекта недвижимого имущества");
                    return;
                }

            }
            if (radioButton2.Checked)
            {
                if (textBox23.Text == "")
                {
                    MessageBox.Show("Необходимо ввести Назначение земель объекта недвижимого имущества");
                    return;
                }
            }
            if (textBox11.Text == "")
            {
                MessageBox.Show("Необходимо ввести Наименование документа основания объекта недвижимого имущества");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Необходимо ввести Серию документа основания объекта недвижимого имущества");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Необходимо ввести Номер документа основания объекта недвижимого имущества");
                return;
            }
            if (textBox13.Text == "")
            {
                MessageBox.Show("Необходимо ввести Кем заверен документ основания объекта недвижимого имущества");
                return;
            }
            if (textBox20.Text == "")
            {
                MessageBox.Show("Необходимо ввести Стоимость объекта недвижимого имущества");
                return;
            }
            if (textBox24.Text == "")
            {
                MessageBox.Show("Необходимо ввести № Регистрационной записи из документа основания недвижимого имущества");
                return;
            }


            Form4.con.Open();
      // Добавление заявки
            SqlCommand com = new SqlCommand("insert into Zagorod_Nedvig_Zayav(id,id_pokupat,id_object,Date_zayv,Otpravl_Na_Ispolnen)" +
                " values('" + textBox9.Text + "','" + textBox9.Text + "','" + textBox9.Text + "','" + DateTime.Now.ToString() + "','1')", Form4.con);
            com.ExecuteNonQuery();
   // Добавление покупателя
             com = new SqlCommand("insert into Zagorod_Nedvig_Pokupat(id,FIO_pokupat,DB_pokupat,Adres_pokupat,Contact_phone,Seria_Pas_pokupat,Nomer_Pas_pokupat,Kod_Pod_pokupat,Date_Pas_vid,Org_Pas_pokupat,id_zayavl) " +
               "values('" + textBox9.Text + "','" + textBox1.Text + "','" + dateTimePicker4.Value.ToString() + "','" + textBox5.Text + "','" + textBox50.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," +
               "'" + textBox8.Text + "','" + dateTimePicker3.Value.ToString() + "','" + textBox10.Text + "','" + textBox9.Text + "')", Form4.con);
            com.ExecuteNonQuery();
     // Добавление объекта
            string n_object = "";

            if (radioButton2.Checked)
            {
                n_object = "ЗУ";
            }
            else if (radioButton3.Checked)
            {
                n_object = "Дом";
            }

            com = new SqlCommand("insert into Zagorod_Nedvig_Object" +
                "(id,Naimenovanie,K_N,K_N_ZU,Ploshad_KM,Adres,Document_osnov_Naimenovanie,Seria_document,Number_document,Date_document,Org_vid_document,Stoimost,Kol_vo_floor,Naznach_zemel,N_reg_z,id_zayavl) " +
                "values('" + textBox9.Text + "','" + n_object + "','" + textBox14.Text + "','" + textBox4.Text + "','" + textBox16.Text + "','" + textBox15.Text + "'," +
                "'" + textBox11.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker2.Value.ToString() + "','" + textBox13.Text + "','" + textBox20.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + textBox9.Text + "')", Form4.con);
            com.ExecuteNonQuery();

            
  


     //Сформировать заявку у документов

            com = new SqlCommand("Update Zagorod_Nedvig_Documents set id_zayavl='"+textBox9.Text+"' where id_zayavl is null", Form4.con);
            com.ExecuteNonQuery();

            //Чистка полей
            textBox9.Clear();
            textBox12.Clear();
            textBox14.Clear();
            textBox16.Clear();
            textBox15.Clear();
            textBox4.Clear();
            textBox11.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox21.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox50.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox13.Clear();
            textBox20.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            richTextBox1.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker4.Text = DateTime.Now.ToString("yyyy-MM-dd");


     //Обновление Заявок

    //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv " +
                "from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id " +
                "left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id " +
                "where Otpravl_Na_Ispolnen is Not null", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";
            //Вывод в DataGrid1
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Otpravl_Na_Ispolnen," +
                "Ispolneno,Otpravl_Na_Soglosovanie,Soglasovano,Otpravl_Na_Korrect,otkaz " +
                "from Zagorod_Nedvig_Zayav " +
                "left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id" +
                " left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id", Form4.con);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Отправлено на исполнение";
            dataGridView1.Columns[6].HeaderText = "Исполнено";
            dataGridView1.Columns[7].HeaderText = "Отправлено на согласование";
            dataGridView1.Columns[8].HeaderText = "Согласовано";
            dataGridView1.Columns[9].HeaderText = "Отправлено на корректировку";
            dataGridView1.Columns[10].HeaderText = "Отказ";
            Form4.con.Close();
            MessageBox.Show("Заявка отправлена на Исполнение!");
            this.Width = 588;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com;
            Form4.con.Open();

           
     // Добавление Документов
            if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length > 0)
            {
                com = new SqlCommand("insert into Zagorod_Nedvig_Documents(Naimenovanie,Seria,Nomer,Date_D,Avtor,Dop_info,Scan) " +
                "select '" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "'," +
                "'" + dateTimePicker1.Value.ToString() + "','" + textBox21.Text + "','" + richTextBox1.Text + "',BulkColumn from OpenRowSet (BULK N'"+ Path.GetDirectoryName(Application.ExecutablePath) +@"\Сканы\file001.jpg"+"', SINGLE_BLOB) as Файл", Form4.con);
                com.ExecuteNonQuery();
            }
            else
            {
                if (textBox12.Text == "")
                {
                    DialogResult dialogResult = MessageBox.Show("Продолжить без приложения скан-копии документа?", "Оповещение", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        com = new SqlCommand("insert into Zagorod_Nedvig_Documents(Naimenovanie,Seria,Nomer,Date_D,Avtor,Dop_info) " +
                  "select '" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "'," +
                  "'" + dateTimePicker1.Value.ToString() + "','" + textBox21.Text + "','" + richTextBox1.Text + "'", Form4.con);
                        com.ExecuteNonQuery();

                    }
                    else
                    {
                        Form4.con.Close();
                        return;

                    }
                }
                
            }
            if (textBox12.Text != "")
            {
       //В случае корректировки внесенных данных
                if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length > 0)
                {
                    com = new SqlCommand("Update Zagorod_Nedvig_Documents set id_zayavl='" + textBox9.Text + "',Naimenovanie='" + textBox17.Text + "',Seria='" + textBox18.Text + "',Nomer='" + textBox19.Text + "'," +
                   "Date_D='" + dateTimePicker1.Value.ToString() + "',Avtor='" + textBox21.Text + "',Dop_info='" + richTextBox1.Text + "',Scan=BulkColumn from OpenRowSet (BULK N '"+Path.GetDirectoryName(Application.ExecutablePath) +@"\Сканы\file001.jpg"+"', SINGLE_BLOB) as Файл where id='" + textBox12.Text + "'", Form4.con);
                    com.ExecuteNonQuery();
                }
                else
                {
                    com = new SqlCommand("Update Zagorod_Nedvig_Documents set Naimenovanie='" + textBox17.Text + "',Seria='" + textBox18.Text + "',Nomer='" + textBox19.Text + "'," +
                  "Date_D='" + dateTimePicker1.Value.ToString() + "',Avtor='" + textBox21.Text + "',Dop_info='" + richTextBox1.Text + "' where id='" + textBox12.Text + "'", Form4.con);
                    com.ExecuteNonQuery();
                }
            }
       //Обновление списка

            com = new SqlCommand("SELECT Naimenovanie from Zagorod_Nedvig_Documents where id_zayavl is null", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader.Read())
            {
                this.comboBox1.Items.Add(reader[0].ToString());

            }
            reader.Close();
            Form4.con.Close();
            //Чистка полей
            textBox12.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox21.Clear();
            richTextBox1.Clear();
            comboBox1.Text = "";
            label34.Text = "0";

     //Удаление файлов из папки

            if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length == 0)
            {
                return;
            }
            else
            {
                string file = Path.GetDirectoryName(Application.ExecutablePath)+@"\Сканы\file001.jpg";
                File.Delete(file);
            }

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    //Вывод обширной информации о документе 
            Form4.con.Open();
            SqlCommand com = new SqlCommand("SELECT id,Naimenovanie,Seria,Nomer,Date_D,Avtor,Dop_info,Scan " +
                "from Zagorod_Nedvig_Documents where id_zayavl is null and Naimenovanie='" + comboBox1.Text + "'", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox12.Text = reader[0].ToString();
                textBox17.Text = reader[1].ToString();
                textBox18.Text = reader[2].ToString();
                textBox19.Text = reader[3].ToString();
                dateTimePicker1.Text = reader[4].ToString();
                textBox21.Text = reader[5].ToString();
                richTextBox1.Text = reader[6].ToString();

                if (reader[7].ToString() != "")
                {
                    label34.Text = "1";
                }
                else {
                    label34.Text = "0";
                }
                
            }
            reader.Close();
            Form4.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
     //Удаление выбранных документов
            Form4.con.Open();
            SqlCommand com = new SqlCommand("delete from Zagorod_Nedvig_Documents where id='" + textBox12.Text + "'", Form4.con);
            com.ExecuteNonQuery();
     //Чистка полей
            textBox12.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox21.Clear();
            richTextBox1.Clear();
            comboBox1.Text = "";
            label34.Text = "0";
     //Обновление списка 
            com = new SqlCommand("SELECT Naimenovanie from Zagorod_Nedvig_Documents where id_zayavl is null", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            comboBox1.Items.Clear();
            while (reader.Read())
            {
                this.comboBox1.Items.Add(reader[0].ToString());

            }
            reader.Close();
            Form4.con.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 3)
            {
                textBox8.Text = textBox8.Text + "-";
                textBox8.SelectionStart = 4;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (panel2.Visible == true)
            {
      //Удалить документы при отмени заявки
                Form4.con.Open();
                SqlCommand com = new SqlCommand("Delete from Zagorod_Nedvig_Documents where id_zayavl=null", Form4.con);
                com.ExecuteNonQuery();
                Form4.con.Close();
                DialogResult dialogResult = MessageBox.Show("Отменить формирование новой заявки?", "Оповещение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
     //Удаление файлов из папки

                    if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length > 0)
                    {
              
                        string file = Path.GetDirectoryName(Application.ExecutablePath)+@"\Сканы\file001.jpg";
                        File.Delete(file);
                    }
                    Form f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }

            }
            else
            {
                Form f4 = new Form4();
                f4.Show();
                this.Hide();
            }
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (panel2.Visible == true)
            {
                DialogResult dialogResult = MessageBox.Show("Отменить формирование новой заявки?", "Оповещение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
     //Удалить документы при отмени заявки
                    Form4.con.Open();
                    SqlCommand com = new SqlCommand("Delete from Zagorod_Nedvig_Documents where id_zayavl=null", Form4.con);
                    com.ExecuteNonQuery();
                    Form4.con.Close();
     //Удаление файлов из папки

                    if (System.IO.Directory.GetDirectories(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length + System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + @"\Сканы").Length > 0)
                    {   
                        string file = Path.GetDirectoryName(Application.ExecutablePath)+ @"\Сканы\file001.jpg";
                        File.Delete(file);
                    }
                    Application.Exit();
                }

            }
            else
            {
                Application.Exit();
            }
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
  //Вывод в datagrid2
            SqlDataAdapter da = new SqlDataAdapter("select id,FIO_pokupat,DB_pokupat,Adres_pokupat,Contact_phone,Seria_Pas_pokupat,Nomer_Pas_pokupat,Kod_Pod_pokupat,Date_Pas_vid,Org_Pas_pokupat " +
                "from Zagorod_Nedvig_Pokupat " +
                "where FIO_pokupat='" + textBox1.Text + "' or DB_pokupat='" + dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' or Adres_pokupat='" + textBox5.Text + "' " +
                "or Contact_phone='" + textBox50.Text + "' or Seria_Pas_pokupat='" + textBox6.Text + "' or Nomer_Pas_pokupat='" + textBox7.Text + "' or Kod_Pod_pokupat='" + textBox8.Text + "'" +
                "or Date_Pas_vid='" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "' or  Org_Pas_pokupat='" + textBox10.Text + "'", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Pokupat");
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].HeaderText = "id";
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText = "ФИО";
            dataGridView2.Columns[2].HeaderText = "Дата рождения";
            dataGridView2.Columns[3].HeaderText = "Адрес регистрации";
            dataGridView2.Columns[4].HeaderText = "Телефон";
            dataGridView2.Columns[5].HeaderText = "Серия паспорта";
            dataGridView2.Columns[6].HeaderText = "Номер паспорта";
            dataGridView2.Columns[7].HeaderText = "Код подразделения";
            dataGridView2.Columns[8].HeaderText = "Дата выдачи паспорта";
            dataGridView2.Columns[9].HeaderText = "Кем выдан паспорт";
            if (dataGridView2.RowCount > 1)
            {
                dataGridView2.Visible = true;
                linkLabel6.Visible = true;
            }


        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
     //Определить № заявки выделенной строки 
            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

            string id = Convert.ToString(selectedRow.Cells[0].Value);

     // вывести из базы покупателя
            Form4.con.Open();
    //Покупатель
            SqlCommand com = new SqlCommand("Select FIO_pokupat,DB_pokupat,Adres_pokupat,Contact_phone,Seria_Pas_pokupat,Nomer_Pas_pokupat,Kod_Pod_pokupat,Date_Pas_vid,Org_Pas_pokupat " +
                "from Zagorod_Nedvig_Pokupat where id='" + id + "'", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
                dateTimePicker4.Text = reader[1].ToString();
                textBox5.Text = reader[2].ToString();
                textBox50.Text = reader[3].ToString();
                textBox6.Text = reader[4].ToString();
                textBox7.Text = reader[5].ToString();
                textBox8.Text = reader[6].ToString();
                dateTimePicker3.Text = reader[7].ToString();
                textBox10.Text = reader[8].ToString();
            }
            reader.Close();
            Form4.con.Close();
            dataGridView2.Visible = false;
            linkLabel6.Visible = false;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView2.Visible = false;
            linkLabel6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label34.Text == "0")
            {
                return;
            }
            else
                {

                this.Width = 1336;
                this.Height = 825;

                if (textBox12.Text != "")
            {

                    
                    Form4.con.Open();
                    SqlCommand com = new SqlCommand("Select Scan from Zagorod_Nedvig_Documents where id='" + textBox12.Text + "'", Form4.con);
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        panel1.Visible = true;
                        button7.Visible = true;
                        byte[] picbyte = reader[0] as byte[] ?? null;
                        if (picbyte != null)
                        {
                            MemoryStream mstream = new MemoryStream(picbyte);
                            pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                            {
                                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                            }
                        }


                    }
                    reader.Close();
                    Form4.con.Close();
                }
                if (textBox12.Text == "")
                {
                    panel1.Visible = true;
                    button7.Visible = true;
                    using (Stream stream = File.OpenRead(Path.GetDirectoryName(Application.ExecutablePath)+@"\Сканы\file001.jpg"))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                    }
                  


                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {


            this.Width = 1347;
            this.Height = 471;
            panel1.Visible = false;
            button7.Visible = false;
            
        }

    
    }
    }

