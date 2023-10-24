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
                        break;
                    }
                    aggiornaVista(dim);
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
                        break;
                    }
                }
            }
        }

        private void cancella_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ricerca_box.Text))
            {
                MessageBox.Show("Non hai inserito nessun prodotto della lista!");
            }
            else
            {
                // scorre ogni prodotto
                for (int i = 0; i < dim; i++)
                {
                    // verifica se è il prodotto ricercato
                    if (p[i].nome == ricerca_box.Text)
                    {
                        // cambia e cancella la posizione del prodotto ricercato 
                        for (int j = i; j < dim - 1; j++)
                        {
                            p[j] = p[j + 1];
                        }
                        dim--;

                        aggiornaVista(dim);
                        MessageBox.Show("Cancellato");
                        return;
                    }
                }
            }
        }

        private void somma_btn_Click(object sender, EventArgs e)
        {
            float prezzotot = 0;
            // somma tutti i prezzi
            for (int i = 0; i < dim; i++)
            {
                prezzotot += p[i].prezzo;
            }
            MessageBox.Show("Prezzo totale: " + prezzotot + "£");
        }

        private void min_btn_Click(object sender, EventArgs e)
        {
            float min = 100;
            //verifica quale prezzo è il minore
            for (int i = 0; i < dim; i++)
            {
                if (p[i].prezzo < min)
                {
                    min = p[i].prezzo;
                }
            }
            MessageBox.Show("Prezzo minore: " + min+ "£");
        }

        private void max_btn_Click(object sender, EventArgs e)
        {
            float maggiore = 0;
            // verifica se quale prezzo è maggiore
            for (int i = 0; i < dim; i++)
            {
                if (p[i].prezzo > maggiore)
                {
                    maggiore = p[i].prezzo;
                }
            }
            MessageBox.Show("Prezzo maggiore: " + maggiore + "£");
        }

        private void ordinamento_btn_Click(object sender, EventArgs e)
        {
            // ordinamento Bubble Sort
            for (int i = 0; i < dim - 1; i++)
            {
                for (int j = 0; j < dim - i - 1; j++)
                {
                    if (string.Compare(p[j].nome, p[j + 1].nome) > 0)
                    {
                        // Scambia gli elementi se sono fuori ordine
                        Prodotto temp = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = temp;
                    }
                }
            }
            articoli.Items.Clear();
            // aggiunta degli elmenti ordinati
            aggiornaVista(dim);
        }

        private void fileprod_btn_Click(object sender, EventArgs e)
        {
            string filename = "prodotti.txt";
            StreamWriter writer = new StreamWriter(filename);
            // aggiunge i nomi e i prezzi dei prodotti nel file
            for (int i = 0; i < dim; i++)
            {
                writer.WriteLine("Nome: " + p[i].nome.ToString() + "       Prezzo: " + p[i].prezzo.ToString() + "£");
            }
            writer.Close();
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
            }
            else
            {
                MessageBox.Show("Il file non esiste");
            }
        }

        private void sott_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prc_box.Text))
            {
                MessageBox.Show("Non hai inserito la percentuale!");
            }
            else
            {
                float percentuale = float.Parse(prc_box.Text);
                float perc;
                // toglie la percentuale a ogni prezzo
                for (int i = 0; i < dim; i++)
                {
                    perc = (percentuale / 100) * p[i].prezzo;
                    p[i].prezzo = p[i].prezzo - perc;
                }
                aggiornaVista(dim);
            }
        }

        private void agg_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(prc_box.Text))
            {
                MessageBox.Show("Non hai inserito la percentuale!");
            }
            else
            {
                float percentuale = float.Parse(prc_box.Text);
                float perc;
                // aggiunge la percentuale a ogni prezzo
                for (int i = 0; i < dim; i++)
                {
                    perc = (percentuale / 100) * p[i].prezzo;
                    p[i].prezzo = p[i].prezzo + perc;
                }
                aggiornaVista(dim);
            }
        }
    }
}
