using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneCRUDcongestionedirettasulfile
{
    public partial class Form1 : Form
    {
        //struct prodotto
        public struct Prodotto
        {
            public string nome;
            public float prezzo;
        }
        public Prodotto[] p;
        public int dim;
        public Form1()
        {
            InitializeComponent();

            p = new Prodotto[100];
            dim = 0;
        }

        private void Modifican_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(modnome_box.Text))
            {
                MessageBox.Show("Non hai inserito nesssun nome!");
            }
            else
            {
                // scorre tutti i prodotti
                for (int i = 0; i < dim; i++)
                {
                    // controlla se è il prodotto ricercato
                    if (p[i].nome == ricercanome_box.Text)
                    {
                        p[i].nome = modnome_box.Text;
                        //aggiornaVista(dim);
                        MessageBox.Show("Nome modificato");
                        modnome_box.Clear();
                        ricercanome_box.Clear();
                        break;
                    }
                }
            }
        }

        private void Modificap_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(modprezzo_box.Text))
            {
                MessageBox.Show("Non hai inserito nesssun prezzo!");
            }
            else
            {
                // scorre tutti i prezzi
                for (int i = 0; i < dim; i++)
                {
                    // controlla se è il prezzo ricercato
                    if (p[i].prezzo == float.Parse(ricercanome_box.Text))
                    {
                        p[i].prezzo = float.Parse(modprezzo_box.Text);
                        //aggiornaVista(dim);
                        MessageBox.Show("Prezzo modificato");
                        modprezzo_box.Clear();
                        ricercanome_box.Clear();
                        break;
                    }
                }
            }
        }

        private void canclogica_btn_Click(object sender, EventArgs e)
        {
            string prodFilePath = @"prodotti.txt";
            if (File.Exists(prodFilePath))
            {

                MessageBox.Show("Cancellazione logica completata. Il contenuto è stato spostato nel cestino.");
            }
            else
            {
                MessageBox.Show("Non c'è nulla nel file.");
            }
        }

        private void fileprod_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nome_box.Text) || string.IsNullOrEmpty(Prezzo_box.Text))
            {
                MessageBox.Show("Non hai inserito nulla nel prezzo o nel nome prodotto!");
            }
            else
            {
                string prezzoprodotto = Prezzo_box.Text;
                string nomeprodotto = Nome_box.Text;
                int Lenght;
                if (decimal.TryParse(Prezzo_box.Text, out decimal prezzoProdotto))
                {
                    string FilePath = @"prodotti.txt";
                    var oFile = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter sw = new StreamWriter(oFile);
                    sw.WriteLine($"{nomeprodotto};{prezzoprodotto};1;0;".PadRight(Lenght - 4) + "##");
                    sw.Close();
                    MessageBox.Show("Prodotto aggiunto al file.");
                    
                }
                else
                {
                    MessageBox.Show("Inserisci un prezzo valido per il prodotto.");
                }
            }
        }

        private void mostraprod_btn_Click(object sender, EventArgs e)
        {
            string filename = "prodotti.txt";
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string line;
                // legge il file
                while ((line = reader.ReadLine()) != null)
                {
                    // aggiunge il nome e il prezzo dei prodotti nella listbox
                    articoli.Items.Add(line);
                }
                reader.Close();
                MessageBox.Show("Prodotti nel file");
            }
            else
            {
                MessageBox.Show("Il file non esiste");
            }
        }
        private void reset_btn_Click(object sender, EventArgs e)
        {
            string prodFilePath = @"prodotti.txt";
            if (File.Exists(prodFilePath))
            {
                // Cancella il contenuto del file dei prodotti
                File.Delete(prodFilePath);
                MessageBox.Show("reset file completato.");
            }
            else
            {
                MessageBox.Show("Non c'è nulla nel file.");
            }
        }
        private int Ricerca(string nome)
        {
            int riga = 0;
            string prodFilePath = @"prodotti.txt";
            string ricercan = ricercanome_box.Text;

            if (File.Exists(prodFilePath))
            {
                using (StreamReader sr = File.OpenText(prodFilePath))
                {
                    string s;

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');

                        if (dati[3] == "0" && dati[0] == ricercan)
                        {
                            sr.Close();
                            return riga;
                        }
                        riga++;
                    }
                    return -1;
                }
            }
        }

        private void recupera_btn_Click(object sender, EventArgs e)
        {
            string prodFilePath = @"prodotti.txt";
            string ricercan = ricercanome_box.Text;

            if (File.Exists(prodFilePath))
            {
                using (StreamReader sr = File.OpenText(prodFilePath))
                {
                    string s;

                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] dati = s.Split(';');

                        if (dati[3] == "0" && dati[0] == ricercan)
                        {
                            File.WriteAllText(prodFilePath, dati[3] + dati[0]);
                            sr.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Il cestino è vuoto.");
            }

        }
    }
}
   

       

