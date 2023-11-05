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
        //inserire prodotto
        private void inserisci_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nome_box.Text) || string.IsNullOrEmpty(Prezzo_box.Text))
            {
                MessageBox.Show("Non hai inserito nulla nel prezzo o nel nome prodotto!");
            }
            else
            {
                p[dim].nome = Nome_box.Text;
                p[dim].prezzo = float.Parse(Prezzo_box.Text);
                dim++;
                visualizza(p);
                MessageBox.Show("Prodotto aggiunto");
                Nome_box.Clear();
                Prezzo_box.Clear();
            }
        }
        public void aggiornaVista(int dim)
        {
            articoli.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                articoli.Items.Add("Nome: " + p[i].nome.ToString() + "      Prezzo: " + p[i].prezzo.ToString() + "£");
            }
        }
        public string prodString(Prodotto p)
        {
            return "Nome: " + p.nome.ToString() + "      Prezzo: " + p.prezzo.ToString() + "£";
        }

        //Aggiungi nella list_box
        public void visualizza(Prodotto[] pp)
        {
            articoli.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                articoli.Items.Add(prodString(pp[i]));
            }
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
                    if (p[i].nome == ricerca_box.Text)
                    {
                        p[i].nome = modnome_box.Text;
                        aggiornaVista(dim);
                        MessageBox.Show("Nome modificato");
                        modnome_box.Clear();
                        ricerca_box.Clear();
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
                    if (p[i].prezzo == float.Parse(ricerca_box.Text))
                    {
                        p[i].prezzo = float.Parse(modprezzo_box.Text);
                        aggiornaVista(dim);
                        MessageBox.Show("Prezzo modificato");
                        modprezzo_box.Clear();
                        ricerca_box.Clear();
                        break;
                    }
                }
            }
        }

        private void canclogica_btn_Click(object sender, EventArgs e)
        {
            string prodFilePath = @"prodotti.txt";
            string cestinoFilePath = @"cestino_prodotti.txt";
            if (File.Exists(prodFilePath))
            {
                // Copia il contenuto del file dei prodotti nel cestino
                File.WriteAllText(cestinoFilePath, File.ReadAllText(prodFilePath));
                // Cancella il contenuto del file dei prodotti
                File.Delete(prodFilePath);
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
                string nomeprodotto = Nome_box.Text;
                if (decimal.TryParse(Prezzo_box.Text, out decimal prezzoProdotto))
                {
                    string FilePath = @"prodotti.txt";
                    var oFile = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter sw = new StreamWriter(oFile);
                    sw.WriteLine($"{Nome_box.Text};{Prezzo_box.Text}€");
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
        private int ContaRighePerProdotto(string prodottoDaCercare)
        {
            string FilePath = @"prodotti.txt";
            int conteggio = 0;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    if (linea.Contains(prodottoDaCercare))
                    {
                        conteggio++;
                    }
                }
            }
            return conteggio;
        }

        private void cancfisica_Click(object sender, EventArgs e)
        {
            string prodFilePath = @"prodotti.txt";
            string cestinoFilePath = @"cestino_prodotti.txt";
            if (File.Exists(prodFilePath))
            {
                // Cancella il contenuto del file dei prodotti
                File.Delete(prodFilePath);
                File.Delete(cestinoFilePath);
                MessageBox.Show("Cancellazione fisica completata.");
            }
            else
            {
                MessageBox.Show("Non c'è nulla nel file.");
            }
        }
    }
}
       

