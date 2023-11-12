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

        public struct product
        {
            public string Nome;
            public float Prezzo;
            public int Numero;
            public int Visualizza;
        }

        public void aggiungiprodotti(string nome, float prezzo, string filePath, int recordLenght)
        {
            var oStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);

            sw.WriteLine($"{nome};{prezzo};1;0;".PadRight(recordLenght - 4) + "##");

            sw.Close();
        }

        public product ricercaprodotti(int posizione, string filePath, int recordLenght)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var reader = new BinaryReader(fileStream);

                // Posiziona il puntatore del file alla posizione corretta per leggere il record del prodotto.
                fileStream.Seek(recordLenght * posizione, SeekOrigin.Begin);

                // Legge i dati dal file e crea un oggetto prodotto.
                string n = reader.ReadString();
                float p = reader.ReadSingle();
                int num = reader.ReadInt32();
                int v = reader.Read();

                // Chiude il reader e il fileStream.
                reader.Close();
                fileStream.Close();

                return new product { Nome = n, Prezzo = p, Numero = num, Visualizza = v };
            }
        }

        public void modificaprodotto(int posizione, string nome, float prezzo, string filePath, int recordLenght)
        {
            
            // Cerca il prodotto nella posizione specificata all'interno del file e lo assegna a 'prod'.
            product prod = ricercaprodotti(posizione, filePath, recordLenght); ;

            // Apre un FileStream per il file specificato in modalità di apertura per la scrittura.
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);

            // Posiziona il puntatore del file alla posizione corretta per sovrascrivere il record del prodotto.
            file.Seek(recordLenght * posizione, SeekOrigin.Begin);

            // Crea una nuova riga con i dati modificati: nome, prezzo, 'number' da 'prod', e 0 come quarto campo.
            // Utilizza PadRight per garantire che la riga abbia la lunghezza corretta specificata da 'recordLength - 4'
            // e aggiunge "##" alla fine della riga.
            string line = $"{nome};{prezzo};{prod.Numero};0;".PadRight(recordLenght - 4) + "##";

            // Converte la riga in un array di byte utilizzando la codifica UTF-8.
            byte[] bytes = Encoding.UTF8.GetBytes(line);

            // Scrive gli array di byte nel file per sovrascrivere i dati esistenti.
            writer.Write(bytes);

            // Chiude il BinaryWriter e il FileStream per rilasciare le risorse.
            writer.Close();
            file.Close();
        }

        public void cancellaprodotto(int position, string filePath, int recordLength)
        {
            // Cerca il prodotto nella posizione specificata all'interno del file e lo assegna a 'prod'.
            product prod = ricercaprodotti(position, filePath, recordLength);

            // Apre un FileStream per il file specificato in modalità di apertura per la scrittura.
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
        }
    
        private void Modifican_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(modnome_box.Text))
            {
                MessageBox.Show("Non hai inserito nesssun nome!");
            }
            else
            {

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
                string nome = Nome_box.Text;
                float prezzo = float.Parse(Prezzo_box.Text);
                string lunghezza = $"{nome};{prezzo};1;0;";
                int recordLength = lunghezza.Length;
                aggiungiprodotti(nome, prezzo, "prodotti.dat", recordLength);
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
   

       

