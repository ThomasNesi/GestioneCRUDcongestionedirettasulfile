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
using System.Xml.Linq;
using static GestioneCRUDcongestionedirettasulfile.Form1;

namespace GestioneCRUDcongestionedirettasulfile
{
    public partial class Form1 : Form
    {

        public struct prodotto
        {
            public string Nome;
            public float Prezzo;
            public int Numero;
            public bool Visualizza;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private int recordLenght = 64;
        public void aggiungiprodotti(string nome, float prezzo, string filePath)
        {
            var oStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);

            sw.WriteLine($"{nome};{prezzo};1;0;".PadRight(recordLenght - 4) + "##");

            sw.Close();
        }

        public int indprodotti(string nome, string filePath)
        {
            int posizione = 0;

            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;

                while ((s = sr.ReadLine()) != null)
                {
                    string[] data = s.Split(';');

                    if (data[3] == "0" && data[0] == nome)
                    {
                        sr.Close();
                        return posizione;
                    }

                    posizione++;
                }

                sr.Close();
            }

            return -1;
        }


    public void modificaprodotto(int posizione, string nome, float prezzo, string filePath)
        {

            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            // Posiziona il puntatore del file alla posizione corretta per sovrascrivere il record del prodotto.
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);

            string line = $"{nome};{prezzo};1;0;".PadRight(recordLenght - 4) + "##";

            byte[] bytes = Encoding.UTF8.GetBytes(line);

            // Scrive gli array di byte nel file per sovrascrivere i dati esistenti.
            writer.Write(bytes);

            writer.Close();
            file.Close();
        }
        public string[] ricercaprod(string nome, string filePath)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }

        public void canclogica(string filePath)
        {
            int indice = indprodotti(ricerca_box.Text, filePath);
            if (string.IsNullOrEmpty(ricerca_box.Text))
            {
                MessageBox.Show("Inserire un prodotto");
                return;
            }
            else if (indice == -1)
            {
                MessageBox.Show("Il prodotto non esiste");
            }
            else if (indice >= 0)
            {
                sprodotti(filePath);
                MessageBox.Show("Prodotto cancellato logicamente");
            }
        }
        public void cancfisica(string filePath)
        {
            int ind = indprodotti(ricerca_box.Text, filePath);
            if (string.IsNullOrEmpty(ricerca_box.Text))
            {
                MessageBox.Show("Non è stato inserito nulla");
                return;
            }
            else if (ind == -1)
            {
                MessageBox.Show("Il prodotto ricercato non esiste");
            }
            else if (ind >= 0)
            {
                List<string> line = new List<string>();

                using (StreamReader salva = File.OpenText(filePath))
                {
                    string lettura;
                    while ((lettura = salva.ReadLine()) != null)
                    {
                        line.Add(lettura);
                    }
                }

                line.RemoveAt(ind);

                using (StreamWriter scrivi = new StreamWriter(filePath, false))
                {
                    foreach (string riga in line)
                    {
                        scrivi.WriteLine(riga);
                    }
                }
                MessageBox.Show("Prodotto eliminato fisicamente");
            }

        }
        private void sprodotti(string filePath)
        {
            int indice = indprodotti(ricerca_box.Text, filePath);
            string[] prodotto = ricercaprod(ricerca_box.Text, filePath);
            string line;
            var salva = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter scrivi = new BinaryWriter(salva);
            salva.Seek(recordLenght * indice, SeekOrigin.Begin);
            line = $"{prodotto[0]};{prodotto[1]};{prodotto[3]};1;".PadRight(recordLenght - 4) + "##";
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            scrivi.Write(bytes, 0, bytes.Length);
            scrivi.Close();
            salva.Close();
        }

        private void recuperaprodotto(string filePath)
        {
            int indice = indprodotti(ricerca_box.Text, filePath);
            if (string.IsNullOrEmpty(ricerca_box.Text))
            {
                MessageBox.Show("Inserire un prodotto");
                return;
            }
            else if (indice == -1)
            {
                MessageBox.Show("Prodotto non esiste");
            }
            else if (indice >= 0)
            {
                string[] prod = ricercaprod(ricerca_box.Text, filePath);
                string line;
                var salva = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                BinaryWriter scrivi = new BinaryWriter(salva);
                salva.Seek(recordLenght * indice, SeekOrigin.Begin);
                line = $"{prod[0]};{prod[1]};{prod[3]};0;".PadRight(recordLenght - 4) + "##";
                byte[] bytes = Encoding.UTF8.GetBytes(line);
                scrivi.Write(bytes, 0, bytes.Length);
                scrivi.Close();
                salva.Close();
                MessageBox.Show("Prodotto recuperato");
            }
        }
        private void canclogica_btn_Click(object sender, EventArgs e)
        {
                canclogica("prodotti.dat");
                MessageBox.Show($"Prodotto cancellato logicamente.");
        }

        private void fileprod_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nome_box.Text) || string.IsNullOrEmpty(Prezzo_box.Text))
            {
                MessageBox.Show("Non hai inserito nulla nel prezzo o nel nome prodotto!");
            }
            else
            {
                string nome = Nome_box.Text;
                float prezzo = float.Parse(Prezzo_box.Text);
                aggiungiprodotti(nome, prezzo, "prodotti.dat");
            }
        }

        private void mostraprod_btn_Click(object sender, EventArgs e)
        {
            string filename = "prodotti.dat";
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string line;
                // legge il file
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    if (data[3] == "0")
                    {
                        // aggiunge il nome e il prezzo dei prodotti nella listbox
                        articoli.Items.Add(line);
                    }
                    else
                    {
                        articoli.Items.Add(" ");
                    }
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
            string prodFilePath = @"prodotti.dat";
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

        private void recupera_btn_Click(object sender, EventArgs e)
        {
            recuperaprodotto("prodotti.dat");
        }


        private void Modifica_btn_Click(object sender, EventArgs e)
        {
            string nuovonome = modnome_box.Text;
            float nuovoprezzo = float.Parse(modprezzo_box.Text);
            string ricnome = ricerca_box.Text;

            int posizione = indprodotti(ricnome, "prodotti.dat");

            if (posizione == -1)
            {
                MessageBox.Show($"Prodotto non trovato.");
            }
            else if(posizione >= 0)
            {
                modificaprodotto(posizione, nuovonome, nuovoprezzo, "prodotti.dat");
                MessageBox.Show($"Prodotto modificato.");
            }
        }

        private void cancfisica_btn_Click(object sender, EventArgs e)
        {
            cancfisica("prodotti.dat");
            ricerca_box.Clear();
        }
    }
}
   

       

