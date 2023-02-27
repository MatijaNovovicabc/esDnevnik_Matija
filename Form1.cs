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
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using System.Linq.Expressions;

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
            label12.Visible = false;
            label13.Visible = false;
            comboBox5.Visible = false;
            comboBox1.Visible = false;
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

        public void Smer(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top " + id + " * from smer except select top " + (id - 1) + " * from smer");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
        }

        public void Predmet(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top " + id + " * from predmet except select top " + (id - 1) + " * from predmet");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString();
        }

        public void Ocena(int id)
        {
            textBox2.Text = Ocene1.Rows[id - 1][3].ToString();
            textBox3.Text = Ocene2.Rows[0][0].ToString();
            comboBox2.Text = Ocene1.Rows[id - 1][0].ToString();
            textBox5.Text = Ocene1.Rows[id - 1][1].ToString();
            textBox6.Text = Ocene1.Rows[id - 1][2].ToString();
        }
        public void Upisnica(int id)
        {
            DataTable a = new DataTable();
            a = Konekcija.Unos("select top " + id +  " Upisnica.id, Osoba.ime + ' ' + Osoba.prezime, Odeljenje.razred,Odeljenje.indeks,Skolska_godina.naziv from upisnica join osoba on Upisnica.osoba_id=Osoba.id join Odeljenje on Upisnica.odeljenje_id=Odeljenje.id join Skolska_godina on Odeljenje.godina_id=Skolska_godina.id except select top " + (id - 1) + " Upisnica.id, Osoba.ime + ' ' + Osoba.prezime, Odeljenje.razred,Odeljenje.indeks,Skolska_godina.naziv from upisnica join osoba on Upisnica.osoba_id=Osoba.id join Odeljenje on Upisnica.odeljenje_id=Odeljenje.id join Skolska_godina on Odeljenje.godina_id=Skolska_godina.id");
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString() + " / " +a.Rows[0][3].ToString() + " / " + a.Rows[0][4].ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }
        int osobaindex = 1, odeljenjeindex = 1, skolska_godinaIndex = 1, smerIndex = 1, predmetIndex = 1, ocenaIndex = 1,upisnicaIndex, odeljenjeID, predmetID;
        DataTable Odeljenja, Predmeti, Ocene1, Ocene2,Ucenici;

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
            if (prikaz == "Smer")
            {
                Smer(1);
                smerIndex = 1;
            }
            if (prikaz == "Predmet")
            {
                Predmet(1);
                predmetIndex = 1;
            }
            if (prikaz == "Ocena")
            {
                Ocena(1);
                ocenaIndex = 1;
            }
            if (prikaz == "Upisnica")
            {
                Upisnica(1);
                upisnicaIndex = 1;
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
                DataTable a,b,c = new DataTable();
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
            if (prikaz == "Smer")
            {
                smerIndex++;
                Smer(smerIndex);
                DataTable a = Konekcija.Unos("select count(id) from smer");
                if (smerIndex == (int)a.Rows[0][0]) { button4.Enabled = false; button5.Enabled = false; }
            }
            if (prikaz == "Predmet")
            {
                predmetIndex++;
                Predmet(predmetIndex);
                DataTable a = Konekcija.Unos("select count(id) from predmet");
                if (predmetIndex == (int)a.Rows[0][0]) { button4.Enabled = false; button5.Enabled = false; }
            }
            if (prikaz == "Ocena")
            {
                ocenaIndex++;
                Ocena(ocenaIndex);
                if (ocenaIndex == Ocene1.Rows.Count) { button4.Enabled = false; button5.Enabled = false; }
            }
            if (prikaz == "Upisnica")
            {
                upisnicaIndex++;
                Upisnica(upisnicaIndex);
                DataTable a = Konekcija.Unos("select count(id) from upisnica");
                if (upisnicaIndex == a.Rows.Count) { button4.Enabled = false; button5.Enabled = false; }
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
            if (prikaz == "Smer")
            {
                smerIndex--;
                Smer(smerIndex);
                if (smerIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            if (prikaz == "Predmet")
            {
                predmetIndex--;
                Predmet(predmetIndex);
                if (predmetIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            if (prikaz == "Ocena")
            {
                ocenaIndex--;
                Ocena(ocenaIndex);
                if (ocenaIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
            }
            if (prikaz == "Upisnica")
            {
                upisnicaIndex--;
                Upisnica(upisnicaIndex);
                if (upisnicaIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
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
                    osobaindex = 1;
                    if (a.Rows.Count == 0)
                    {
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        osobaindex = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";

                    }
                    if (a.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        Osoba(1);
                        osobaindex = 1;
                    }
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
                    odeljenjeindex = 1;
                    if (a.Rows.Count == 0)
                    {
                        odeljenjeindex = 0;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                    }
                    if (a.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        odeljenjeindex = 1;
                        Odeljenje(1);
                    }

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
                    com.CommandText = "delete from skolska_godina where id=(select top " + skolska_godinaIndex + " id from skolska_godina except select top " + (skolska_godinaIndex - 1) + " id from skolska_godina)";
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
                    skolska_godinaIndex = 1;
                    if (a.Rows.Count == 0)
                    {
                        skolska_godinaIndex = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        skolska_godinaIndex = 1;
                        Skolska_godina(1);
                    }
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati skolsku godinu");
                }
            }
            if (prikaz == "Smer")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from smer where id=(select top " + smerIndex + " id from smer except select top " + (smerIndex - 1) + " id from smer)";
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from smer");
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    smerIndex = 1;
                    if (a.Rows.Count == 0)
                    {
                        smerIndex = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        smerIndex = 1;
                        Smer(1);
                    }
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati smer");
                }
            }
            if (prikaz == "Predmet")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from predmet where id=(select top " + predmetIndex + " id from predmet except select top " + (predmetIndex - 1) + " id from predmet)";
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from predmet");
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    predmetIndex = 1;
                    if (a.Rows.Count == 0)
                    {
                        predmetIndex = 0;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (a.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        predmetIndex = 1;
                        Predmet(1);
                    }
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati predmet");
                }
            }
            if (prikaz == "Ocena")
            {
                try
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = Konekcija.Connect();
                    com.CommandText = "delete from ocena where id="+Convert.ToInt64(textBox2.Text);
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    com.Connection = c;
                    com.ExecuteNonQuery();
                    c.Close();
                    Ocene1 = new DataTable();
                    Ocene2 = new DataTable();
                    Ocene1 = Konekcija.Unos("select osoba.ime + ' ' + Osoba.prezime, Ocena.ocena, Ocena.datum, Ocena.id from Osoba join ocena on Osoba.id=Ocena.ucenik_id join Raspodela on Ocena.raspodela_id=Raspodela.id join Predmet on Raspodela.predmet_id=Predmet.id join Odeljenje on Raspodela.odeljenje_id=Odeljenje.id where predmet_id=" + predmetID + " and odeljenje_id=" + odeljenjeID);
                    Ocene2 = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime, Predmet.naziv, Raspodela.id from Osoba join Raspodela on Osoba.id = Raspodela.nastavnik_id join Predmet on Raspodela.predmet_id = Predmet.id join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id where predmet_id = " + predmetID + " and odeljenje_id =" + odeljenjeID);
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    ocenaIndex = 1;
                    if (Ocene1.Rows.Count == 0)
                    {
                        ocenaIndex = 0;
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox2.Text = "";
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (Ocene1.Rows.Count >= 1)
                    {
                        button4.Enabled = true;
                        button5.Enabled = true;
                        ocenaIndex = 1;
                        Ocena(1);
                    }
                }
                catch
                {
                    errorProvider1.SetError(button3, "Trenutno nije moguce izbrisati predmet");
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
                a = Konekcija.Unos("select * from osoba where jmbg='"+textBox5.Text+"'");
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button1, "Takva osoba vec postoji");
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
                a = Konekcija.Unos("select id from skolska_godina where naziv='" + comboBox4.Text + "'");
                int god = (int)a.Rows[0][0];
                a.Clear();
                a = Konekcija.Unos("select * from odeljenje where razred='" + textBox2.Text + "' and indeks='" + textBox3.Text + "' and godina_id=" + god);
                if (a.Rows.Count != 0 && a.Rows[0][0].ToString()!=textBox1.Text)
                {
                    errorProvider1.SetError(button1, "Vec postoji takvo odeljenje");
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
            if (prikaz == "Skolska_godina")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from skolska_godina where naziv='" + textBox2.Text + "'");
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button1, "Vec postoji takva skolska godina");
                }
                else
                {
                    try
                    {
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        SqlCommand com = new SqlCommand();
                        com.Connection = c;
                        com.CommandText = "update skolska_godina set naziv='" + textBox2.Text + "' where id=" + n;
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    catch
                    {
                        errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Smer")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from smer where naziv='" + textBox2.Text + "'");
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button1, "Takav smer vec postoji");
                }
                else
                {
                    try
                    {
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        SqlCommand com = new SqlCommand();
                        com.Connection = c;
                        com.CommandText = "update smer set naziv='" + textBox2.Text + "' where id=" + n;
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    catch
                    {
                        errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Predmet")
            {
                int n = Convert.ToInt32(textBox1.Text);
                DataTable a = new DataTable();
                a = Konekcija.Unos("select * from predmet where naziv='" + textBox2.Text + "' and razred=" + int.Parse(textBox3.Text));
                if (a.Rows.Count != 0)
                {
                    errorProvider1.SetError(button1, "Takav predmet vec postoji");
                }
                else
                {
                    try
                    {
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        SqlCommand com = new SqlCommand();
                        com.Connection = c;
                        com.CommandText = "update predmet set naziv='" + textBox2.Text + "', razred="+textBox3.Text+" where id=" + n;
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    catch
                    {
                        errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                    }
                }
            }
            if (prikaz == "Ocena")
            {
                int n = Convert.ToInt32(textBox2.Text);
                try
                {
                    DataTable a = new DataTable();
                    if (Convert.ToInt16(textBox5.Text) > 5 || Convert.ToInt16(textBox5.Text) < 1) a = Konekcija.Unos("select from u");
                    SqlConnection c = new SqlConnection(Konekcija.Veza());
                    c.Open();
                    SqlCommand com = new SqlCommand();
                    com.Connection = c;
                    com.CommandText = "update ocena set ocena=" + textBox5.Text +" where id=" + n;
                    com.ExecuteNonQuery();
                    c.Close();
                    Ocene1 = new DataTable();
                    Ocene2 = new DataTable();
                    Ocene1 = Konekcija.Unos("select osoba.ime + ' ' + Osoba.prezime, Ocena.ocena, Ocena.datum, Ocena.id from Osoba join ocena on Osoba.id=Ocena.ucenik_id join Raspodela on Ocena.raspodela_id=Raspodela.id join Predmet on Raspodela.predmet_id=Predmet.id join Odeljenje on Raspodela.odeljenje_id=Odeljenje.id where predmet_id=" + predmetID + " and odeljenje_id=" + odeljenjeID);
                    Ocene2 = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime, Predmet.naziv, Raspodela.id from Osoba join Raspodela on Osoba.id = Raspodela.nastavnik_id join Predmet on Raspodela.predmet_id = Predmet.id join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id where predmet_id = " + predmetID + " and odeljenje_id =" + odeljenjeID);
                    Ocena(ocenaIndex);
                }
                catch
                {
                    errorProvider1.SetError(button1, "Uneti podaci nisu dobri");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (prikaz == "Osoba")
            {
                try
                {
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from osoba where jmbg='" + textBox5.Text + "'");
                    if (a.Rows.Count != 0)
                    {
                        errorProvider1.SetError(button2, "JMBG vec postoji");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand();
                            SqlConnection c = new SqlConnection(Konekcija.Veza());
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert osoba values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," + Convert.ToInt32(textBox8.Text) + ")";
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
                            if (osobaindex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Odeljenje")
            {
                try
                {
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
                            int smer = 1, razredni = 1, godina = 1;
                            a = new DataTable();
                            a = Konekcija.Unos("select id from smer where naziv='" + comboBox2.Text + "'");
                            smer = (int)a.Rows[0][0];
                            string[] b = comboBox3.Text.Split(' ');
                            a = new DataTable();
                            a = Konekcija.Unos("select id from osoba where ime='" + b[0] + "'" + " and prezime='" + b[1] + "'");
                            razredni = (int)a.Rows[0][0];
                            a = new DataTable();
                            a = Konekcija.Unos("select id from skolska_godina where naziv='" + comboBox4.Text + "'");
                            godina = (int)a.Rows[0][0];
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert into odeljenje values(" + Convert.ToInt32(textBox2.Text) + ",'" + textBox3.Text + "'," + smer + "," + razredni + "," + godina + ")";
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
                            if (odeljenjeindex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Skolska_godina")
            {
                try
                {
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from skolska_godina where naziv='" + textBox2.Text + "'");
                    if (a.Rows.Count != 0)
                    {
                        errorProvider1.SetError(button2, "Skolska godina vec postoji");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand();
                            SqlConnection c = new SqlConnection(Konekcija.Veza());
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert into skolska_godina values('" + textBox2.Text + "')";
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
                            if (skolska_godinaIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Smer")
            {
                try
                {
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from smer where naziv='" + textBox2.Text + "'");
                    if (a.Rows.Count != 0)
                    {
                        errorProvider1.SetError(button2, "Smer vec postoji");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand();
                            SqlConnection c = new SqlConnection(Konekcija.Veza());
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert into smer values('" + textBox2.Text + "')";
                            com.ExecuteNonQuery();
                            c.Close();
                            button6.Enabled = true;
                            button7.Enabled = true;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button1.Enabled = true;
                            button3.Enabled = true;
                            a = new DataTable();
                            a = Konekcija.Unos("select * from smer");
                            smerIndex = (int)a.Rows.Count;
                            Smer(smerIndex);
                            if (smerIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Predmet")
            {
                try
                {
                    DataTable a = new DataTable();
                    a = Konekcija.Unos("select * from predmet where naziv='" + textBox2.Text + "' and razred=" + int.Parse(textBox3.Text));
                    if (a.Rows.Count != 0)
                    {
                        errorProvider1.SetError(button2, "Predmet vec postoji");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand();
                            SqlConnection c = new SqlConnection(Konekcija.Veza());
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert into predmet values('" + textBox2.Text + "'," + textBox3.Text + ")";
                            com.ExecuteNonQuery();
                            c.Close();
                            button6.Enabled = true;
                            button7.Enabled = true;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button1.Enabled = true;
                            button3.Enabled = true;
                            a = new DataTable();
                            a = Konekcija.Unos("select * from predmet");
                            predmetIndex = (int)a.Rows.Count;
                            Predmet(predmetIndex);
                            if (predmetIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Ocena")
            {
                try
                {
                    string[] s = new string[2];
                    s = comboBox2.Text.Split(' ');
                    int id;
                    try
                    {
                        DataTable a = new DataTable();
                        if (Convert.ToInt16(textBox5.Text) > 5 || Convert.ToInt16(textBox5.Text) < 1) a = Konekcija.Unos("select from u");
                        id = (int)Konekcija.Unos("select distinct Osoba.id from osoba join Upisnica on Osoba.id=Upisnica.osoba_id join Odeljenje on Upisnica.odeljenje_id=Odeljenje.id where Osoba.ime='" + s[0] + "' and prezime='" + s[1] + "' and odeljenje_id=" + odeljenjeID).Rows[0][0];
                        SqlCommand com = new SqlCommand();
                        SqlConnection c = new SqlConnection(Konekcija.Veza());
                        c.Open();
                        com.Connection = c;
                        com.CommandText = "insert into ocena values(getdate()," + Ocene2.Rows[0][2] + "," + textBox5.Text + "," + id + ")";
                        com.ExecuteNonQuery();
                        c.Close();
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        Ocene1 = new DataTable();
                        Ocene2 = new DataTable();
                        Ocene1 = Konekcija.Unos("select osoba.ime + ' ' + Osoba.prezime, Ocena.ocena, Ocena.datum, Ocena.id from Osoba join ocena on Osoba.id=Ocena.ucenik_id join Raspodela on Ocena.raspodela_id=Raspodela.id join Predmet on Raspodela.predmet_id=Predmet.id join Odeljenje on Raspodela.odeljenje_id=Odeljenje.id where predmet_id=" + predmetID + " and odeljenje_id=" + odeljenjeID);
                        Ocene2 = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime, Predmet.naziv, Raspodela.id from Osoba join Raspodela on Osoba.id = Raspodela.nastavnik_id join Predmet on Raspodela.predmet_id = Predmet.id join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id where predmet_id = " + predmetID + " and odeljenje_id =" + odeljenjeID);
                        ocenaIndex = Ocene1.Rows.Count;
                        Ocena(ocenaIndex);
                        if (ocenaIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
                    }
                    catch
                    {
                        errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
            if (prikaz == "Upisnica")
            {
                try
                {
                    DataTable a = new DataTable();
                    string[] s = textBox2.Text.Split(' ');
                    a = Konekcija.Unos("select * from upisnica join osoba on Upisnica.osoba_id=Osoba.id where osoba.ime='" + s[0]+"' and osoba.prezime ='" + s[1]+"'");
                    if (a.Rows.Count != 0)
                    {
                        errorProvider1.SetError(button2, "Osoba je vec u odeljenju");
                    }
                    else
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand();
                            SqlConnection c = new SqlConnection(Konekcija.Veza());
                            c.Open();
                            com.Connection = c;
                            com.CommandText = "insert into upisnica values('" + textBox2.Text + "'," + textBox3.Text + ")";
                            com.ExecuteNonQuery();
                            c.Close();
                            button6.Enabled = true;
                            button7.Enabled = true;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button1.Enabled = true;
                            button3.Enabled = true;
                            a = new DataTable();
                            a = Konekcija.Unos("select * from predmet");
                            predmetIndex = (int)a.Rows.Count;
                            Predmet(predmetIndex);
                            if (predmetIndex == 1) { button6.Enabled = false; button7.Enabled = false; }
                        }
                        catch
                        {
                            errorProvider1.SetError(button2, "Uneti podaci nisu dobri");
                        }
                    }
                }
                catch { errorProvider1.SetError(button2, "Uneti podaci nisu dobri"); }
            }
        }

        private void upisnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Upisnica";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from upisnica");
            if (a.Rows.Count >= 1)
            {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label1.Text = "ID";
                label2.Text = "Ucenik";
                label3.Text = " Odeljenje";
                Upisnica(1);
                upisnicaIndex = 1;
            }
            if (a.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema upisnica u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label1.Text = "ID";
                label2.Text = "Ucenik";
                label3.Text = " Odeljenje";
            }
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Osoba";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from osoba")
;            if (a.Rows.Count>=1) {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label1.Text = " ID";
                label2.Text = "     Ime";
                label3.Text = "   Prezime";
                label7.Text = "Adresa";
                label8.Text = " JMBG";
                label9.Text = "  E-mail";
                label10.Text = " Lozinka";
                label11.Text = " Uloga";
                Osoba(1);
                osobaindex = 1;
            }
            if (a.Rows.Count==1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema osoba u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
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
                label1.Text = " ID";
                label2.Text = "     Ime";
                label3.Text = "   Prezime";
                label7.Text = "Adresa";
                label8.Text = " JMBG";
                label9.Text = "  E-mail";
                label10.Text = " Lozinka";
                label11.Text = " Uloga";              
            }
        }

        private void odeljenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Odeljenje";
            DataTable b,osoba,godina,smer = new DataTable();
            b = Konekcija.Unos("Select * from odeljenje");
            osoba = Konekcija.Unos("Select * from osoba where uloga=2");
            smer = Konekcija.Unos("Select * from smer");
            godina = Konekcija.Unos("Select * from skolska_godina");
            if (b.Rows.Count>=1) {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox3.Enabled = true;
                textBox6.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label3.Text = "     Indeks";
                label4.Text = "   Smer";
                label5.Text = "Razredni";
                label6.Text = "Godina";
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                DataTable c = new DataTable();
                c = Konekcija.Unos("Select naziv from skolska_godina");
                for (int i = 0; i < c.Rows.Count; i++) comboBox4.Items.Add(c.Rows[i][0]);
                a = Konekcija.Unos("select ime,prezime from osoba where uloga=2");
                for (int i = 0; i < a.Rows.Count; i++) comboBox3.Items.Add(a.Rows[i][0] + " " + a.Rows[i][1]);
                c = new DataTable();
                c = Konekcija.Unos("select naziv from smer");
                for (int i = 0; i < c.Rows.Count; i++) comboBox2.Items.Add(c.Rows[i][0]);
                Odeljenje(1);
                odeljenjeindex = 1;
            }
            if (b.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (osoba.Rows.Count == 0 || smer.Rows.Count == 0 || godina.Rows.Count == 0)
            {
                MessageBox.Show("Nije moguce kreirati novo odeljenje, druge potrebne tabele su prazne");
            }
            if (b.Rows.Count == 0 && osoba.Rows.Count != 0 && smer.Rows.Count != 0 && godina.Rows.Count != 0)
            {
                MessageBox.Show("Nema odeljenja u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox3.Enabled = true;
                textBox6.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
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
                label3.Text = "     Indeks";
                label4.Text = "   Smer";
                label5.Text = "Razredni";
                label6.Text = "Godina";
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                DataTable c,a = new DataTable();
                c = Konekcija.Unos("Select naziv from skolska_godina");
                for (int i = 0; i < c.Rows.Count; i++) comboBox4.Items.Add(c.Rows[i][0]);
                a = Konekcija.Unos("select ime,prezime from osoba where uloga=2");
                for (int i = 0; i < a.Rows.Count; i++) comboBox3.Items.Add(a.Rows[i][0] + " " + a.Rows[i][1]);
                c = new DataTable();
                c = Konekcija.Unos("select naziv from smer");
                for (int i = 0; i < c.Rows.Count; i++) comboBox2.Items.Add(c.Rows[i][0]);
            }
        }

        private void oceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Ocena";
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
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
            label12.Visible = true;
            label13.Visible = true;
            comboBox5.Visible = true;
            comboBox1.Visible = true;
            label12.Text = "Odeljenje";
            label13.Text = "Predmet";
            Odeljenja = new DataTable();
            Predmeti= new DataTable();
            Predmeti = Konekcija.Unos("select naziv,id from predmet");
            Odeljenja = Konekcija.Unos("select Odeljenje.razred,Odeljenje.indeks,Skolska_godina.naziv,Odeljenje.id from Odeljenje join Skolska_godina on Odeljenje.godina_id=Skolska_godina.id");
            for (int i = 0; i < Predmeti.Rows.Count; i++)
            {
                comboBox5.Items.Add(Predmeti.Rows[i][0]);
            }
            for (int i = 0; i < Odeljenja.Rows.Count; i++)
            {
                comboBox1.Items.Add(Odeljenja.Rows[i][0].ToString() + " / " + Odeljenja.Rows[i][1].ToString() + " / " + Odeljenja.Rows[i][2].ToString());
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox1.FindStringExact(comboBox1.Text) == -1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                comboBox2.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
            }
        }

        private void comboBox5_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox5.FindStringExact(comboBox5.Text)==-1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                comboBox2.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox5.Text.Trim()!="" && comboBox1.Text.Trim() != "")
            {
                odeljenjeID = (int)Odeljenja.Rows[comboBox1.SelectedIndex][3]; predmetID = (int) Predmeti.Rows[comboBox5.SelectedIndex][1];
                DataTable c = new DataTable();
                c = Konekcija.Unos("select * from raspodela where odeljenje_id="+odeljenjeID+" and predmet_id="+predmetID);
                if (c.Rows.Count!=0) {
                    ocenaIndex = 1;
                    Ocene1 = new DataTable();
                    Ocene2 = new DataTable();
                    Ucenici = new DataTable();
                    Ucenici = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime from Osoba join Upisnica on Osoba.id=Upisnica.osoba_id join Odeljenje on Upisnica.odeljenje_id=Odeljenje.id where odeljenje_id=" + odeljenjeID);
                    Ocene1 = Konekcija.Unos("select osoba.ime + ' ' + Osoba.prezime, Ocena.ocena, Ocena.datum, Ocena.id from Osoba join ocena on Osoba.id=Ocena.ucenik_id join Raspodela on Ocena.raspodela_id=Raspodela.id join Predmet on Raspodela.predmet_id=Predmet.id join Odeljenje on Raspodela.odeljenje_id=Odeljenje.id where predmet_id=" + predmetID + " and odeljenje_id=" + odeljenjeID);
                    Ocene2 = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime, Predmet.naziv, Raspodela.id from Osoba join Raspodela on Osoba.id = Raspodela.nastavnik_id join Predmet on Raspodela.predmet_id = Predmet.id join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id where predmet_id = " + predmetID + " and odeljenje_id =" + odeljenjeID);
                    if (Ocene1.Rows.Count >= 1)
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        comboBox2.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        textBox2.Enabled = false;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label2.Text = "ID";
                        label3.Text = "Profesor";
                        label4.Text = "Ucenik";
                        label5.Text = "Ocena";
                        label6.Text = "Datum";
                        Ocena(1);
                        comboBox2.Items.Clear();
                        for (int i = 0; i < Ucenici.Rows.Count; i++) comboBox2.Items.Add(Ucenici.Rows[i][0].ToString());
                    }
                    if (Ocene1.Rows.Count == 1)
                    {
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (Ocene1.Rows.Count == 0)
                    {
                        MessageBox.Show("Nema ocena u bazi");
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        comboBox2.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        textBox2.Enabled = false;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox2.Text = "";
                        label2.Text = "ID";
                        label3.Text = "Profesor";
                        label4.Text = "Ucenik";
                        label5.Text = "Ocena";
                        label6.Text = "Datum";
                        comboBox2.Items.Clear();
                        for (int i = 0; i < Ucenici.Rows.Count; i++) comboBox2.Items.Add(Ucenici.Rows[i][0].ToString());
                        textBox3.Text = Ocene2.Rows[0][0].ToString();
                    }
                }
                else {
                    MessageBox.Show("Odeljenje nema taj predmet");
                    comboBox1.Text = "";
                    comboBox5.Text = "";
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    comboBox2.Visible = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() != "" && comboBox1.Text.Trim() != "")
            {               
                odeljenjeID = (int)Odeljenja.Rows[comboBox1.SelectedIndex][3]; predmetID = (int)Predmeti.Rows[comboBox5.SelectedIndex][1];
                DataTable c = new DataTable();
                c = Konekcija.Unos("select * from raspodela where odeljenje_id=" + odeljenjeID + " and predmet_id=" + predmetID);
                if (c.Rows.Count!=0) {
                    ocenaIndex = 1;
                    Ocene1 = new DataTable();
                    Ocene2 = new DataTable();
                    Ucenici = new DataTable();
                    Ucenici = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime from Osoba join Upisnica on Osoba.id=Upisnica.osoba_id join Odeljenje on Upisnica.odeljenje_id=Odeljenje.id where odeljenje_id=" + odeljenjeID);
                    Ocene1 = Konekcija.Unos("select osoba.ime + ' ' + Osoba.prezime, Ocena.ocena, Ocena.datum, Ocena.id from Osoba join ocena on Osoba.id=Ocena.ucenik_id join Raspodela on Ocena.raspodela_id=Raspodela.id join Predmet on Raspodela.predmet_id=Predmet.id join Odeljenje on Raspodela.odeljenje_id=Odeljenje.id where predmet_id=" + predmetID + " and odeljenje_id=" + odeljenjeID);
                    Ocene2 = Konekcija.Unos("select Osoba.ime + ' ' + Osoba.prezime, Predmet.naziv, Raspodela.id from Osoba join Raspodela on Osoba.id = Raspodela.nastavnik_id join Predmet on Raspodela.predmet_id = Predmet.id join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id where predmet_id = " + predmetID + " and odeljenje_id =" + odeljenjeID);
                    if (Ocene1.Rows.Count >= 1)
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        comboBox2.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        textBox2.Enabled = false;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        label2.Text = "ID";
                        label3.Text = "Profesor";
                        label4.Text = "Ucenik";
                        label5.Text = "Ocena";
                        label6.Text = "Datum";
                        Ocena(1);
                        comboBox2.Items.Clear();
                        for (int i = 0; i < Ucenici.Rows.Count; i++) comboBox2.Items.Add(Ucenici.Rows[i][0].ToString());
                    }
                    if (Ocene1.Rows.Count == 1)
                    {
                        button4.Enabled = false;
                        button5.Enabled = false;
                    }
                    if (Ocene1.Rows.Count == 0)
                    {
                        MessageBox.Show("Nema ocena u bazi");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox2.Text = "";
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        comboBox2.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        textBox2.Enabled = false;
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        label2.Text = "ID";
                        label3.Text = "Profesor";
                        label4.Text = "Ucenik";
                        label5.Text = "Ocena";
                        label6.Text = "Datum";
                        comboBox2.Items.Clear();
                        for (int i = 0; i < Ucenici.Rows.Count; i++) comboBox2.Items.Add(Ucenici.Rows[i][0].ToString());
                        textBox3.Text = Ocene2.Rows[0][0].ToString();
                    }
                }
                else { 
                    MessageBox.Show("Odeljenje nema taj predmet");
                    comboBox1.Text = ""; 
                    comboBox5.Text = "";
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    comboBox2.Visible = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void predmetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Predmet";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from predmet");
            if (a.Rows.Count >= 1)
            {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label1.Text = "ID";
                label2.Text = "  Naziv";
                label3.Text = "    Razred";
                Predmet(1);
                predmetIndex = 1;
            }
            if (a.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema predmeta u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                label1.Text = "ID";
                label2.Text = "  Naziv";
                label3.Text = "    Razred";
            }
        }

        private void smerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Smer";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from smer");
            if (a.Rows.Count >= 1)
            {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label2.Text = "  Naziv";
                Smer(1);
                smerIndex = 1;
            }
            if (a.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema smerova u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
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
                label2.Text = "  Naziv";
            }
        }

        private void skolskaGodinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            prikaz = "Skolska_godina";
            DataTable a = new DataTable();
            a = Konekcija.Unos("select * from skolska_godina"); 
            if (a.Rows.Count >= 1)
            {
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
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
                label2.Text = "  Naziv";
                Skolska_godina(1);
                skolska_godinaIndex = 1;
            }
            if (a.Rows.Count == 1)
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            if (a.Rows.Count == 0)
            {
                MessageBox.Show("Nema Skolskih godina u bazi");
                comboBox1.Text = "";
                comboBox5.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox6.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Items.Clear();
                comboBox5.Items.Clear();
                label12.Visible = false;
                label13.Visible = false;
                comboBox5.Visible = false;
                comboBox1.Visible = false;
                textBox2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
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
                label2.Text = "  Naziv";
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
            if (prikaz == "Smer")
            {
                DataTable x = new DataTable();
                x = Konekcija.Unos("select count(id) from smer");
                Smer((int)x.Rows[0][0]);
                smerIndex = (int)x.Rows[0][0];
            }
            if (prikaz == "Predmet")
            {
                DataTable x = new DataTable();
                x = Konekcija.Unos("select count(id) from predmet");
                Predmet((int)x.Rows[0][0]);
                predmetIndex = (int)x.Rows[0][0];
            }
            if (prikaz == "Ocena")
            {
                Ocena(Ocene1.Rows.Count);
                ocenaIndex = Ocene1.Rows.Count;
            }
            if (prikaz == "Upisnica")
            {
                DataTable x = new DataTable();
                x = Konekcija.Unos("select count(id) from upisnica");
                Upisnica((int)x.Rows[0][0]);
                upisnicaIndex = (int)x.Rows[0][0];
            }
            button5.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
        }
    }
}
