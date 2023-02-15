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
using System.Configuration;

namespace esDnevnik_Mat
{
    public partial class Form1 : Form
    {
        class Konekcija
        {
            static public SqlConnection Connect()
            {
                string CS = "";
                CS = ConfigurationManager.ConnectionStrings["home"].ConnectionString;           
                SqlConnection conn = new SqlConnection(CS);
                return conn;
            }
            static public string Veza()
            {
                return ConfigurationManager.ConnectionStrings["home"].ConnectionString;
            }
            static public DataTable Unos(string Komanda)
            {
                DataTable Tabela = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(Komanda, Konekcija.Connect());
                adapter.Fill(Tabela);
                return Tabela;
            }


        }
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            textBox1.Enabled = false;
        }
        string prikaz = "";
        public void Odeljenje(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top " + id + " * from odeljenje except select top " + (id - 1) + " * from odeljenje");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString();
            DataTable b = new DataTable();
            b = Konekcija.Unos("select naziv from smer where id=" + a.Rows[0][3]);
            comboBox2.Text = b.Rows[0][0].ToString();
            b.Clear();
            b = Konekcija.Unos("select ime,prezime from osoba where id=" + a.Rows[0][4]);
            comboBox3.Text = b.Rows[0][0].ToString() + " " + b.Rows[0][1].ToString();
            b.Clear();
            b = Konekcija.Unos("select naziv from skolska_godina where id=" + a.Rows[0][5]);
            comboBox4.Text = b.Rows[0][0].ToString();
        }
        public void Osoba(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top "+id+" * from osoba except select top " +(id-1)+" * from osoba");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString();
            textBox4.Text = a.Rows[0][3].ToString();
            textBox5.Text = a.Rows[0][4].ToString();
            textBox6.Text = a.Rows[0][5].ToString();
            textBox7.Text = a.Rows[0][6].ToString();
            textBox8.Text = a.Rows[0][7].ToString();
        }

        public void Skolska_godina(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top " + id + " * from skolska_godina except select top " + (id - 1) + " * from skolska_godina");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }
        int osobaindex = 1, odeljenjeindex = 1, skolska_godinaIndex = 1;
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Odeljenje")
            {
                Odeljenje(1);
                odeljenjeindex = 1;
            }
            if (prikaz == "Osoba")
            {
                Osoba(1);
                osobaindex = 1;
            }
            if (prikaz == "Skolska_godina")
            {
                Skolska_godina(1);
                skolska_godinaIndex = 1;
            }
            button7.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Odeljenje")
            {
                odeljenjeindex++;
                Odeljenje(odeljenjeindex);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select count(id) from odeljenje");
                if (odeljenjeindex == (int)a.Rows[0][0]) { button4.Enabled = false; button5.Enabled = false; }
            }
            if (prikaz == "Osoba")
            {
                osobaindex++;
                Osoba(osobaindex);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select count(id) from osoba");
                if (osobaindex == (int)a.Rows[0][0]) { button4.Enabled = false; button5.Enabled = false; }
            }
            if (prikaz == "Skolska_godina")
            {
                skolska_godinaIndex++;
                Skolska_godina(skolska_godinaIndex);
                DataTable a = Konekcija.Unos("select count(id) from skolska_godina");
                if (skolska_godinaIndex == (int)a.Rows[0][0]) { button4.Enabled = false; button5.Enabled = false; }
            }
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Odeljenje")
            {
                odeljenjeindex--;
                Odeljenje(odeljenjeindex);
                if (odeljenjeindex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            if (prikaz == "Osoba")
            {
                osobaindex--;
                Osoba(osobaindex);
                if (osobaindex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            if (prikaz == "Skolska_godina")
            {
                skolska_godinaIndex--;
                Skolska_godina(skolska_godinaIndex);
                if (skolska_godinaIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            button4.Enabled = true;
            button5.Enabled = true;
        }
        public void BrisiOsoba(int id)
        {
            SqlCommand com = new SqlCommand();
            SqlConnection c = new SqlConnection(Konekcija.Veza());
            com.Connection = c;
            com.CommandText = "delete * from osoba where id="+id;
            int n = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Osoba")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from osoba where id=(select top " + osobaindex + " id from osoba except select top " + (osobaindex - 1) + " id from osoba)";
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from osoba");
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    if (a.Rows.Count == 0)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count == 1)
                    {
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    Osoba(1);
                    osobaindex = 1;
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati osobu");

                }
            }
            if (prikaz == "Odeljenje")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from odeljenje where id=(select top " + odeljenjeindex + " id from odeljenje except select top " + (odeljenjeindex - 1) + " id from odeljenje)";
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from odeljenje");
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    if (a.Rows.Count == 0)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count == 1)
                    {
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    odeljenjeindex = 1;
                    Odeljenje(1);
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati odeljenje");
                }
            }
            if (prikaz == "Skolska_godina")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from skolska_godina where id=(select top " + skolska_godinaIndex + " id from odeljenje except select top " + (skolska_godinaIndex - 1) + " id from odeljenje)";
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from skolska_godina");
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    if (a.Rows.Count == 0)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count == 1)
                    {
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    skolska_godinaIndex = 1;
                    Skolska_godina(1);
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati skolsku godinu");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Osoba")
            {
                int n =Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from osoba where id="+n);
                if (a.Rows.Count == 0)
                {
                    errorProvider1.SetError(button1, "Ne postoji osoba sa takvim ID-jem");
                }
                else
                {
                    try
                    {
                        SqlCommand com = new SqlCommand();
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        com.Connection = c;
                        com.CommandText = "update osoba set ime='" + textBox2.Text+"'" + " where id=" + n +
                            "update osoba set prezime='" + textBox3.Text +"'" + " where id=" + n +
                            "update osoba set adresa='" + textBox4.Text +"'" + " where id=" + n +
                            "update osoba set jmbg='" + textBox5.Text+"'" + " where id=" + n +
                            "update osoba set email='" + textBox6.Text +"'" + " where id=" + n +
                            "update osoba set pass='" + textBox7.Text +"'" + " where id=" + n +
                            "update osoba set uloga=" + Convert.ToInt32(textBox8.Text) + " where id=" + n;
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    catch
                    {
                        errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Odeljenje")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from odeljenje where id=" + n);
                if (a.Rows.Count == 0)
                {
                    errorProvider1.SetError(button1, "Ne postoji odeljenje sa takvim ID-jem");
                }
                else
                {
                    try
                    {
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        int smer = 1, razredni = 1, skolska = 1;
                        a = new DataTable();
                        a = Konekcija.Unos("select id from smer where naziv='"+comboBox2.Text+"'");
                        smer = (int)a.Rows[0][0];
                        string[] b = comboBox3.Text.Split(' ');
                        a = new DataTable();
                        a = Konekcija.Unos("select id from osoba where ime='" + b[0]+"'" +" and prezime='" + b[1]+"'");
                        razredni = (int)a.Rows[0][0];
                        a = new DataTable();
                        a = Konekcija.Unos("select id from skolska_godina where naziv='"+comboBox4.Text+"'");
                        skolska = (int)a.Rows[0][0];
                        SqlCommand com = new SqlCommand();
                        com.Connection = c;
                        com.CommandText = "update odeljenje set razred=" + Convert.ToInt32(textBox2.Text) + " where id=" + n +
                            "update odeljenje set indeks=" + Convert.ToInt32(textBox3.Text) + " where id=" + n +
                            "update odeljenje set smer_id=" + smer + " where id=" + n +
                            "update odeljenje set razredni_id=" + razredni + " where id=" + n +
                            "update odeljenje set godina_id=" + skolska + " where id=" + n;
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    catch
                    {
                        errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Osoba")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from osoba where jmbg='" + textBox5.Text+"'");
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button2,"JMBG vec postoji");
                }
                else
                {
                    try
                    {
                        SqlCommand com = new SqlCommand();
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        com.Connection = c;
                        com.CommandText = "insert osoba values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" +textBox5.Text+"','"+ textBox6.Text + "','"+textBox7.Text+"',"+Convert.ToInt32(textBox8.Text) +")";
                        com.ExecuteNonQuery();
                        c.Close();
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        a.Clear();
                        a = Konekcija.Unos("select * from osoba");
                        osobaindex = (int)a.Rows.Count;
                        Osoba(osobaindex);
                    }
                    catch
                    {
                        errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Odeljenje")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select id from skolska_godina where naziv='" + comboBox4.Text + "'");
                int god = (int)a.Rows[0][0];
                a.Clear();
                a = Konekcija.Unos("select * from odeljenje where razred='" + textBox2.Text + "' and indeks='" + textBox3.Text + "' and godina_id=" + god);
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button2, "Odeljenje vec postoji");
                }
                else
                {
                    try
                    {
                        SqlCommand com = new SqlCommand();
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        int smer = 1, razredni = 1, odeljenje = 1;
                        a = new DataTable();
                        a = Konekcija.Unos("select id from smer where naziv='" + comboBox2.Text + "'");
                        smer = (int)a.Rows[0][0];
                        string[] b = comboBox3.Text.Split(' ');
                        a = new DataTable();
                        a = Konekcija.Unos("select id from osoba where ime='" + b[0] + "'" + " and prezime='" + b[1] + "'");
                        razredni = (int)a.Rows[0][0];
                        a = new DataTable();
                        a = Konekcija.Unos("select id from skolska_godina where naziv='" + comboBox4.Text + "'");
                        c.Open();
                        com.Connection = c;
                        com.CommandText = "insert into odeljenje values(" + Convert.ToInt32(textBox2.Text) + ",'" + textBox3.Text + "'," + smer + "," + razredni + "," + odeljenje + ")";
                        com.ExecuteNonQuery();
                        c.Close();
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        a = new DataTable();
                        a = Konekcija.Unos("select * from odeljenje");
                        odeljenjeindex = (int)a.Rows.Count;
                        Odeljenje(odeljenjeindex);
                    }
                    catch
                    {
                        errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Skolska_godina")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from skolska_godina where id="+int.Parse(textBox1.Text));
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button2, "Odeljenje vec postoji");
                }
                else
                {
                    try
                    {
                        SqlCommand com = new SqlCommand();
                        SqlConnection c = new SqlConnection(Konekcija.Veza());                     
                        c.Open();
                        com.Connection = c;
                        com.CommandText = "insert into skolska_godina values('" + textBox2.Text +"')";
                        com.ExecuteNonQuery();
                        c.Close();
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        a = new DataTable();
                        a = Konekcija.Unos("select * from skolska_godina");
                        skolska_godinaIndex = (int)a.Rows.Count;
                        Skolska_godina(skolska_godinaIndex);
                    }
                    catch
                    {
                        errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                    }
                }
            }
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prikaz = "Osoba";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from osoba")
;            if (a.Rows.Count>=1) {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                label1.Text = "ID";
                label2.Text = "Ime";
                label3.Text = "Prezime";
                label7.Text = "Adresa";
                label8.Text = "JMBG";
                label9.Text = "E-mail";
                label10.Text = "Lozinka";
                label11.Text = "Uloga";
                Osoba(1);
            }
            if (a.Rows.Count==1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema osoba u bazi");
            }
        }

        private void odeljenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prikaz = "Odeljenje";
            DataTable b = new DataTable();
            b = Konekcija.Unos("Select * from odeljenje");
            if (b.Rows.Count>=1) {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                DataTable a = new DataTable();
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label8.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                label1.Text = "ID";
                label2.Text = "Razred";
                label3.Text = "Indeks";
                label4.Text = "Smer";
                label5.Text = "Razredni";
                label6.Text = "Godina";
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox2.Items.Add("Informaticki");
                comboBox2.Items.Add("Prirodni");
                comboBox2.Items.Add("Drustveni");
                DataTable c = new DataTable();
                c = Konekcija.Unos("Select naziv from skolska_godina");
                for (int i = 0; i < c.Rows.Count; i++) comboBox4.Items.Add(c.Rows[i][0]);
                a = Konekcija.Unos("select ime,prezime from osoba where uloga=2");
                for (int i = 0; i < a.Rows.Count; i++) comboBox3.Items.Add(a.Rows[i][0] + " " + a.Rows[i][1]);
                Odeljenje(1);
            }
            if (b.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (b.Rows.Count == 0)
            {
                MessageBox.Show("Nema odeljenja u bazi");
            }
        }

        private void skolskaGodinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prikaz = "Skolska godina";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from skolska_godina"); 
            if (a.Rows.Count >= 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label1.Text = "ID";
                label2.Text = "Naziv";
                Skolska_godina(1);
            }
            if (a.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema odeljenja u bazi");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Odeljenje")
            {
                DataTable c= new DataTable();
                c = Konekcija.Unos("select count(id) from odeljenje");
                Odeljenje((int)c.Rows[0][0]);
                odeljenjeindex = (int)c.Rows[0][0];
            }
            if (prikaz == "Osoba")
            {
                DataTable x= new DataTable();
                x = Konekcija.Unos("select count(id) from osoba");
                Osoba((int)x.Rows[0][0]);
                osobaindex = (int)x.Rows[0][0];
            }
            if (prikaz == "Skolska_godina")
            {
                DataTable x = new DataTable();
                x = Konekcija.Unos("select count(id) from skolska_godina");
                Skolska_godina((int)x.Rows[0][0]);
                skolska_godinaIndex = (int)x.Rows[0][0];
            }
            button5.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
        }
    }
}
