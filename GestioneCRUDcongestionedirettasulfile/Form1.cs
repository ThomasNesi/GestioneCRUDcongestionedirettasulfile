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

        public int ricercaprodotti(string nome, string filePath)
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

            prodotto prod = recuperaprodotto(posizione, filePath); 

            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            // Posiziona il puntatore del file alla posizione corretta per sovrascrivere il record del prodotto.
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);

            string line = $"{nome};{prezzo};{prod.Numero};0;".PadRight(recordLenght - 4) + "##";

            byte[] bytes = Encoding.UTF8.GetBytes(line);

            // Scrive gli array di byte nel file per sovrascrivere i dati esistenti.
            writer.Write(bytes);

            writer.Close();
            file.Close();
        }

        public void canclogica(int posizione, string filePath)
        {
            prodotto prod = recuperaprodotto(posizione, filePath);

            prod.Visualizza = false;

            sprodotti(prod, posizione, filePath);
        }
        public void cancfisica(int posizione, string filePath)
        {
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            {
                
                file.Seek(posizione, SeekOrigin.Begin);

                var emptyLine = new string(' ', recordLenght);
                byte[] bytes = Encoding.UTF8.GetBytes(emptyLine);
                file.Write(bytes, 0, bytes.Length);
            }
            MessageBox.Show($"Prodotto fisicamente cancellato.");

        }
        private void sprodotti(prodotto prod, int posizione, string filePath)
        {
            using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            using (var writer = new BinaryWriter(file))
            {

                file.Seek(recordLenght * posizione, SeekOrigin.Begin);

                string line = $"{prod.Nome};{prod.Prezzo};{prod.Numero};{prod.Visualizza};".PadRight(recordLenght - 4) + "##";
                byte[] bytes = Encoding.UTF8.GetBytes(line);

                writer.Write(bytes);
            }
        }

        private prodotto recuperaprodotto(int position, string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                sr.BaseStream.Seek(recordLenght * position, SeekOrigin.Begin);
                string line = sr.ReadLine();
                sr.Close();

                string[] data = line.Split(';');

                prodotto prod;
                prod.Nome = data[0];
                prod.Prezzo = float.Parse(data[1]);
                prod.Numero = int.Parse(data[2]);
                prod.Visualizza = data[3] == "1";

                return prod;
            }
        }
        private int posizionecanc = -1;
        private void canclogica_btn_Click(object sender, EventArgs e)
        {
            string nomeCercato = ricerca_box.Text;

            int posizione = ricercaprodotti(nomeCercato, "prodotti.dat");

            if (posizione != -1)
            {
                canclogica(posizione, "prodotti.dat");
                MessageBox.Show($"Prodotto cancellato logicamente.");
            }
            else
            {
                MessageBox.Show($"Prodotto non trovato.");
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
            string nomeCercato = ricerca_box.Text;
            string lunghezza = $"nome;prezzo;1;0;##";
            int recordLength = lunghezza.Length;

            int posizione = ricercaprodotti(nomeCercato, "prodotti.dat");

            if (posizionecanc != -1)
            {
                prodotto prodottoRecuperato = recuperaprodotto(posizione, "prodotti.dat");
            }
            else
            {
                MessageBox.Show($"Prodotto con nome '{nomeCercato}' non trovato.");
            }
        }


        private void Modifica_btn_Click(object sender, EventArgs e)
        {
            string nuovonome = modnome_box.Text;
            float nuovoprezzo = float.Parse(modprezzo_box.Text);
            string lunghezza = $"{nuovonome};{nuovoprezzo};1;0;";
            int recordLength = lunghezza.Length;
            string ricnome = ricerca_box.Text;

            int posizione = ricercaprodotti(ricnome, "prodotti.dat");

            if (posizione != -1)
            {
                modificaprodotto(posizione, nuovonome, nuovoprezzo, "prodotti.dat");
                MessageBox.Show($"Prodotto modificato.");
            }
            else
            {
                MessageBox.Show($"Prodotto non trovato.");
            }
        }

        private void cancfisica_btn_Click(object sender, EventArgs e)
        {
            string nomeCercato = ricerca_box.Text;

            int posizione = ricercaprodotti(nomeCercato, "prodotti.dat");

            if (posizione != -1)
            {
                // Esegui la cancellazione fisica.
                cancfisica(posizione, "prodotti.dat");

                MessageBox.Show($"Prodotto cancellato fisicamente.");

            }
            else
            {
                MessageBox.Show($"Prodotto con nome '{nomeCercato}' non trovato.");
            }
        }
    }
}
   

       

