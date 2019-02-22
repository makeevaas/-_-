using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            panel1.Visible = false;
            this.Width = 578;
            this.Height = 743;
  //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Soglosovanie is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";
   //Вывод в datagrid4
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Korrect is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.Columns[0].HeaderText = "Номер заявки";
            dataGridView4.Columns[1].HeaderText = "Покупатель";
            dataGridView4.Columns[2].HeaderText = "Объект";
            dataGridView4.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView4.Columns[4].HeaderText = "Дата заявки";
            dataGridView4.Columns[5].HeaderText = "Причина необходимости корректировки";
  //Вывод в datagrid2
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Soglasovano is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].HeaderText = "Номер заявки";
            dataGridView2.Columns[1].HeaderText = "Покупатель";
            dataGridView2.Columns[2].HeaderText = "Объект";
            dataGridView2.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView2.Columns[4].HeaderText = "Дата заявки";
   //Вывод в datagrid1
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otkaz is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Причина отказа";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4.con.Open();
   //Обновить покупателя
            SqlCommand com = new SqlCommand("Update Zagorod_Nedvig_Pokupat set FIO_pokupat='" + textBox1.Text + "',DB_pokupat='" + dateTimePicker8.Value.ToString() + "'," +
                "Adres_pokupat='" + textBox5.Text + "',Contact_phone='" + textBox4.Text + "',Seria_Pas_pokupat='" + textBox6.Text + "'," +
                "Nomer_Pas_pokupat='" + textBox7.Text + "',Kod_Pod_pokupat='" + textBox8.Text + "',Date_Pas_vid='" + dateTimePicker1.Value.ToString() + "',Org_Pas_pokupat='" + textBox9.Text + "' where id='" + textBox2.Text + "'", Form4.con);
            com.ExecuteNonQuery();
   //Обновить объект
            com = new SqlCommand("Update Zagorod_Nedvig_Object set Naimenovanie='" + textBox10.Text + "',K_N='" + textBox11.Text + "',K_N_ZU='"+textBox3.Text+"',Ploshad_KM='" + textBox12.Text + "',Adres='" + textBox14.Text + "'," +
                "Document_osnov_Naimenovanie='" + textBox15.Text + "',Seria_document='" + textBox21.Text + "',Number_document='" + textBox22.Text + "',Date_document='" + dateTimePicker2.Value.ToString() + "'," +
                "Org_vid_document='" + textBox16.Text + "',Stoimost='" + textBox13.Text + "',Kol_vo_floor='"+textBox23.Text+"',Naznach_zemel='"+textBox24.Text+ "',N_reg_z='"+textBox25.Text+"' where id='" + textBox2.Text + "'", Form4.con);
            com.ExecuteNonQuery();
   //Обновить заявление
            com = new SqlCommand("Update Zagorod_Nedvig_Zayav set Otpravl_Na_Ispolnen=null,Otpravl_Na_Korrect=null,Prich_Korrect_or_Otkaz=null,Ispolneno=null,Otpravl_Na_Soglosovanie=null,Soglasovano=1 where id='" + textBox2.Text + "'", Form4.con);
            com.ExecuteNonQuery();

    //Cформировать договор
            com = new SqlCommand("Select Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Pokupat.DB_pokupat,Zagorod_Nedvig_Pokupat.Contact_phone,Zagorod_Nedvig_Pokupat.Seria_Pas_pokupat,Zagorod_Nedvig_Pokupat.Nomer_Pas_pokupat," +
                "Zagorod_Nedvig_Pokupat.Org_Pas_pokupat, Zagorod_Nedvig_Pokupat.Date_Pas_vid, Zagorod_Nedvig_Pokupat.Kod_Pod_pokupat,Zagorod_Nedvig_Pokupat.Adres_pokupat, Zagorod_Nedvig_Object.Adres, Zagorod_Nedvig_Object.Ploshad_KM, Zagorod_Nedvig_Object.Kol_vo_floor," +
                "Zagorod_Nedvig_Object.Naznach_zemel,Zagorod_Nedvig_Object.K_N, Zagorod_Nedvig_Object.Date_document, Zagorod_Nedvig_Object.N_reg_z, Zagorod_Nedvig_Object.Stoimost, Zagorod_Nedvig_Pokupat.FIO_pokupat " +
                "from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Pokupat.id = Zagorod_Nedvig_Zayav.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id = Zagorod_Nedvig_Object.id where Zagorod_Nedvig_Zayav.id = '"+textBox2.Text+"'", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
       // Создаём объект документа
               Word.Document doc = null;
                try
                {
      // Создаём объект приложения
                   Word.Application app = new Word.Application();
                    // Путь до шаблона документа
                    string source;
                    if (reader[0].ToString() == "ЗУ")
                    {
                         source = Path.GetDirectoryName(Application.ExecutablePath)+@"\ДОГОВОР К_П_ЗУ.docx";
                    }
                    else
                    {
                         source = Path.GetDirectoryName(Application.ExecutablePath)+@"\ДОГОВОР К_П_ЖД.docx";
                    }
      // Открываем
                       doc = app.Documents.Open(source);
                       doc.Activate();

                   // Добавляем информацию
                   // wBookmarks содержит все закладки
                      Word.Bookmarks wBookmarks = doc.Bookmarks;
                      Word.Range wRange;
                      int i = 0;
                    string[] data;
                    if (reader[0].ToString() == "ЗУ")
                    {
                        data = new string[17] { reader[1].ToString(), reader[2].ToString().Substring(0, 10), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString().Substring(0, 10), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString().Substring(0, 10), reader[16].ToString(), reader[17].ToString(), reader[18].ToString() };
                    }
                    else {
                        data = new string[17] { reader[1].ToString(), reader[2].ToString().Substring(0, 10), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString().Substring(0, 10), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[14].ToString(), reader[15].ToString().Substring(0, 10), reader[16].ToString(), reader[17].ToString(), reader[18].ToString() };
                    }

                        foreach (Word.Bookmark mark in wBookmarks)
                        {

                            wRange = mark.Range;
                            wRange.Text = data[i];
                            i++;
                        }

                    // Закрываем документ
                    doc.SaveAs(@"C:\Users\User\Desktop\Диплом\Договоры\ДОГОВОР_К-П_" + textBox2.Text+".docx");
                        doc.Close();
                        doc = null;
                   }
                    catch (Exception)
                   {
                        // Если произошла ошибка, то
                        // закрываем документ и выводим информацию
                        doc.Close();
                       doc = null;
                        Console.WriteLine("Во время выполнения произошла ошибка!");
                      Console.ReadLine();
                    }
                }
            reader.Close();

        
   //Чистка полей
            textBox1.Clear();       
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox16.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            richTextBox1.Clear();
            dateTimePicker8.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridView3.DataSource = null;
            MessageBox.Show("Согласовано! Договор Купли-Продажи объекта №"+ textBox2.Text+" Сформирован в папке Договоров!");
            textBox2.Clear();
            panel1.Visible = false;
            this.Width = 578;
            this.Height = 743;
            //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N," +
                "Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id " +
                "left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Soglosovanie is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";
     //Вывод в datagrid4
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv," +
                "Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id " +
                "left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Korrect is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.Columns[0].HeaderText = "Номер заявки";
            dataGridView4.Columns[1].HeaderText = "Покупатель";
            dataGridView4.Columns[2].HeaderText = "Объект";
            dataGridView4.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView4.Columns[4].HeaderText = "Дата заявки";
            dataGridView4.Columns[5].HeaderText = "Причина необходимости корректировки";
    //Вывод в datagrid1
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otkaz is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Причина отказа";
     //Вывод в datagrid2
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Soglasovano is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].HeaderText = "Номер заявки";
            dataGridView2.Columns[1].HeaderText = "Покупатель";
            dataGridView2.Columns[2].HeaderText = "Объект";
            dataGridView2.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView2.Columns[4].HeaderText = "Дата заявки";
            Form4.con.Close();
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //Определить № заявки выделенной строки 
            int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];

            textBox2.Text = Convert.ToString(selectedRow.Cells[0].Value);
            if (textBox2.Text == "")
            {
                return;
            }

            panel1.Visible = true;
            this.Width = 1714;
            this.Height = 743;
            // Раскрыть обширный просмотр дела
            Form4.con.Open();
   //Покупатель
            SqlCommand com = new SqlCommand("Select FIO_pokupat,DB_pokupat,Adres_pokupat,Contact_phone,Seria_Pas_pokupat,Nomer_Pas_pokupat,Kod_Pod_pokupat,Date_Pas_vid,Org_Pas_pokupat from Zagorod_Nedvig_Pokupat where id='" + textBox2.Text + "'", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
                dateTimePicker8.Text = reader[1].ToString();
                textBox5.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox6.Text = reader[4].ToString();
                textBox7.Text = reader[5].ToString();
                textBox8.Text = reader[6].ToString();
                dateTimePicker1.Text = reader[7].ToString();
                textBox9.Text = reader[8].ToString();
            }
            reader.Close();
    //Объект
            com = new SqlCommand("select Naimenovanie,K_N,K_N_ZU,Ploshad_KM,Stoimost,Adres,Document_osnov_Naimenovanie,Seria_document,Number_document,Date_document,Org_vid_document,Kol_vo_floor,Naznach_zemel,N_reg_z from Zagorod_Nedvig_Object where id='" + textBox2.Text + "'", Form4.con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (reader[2].ToString() == "")
                {
                    label33.Visible = false;
                    textBox3.Visible = false;
                    label34.Visible = false;
                    textBox23.Visible = false;
                    label35.Visible = true;
                    textBox24.Visible = true;
                    textBox24.Text = reader[12].ToString();
                }
                else
                {
                    label35.Visible = false;
                    textBox24.Visible = false;
                    label34.Visible = true;
                    textBox23.Visible = true;
                    textBox23.Text = reader[11].ToString();
                    label33.Visible = true;
                    textBox3.Visible = true;
                    textBox3.Text = reader[2].ToString();
                }
                textBox10.Text = reader[0].ToString();
                textBox11.Text = reader[1].ToString();
                textBox12.Text = reader[3].ToString();
                textBox13.Text = reader[4].ToString();
                textBox14.Text = reader[5].ToString();
                textBox15.Text = reader[6].ToString();
                textBox21.Text = reader[7].ToString();
                textBox22.Text = reader[8].ToString();
                dateTimePicker2.Text = reader[9].ToString();
                textBox16.Text = reader[10].ToString();
                textBox25.Text = reader[13].ToString();

            }
            reader.Close();
  //Вывод в datagrid3
            SqlDataAdapter da = new SqlDataAdapter("select id,Naimenovanie,Seria,Nomer,Date_D,Avtor,Dop_info from Zagorod_Nedvig_Documents where id_zayavl='" + textBox2.Text + "'", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Documents");
            dataGridView3.DataSource = ds.Tables[0];
            dataGridView3.Columns[0].HeaderText = "id";
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].HeaderText = "Наименование";
            dataGridView3.Columns[2].HeaderText = "Серия";
            dataGridView3.Columns[3].HeaderText = "Номер";
            dataGridView3.Columns[4].HeaderText = "Дата";
            dataGridView3.Columns[5].HeaderText = "Автор";
            dataGridView3.Columns[6].HeaderText = "Доп.информация";

            Form4.con.Close();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Определить id документа выделенной строки 
            int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

            string id = Convert.ToString(selectedRow.Cells[0].Value);
            // Раскрыть обширный просмотр дела
            Form4.con.Open();
            SqlCommand com = new SqlCommand("Select Naimenovanie,Seria,Nomer,Date_D,Avtor,Dop_info,Scan from Zagorod_Nedvig_Documents where id='" + id + "'", Form4.con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox20.Text = reader[0].ToString();
                textBox19.Text = reader[1].ToString();
                textBox18.Text = reader[2].ToString();
                dateTimePicker3.Text = reader[3].ToString();
                textBox17.Text = reader[4].ToString();
                richTextBox1.Text = reader[5].ToString();
                //Сканы
   
                panel3.Visible = true;
                button7.Visible = true;
                byte[] picbyte = reader[6] as byte[] ?? null;
                if (picbyte != null)
                {
                    MemoryStream mstream = new MemoryStream(picbyte);
                    pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(mstream);
                    }
                }
                else
                {

                    panel3.Visible = false;
                    button7.Visible = false;
      
                }
            }
            reader.Close();
            Form4.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label32.Visible = true;
            richTextBox3.Visible = true;
            button6.Visible = true;


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label31.Visible = true;
            richTextBox2.Visible = true;
            button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            label31.Visible = false;
            richTextBox2.Visible = false;
            button5.Visible = false;
            label32.Visible = false;
            richTextBox3.Visible = false;
            button6.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
 //Обновить статус и причину корректировки заявки
            Form4.con.Open();
            SqlCommand com = new SqlCommand("Update Zagorod_Nedvig_Zayav " +
                "set Ispolneno=null, Otpravl_Na_Soglosovanie=null,Otpravl_Na_Korrect=1,Prich_Korrect_or_Otkaz='" + richTextBox3.Text+"' where id='"+textBox2.Text+"'", Form4.con);
            com.ExecuteNonQuery();
            Form4.con.Close();

            panel2.Visible = false;
            label31.Visible = false;
            richTextBox2.Visible = false;
            button5.Visible = false;
            label32.Visible = false;
            richTextBox3.Visible = false;
            button6.Visible = false;
 //Чистка полей
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox24.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox16.Clear();
            textBox23.Clear();
            textBox25.Clear();
            richTextBox1.Clear();
            richTextBox3.Clear();
            dateTimePicker8.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridView3.DataSource = null;
            MessageBox.Show("Заявка отправлена на Корректировку!");
   //Обновить заявки
   //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Soglosovanie is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";
   //Вывод в datagrid4
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Korrect is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.Columns[0].HeaderText = "Номер заявки";
            dataGridView4.Columns[1].HeaderText = "Покупатель";
            dataGridView4.Columns[2].HeaderText = "Объект";
            dataGridView4.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView4.Columns[4].HeaderText = "Дата заявки";
            dataGridView4.Columns[5].HeaderText = "Причина необходимости корректировки";

            panel1.Visible = false;
            this.Width = 578;
            this.Height = 743;
        }

        private void button5_Click(object sender, EventArgs e)
        {
    //Обновить статус и причину отказа заявки
            Form4.con.Open();
            SqlCommand com = new SqlCommand("Update Zagorod_Nedvig_Zayav " +
                "set Ispolneno=null, Otpravl_Na_Soglosovanie=null,Otkaz=1,Prich_Korrect_or_Otkaz='" + richTextBox2.Text + "' where id='" + textBox2.Text + "'", Form4.con);
            com.ExecuteNonQuery();
            Form4.con.Close();

            panel2.Visible = false;
            label31.Visible = false;
            richTextBox2.Visible = false;
            button5.Visible = false;
            label32.Visible = false;
            richTextBox3.Visible = false;
            button6.Visible = false;

 //Чистка полей
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox20.Clear();
            textBox19.Clear();
            textBox18.Clear();
            textBox17.Clear();
            textBox16.Clear();
            textBox25.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            dateTimePicker8.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridView3.DataSource = null;
            MessageBox.Show("Отказано!");
  //Обновить заявки
 //Вывод в datagrid5
            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otpravl_Na_Soglosovanie is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView5.DataSource = ds.Tables[0];
            dataGridView5.Columns[0].HeaderText = "Номер заявки";
            dataGridView5.Columns[1].HeaderText = "Покупатель";
            dataGridView5.Columns[2].HeaderText = "Объект";
            dataGridView5.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView5.Columns[4].HeaderText = "Дата заявки";

 //Вывод в datagrid1
            da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otkaz is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Причина отказа";

            panel1.Visible = false;
            this.Width = 578;
            this.Height = 743;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 3)
            {
                textBox8.Text = textBox8.Text + "-";
                textBox8.SelectionStart = 4;
  
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            button7.Visible = false;
        }

        private void label40_Click(object sender, EventArgs e)
        {
            Form4.con.Open();

            //Удаление отказов
           SqlCommand com = new SqlCommand("delete from Zagorod_Nedvig_Zayav where Otkaz is Not null", Form4.con);
            com.ExecuteNonQuery();

            com = new SqlCommand("delete from Zagorod_Nedvig_Object where id_zayavl is null", Form4.con);

           com.ExecuteNonQuery();

            com = new SqlCommand("delete from Zagorod_Nedvig_Pokupat where id_zayavl is null", Form4.con);

            com.ExecuteNonQuery();

            com = new SqlCommand("delete from Zagorod_Nedvig_Documents where id_zayavl is null", Form4.con);

            com.ExecuteNonQuery();

            //Вывод в datagrid1

            SqlDataAdapter da = new SqlDataAdapter("select Zagorod_Nedvig_Zayav.id,Zagorod_Nedvig_Pokupat.FIO_pokupat,Zagorod_Nedvig_Object.Naimenovanie,Zagorod_Nedvig_Object.K_N,Zagorod_Nedvig_Zayav.Date_zayv,Zagorod_Nedvig_Zayav.Prich_Korrect_or_Otkaz from Zagorod_Nedvig_Zayav left join Zagorod_Nedvig_Pokupat on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Pokupat.id left join Zagorod_Nedvig_Object on Zagorod_Nedvig_Zayav.id=Zagorod_Nedvig_Object.id where Otkaz is Not null order by Zagorod_Nedvig_Zayav.id", Form4.con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zagorod_Nedvig_Zayav");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер заявки";
            dataGridView1.Columns[1].HeaderText = "Покупатель";
            dataGridView1.Columns[2].HeaderText = "Объект";
            dataGridView1.Columns[3].HeaderText = "Кадастровый номер";
            dataGridView1.Columns[4].HeaderText = "Дата заявки";
            dataGridView1.Columns[5].HeaderText = "Причина отказа";
            Form4.con.Close();
        }
    }
  
    
}
