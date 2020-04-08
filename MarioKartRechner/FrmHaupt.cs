using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioKartRechner
{
    public partial class frmHaupt : Form
    {
        //Globale Variablen
        private List<string> alleSpieler = new List<string>();
        private List<string> nichtAusgewaehlteSpieler = new List<string>();

        public frmHaupt()
        {
            InitializeComponent();
        }

        //Laden der Form
        private void frmHaupt_Load(object sender, EventArgs e)
        {
            //Spielernamen in List hinzufügen
            for (int i = 0; i < listBoxSchueler.Items.Count; i++)
            {
                alleSpieler.Add(listBoxSchueler.Items[i].ToString());
                nichtAusgewaehlteSpieler.Add(listBoxSchueler.Items[i].ToString());
            }
            //Label Text zurücksetzen
            lblErsterPlatz.Text = "";
            lblZweiterPlatz.Text = "";
            lblDritterPlatz.Text = "";
        }

        //Schaltflächemethoden
        private void btnBeenden_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnZuruecksetzen_Click(object sender, EventArgs e)
        {
            zuruecksetzen();
        }

        private void btnViertelFinale_1_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxSpiel_1, listBoxViertelFinaleSpiel_1);
            spielerZuRunde(listBoxSpiel_2, listBoxViertelFinaleSpiel_1);
        }

        private void btnViertelFinale_2_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxSpiel_3, listBoxViertelFinaleSpiel_2);
            spielerZuRunde(listBoxSpiel_4, listBoxViertelFinaleSpiel_2);
        }

        private void btnViertelFinale_3_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxSpiel_5, listBoxViertelFinaleSpiel_3);
            spielerZuRunde(listBoxSpiel_6, listBoxViertelFinaleSpiel_3);
        }

        private void btnHalbfinale_1_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxViertelFinaleSpiel_1, listBoxHalbfinaleSpiel_1);
        }

        private void btnHalbfinale_2_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxViertelFinaleSpiel_2, listBoxHalbfinaleSpiel_1);
        }

        private void btnHalbfinale_3_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxViertelFinaleSpiel_2, listBoxHalbfinaleSpiel_2);
        }

        private void btnHalbfinale_4_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxViertelFinaleSpiel_3, listBoxHalbfinaleSpiel_2);
        }

        private void btnFinale_Click(object sender, EventArgs e)
        {
            spielerZuRunde(listBoxHalbfinaleSpiel_1, listBoxFinalesSpiel);
            spielerZuRunde(listBoxHalbfinaleSpiel_2, listBoxFinalesSpiel);
        }

        private void btnErsterPlatz_Click(object sender, EventArgs e)
        {
            string spieler = platzierterSpieler(lblErsterPlatz);
            //Ausgabe
            if (spieler != "")
                lblErsterPlatz.Text = spieler;
        }

        private void btnZweiterPlatz_Click(object sender, EventArgs e)
        {
            string spieler = platzierterSpieler(lblZweiterPlatz);
            //Ausgabe
            if (spieler != "")
                lblZweiterPlatz.Text = spieler;
        }

        private void btnDritterPlatz_Click(object sender, EventArgs e)
        {
            string spieler = platzierterSpieler(lblDritterPlatz);
            //Ausgabe
            if (spieler != "")
                lblDritterPlatz.Text = spieler;
        }

        //Tastatur Schaltflächenmethoden zum Entfernen ausgewählter Spieler 
        private void listBoxViertelFinaleSpiel_1_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxViertelFinaleSpiel_1, e);
        }

        private void listBoxViertelFinaleSpiel_2_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxViertelFinaleSpiel_2, e);
        }

        private void listBoxViertelFinaleSpiel_3_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxViertelFinaleSpiel_3, e);
        }

        private void listBoxHalbfinaleSpiel_1_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxHalbfinaleSpiel_1, e);
        }

        private void listBoxHalbfinaleSpiel_2_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxHalbfinaleSpiel_2, e);
        }

        private void listBoxFinalesSpiel_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxFinalesSpiel, e);
        }

        private void listBoxSchueler_KeyDown(object sender, KeyEventArgs e)
        {
            spielerEntfernen(listBoxSchueler, e);
        }

        //Methoden
        private void btnZufall_Click(object sender, EventArgs e)
        {

            string[] spielerListe = new string[listBoxSchueler.Items.Count];

            for (int i = 0; i < spielerListe.Length; i++)
            {
                string name = listBoxSchueler.Items[new Random().Next(listBoxSchueler.Items.Count)].ToString();
                while (spielerListe.Contains(name))
                {
                    name = listBoxSchueler.Items[new Random().Next(listBoxSchueler.Items.Count)].ToString();
                }
                spielerListe[i] = name;
            }



            //Lokale Variablen
            double spiele = 6;
            double spieler = listBoxSchueler.Items.Count;
            int rest = (int)(spieler % spiele);

            string[][] nameZuSpiel = new string[(int)spiele][]; //Liste mit Anzahl der Spiele in 1. Dimenson und anzahl der Spieler in 2. Dimension

            
            for(int i = 0; i < spiele; i++)
            {
                int größe = (int)Math.Ceiling(spieler / spiele);
                //if (rest == 0)
                //{
                //    nameZuSpiel[i] = new string[größe];
                //}
                //else
                //{
                    if (i >= rest)
                    {
                        größe--;
                    }
                    nameZuSpiel[i] = new string[größe];
                //}
                Console.WriteLine("Key: " + i.ToString() + " Größe: " + größe.ToString());
            }
            int zähler = 0;

            for (int i = 0; i < nameZuSpiel.Length; i++)
            {
                for(int k = 0; k < nameZuSpiel[i].Length; k++)
                {
                    nameZuSpiel[i][k] = spielerListe[zähler];
                    zähler++;
                }
            }

            //Random zufall = new Random();

            ////Verarbeitung
            //for (int spiel = 0; spiel <= nameZuSpiel.GetUpperBound(0); spiel++) //Alle Felder der 1(0). Dimension durchgehen
            //{
            //    for (int spieler = 0; spieler <= nameZuSpiel.GetUpperBound(1); spieler++) //Alle Felder der 2(1). Dimension durchgehen
            //    {
            //        string name = uebrigeSpieler[zufall.Next(0, uebrigeSpieler.Count)]; //Zufälliger name
            //        nameZuSpiel[spiel, spieler] = name; //Name zu Spiel hinzufügen
            //        uebrigeSpieler.Remove(name); //Name aus übrigen Spielern entfernen

            //    }
            //}

            //Ausgabe
            listBoxSchueler.Items.Clear();

            foreach(string[] name in nameZuSpiel)
            {
                foreach(string test in name)
                {
                    print(test);
                }
            }

            for(int i = 0; i < nameZuSpiel.Length; i++)
            {
                print("----------------------------");
                for(int k = 0; k < nameZuSpiel[i].Length; k++)
                {
                    print(nameZuSpiel[i][k] + " I: " + i + " K: " + k);
                }
            }


            //for (int i = 0; i < nameZuSpiel.GetUpperBound(0); i++) //Alle Felder der 2(1). Dimension durchgehen
                //for(int )
            //{
            //    //Spieler in Spiele(Listboxen) hinzufügen
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[0][i]);
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[1][i]);
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[2][i]);
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[3][i]);
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[4][i]);
            //    listBoxSpiel_1.Items.Add(nameZuSpiel[5][i]);
            
        }

        private void print(object message)
        {
            Console.WriteLine(message);
        }

        private void spielerZuRunde(ListBox listBoxStart, ListBox listBoxZiel)
        {
            if (listBoxStart.SelectedIndices.Count == 0) //Abfrage ob Spieler ausgewählt sind
                return;

            foreach (int i in listBoxStart.SelectedIndices) //Alle ausgewählten Spieler werden durchgegangen
            {
                string spieler = listBoxStart.Items[i].ToString(); //Spielernamen definieren
                if (listBoxZiel.Items.Contains(spieler)) //Überprüft ob Spieler beriets im Spiel ist
                {
                    listBoxStart.ClearSelected(); //Auswahl wird zurückgesetzt
                    MessageBox.Show("Der Spieler " + spieler + " ist bereichts in diesem Spiel!", "Fehler!");
                    return;
                }
                listBoxZiel.Items.Add(spieler); //Name des ausgewählten Schülers zum Ziel hinzufügen
            }
            listBoxStart.ClearSelected(); //Auswahl wird zurückgesetzt

        }

        private void zuruecksetzen()
        {
            //Auszuwählende Spieler zurücksetzten
            listBoxSchueler.Items.Clear();
            foreach (string name in alleSpieler)
                listBoxSchueler.Items.Add(name);

            nichtAusgewaehlteSpieler = new List<string>(alleSpieler);

            //Achtelfinale Löschen
            listBoxSpiel_1.Items.Clear();
            listBoxSpiel_2.Items.Clear();
            listBoxSpiel_3.Items.Clear();
            listBoxSpiel_4.Items.Clear();
            listBoxSpiel_5.Items.Clear();
            listBoxSpiel_6.Items.Clear();

            //Viertelfinale Löschen
            listBoxViertelFinaleSpiel_1.Items.Clear();
            listBoxViertelFinaleSpiel_2.Items.Clear();
            listBoxViertelFinaleSpiel_3.Items.Clear();

            //Halbfinale Löschen
            listBoxHalbfinaleSpiel_1.Items.Clear();
            listBoxHalbfinaleSpiel_2.Items.Clear();

            //Finale Löschen
            listBoxFinalesSpiel.Items.Clear();
        }

        private void spielerEntfernen(ListBox listbox, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Delete || e.KeyValue == (char)Keys.Back) //Überprüft Gedrückte Taste
            {
                if (listbox.SelectedIndices.Count != 0) //Abfrage ob Spieler ausgewählt sind
                {
                    //Solange bis der Index 0 ist werden alle ausgewählten Indices gelöscht
                    while (listbox.SelectedItems.Count != 0)
                    {
                        listbox.Items.Remove(listbox.SelectedItems[0]);
                    }
                }
            }
        }

        private string platzierterSpieler(Label label)
        {
            //Lokale Variablen
            string ausgewaehlterSpieler = "";
            //Eingabe
            if (listBoxFinalesSpiel.SelectedItem != null)
                ausgewaehlterSpieler = listBoxFinalesSpiel.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Bitte wähle den Platzierten Spieler aus!", "Fehler");
                return "";
            }

            listBoxFinalesSpiel.ClearSelected();

            if (checkObSpielerPlatziert(ausgewaehlterSpieler, label))
            {
                MessageBox.Show("Dieser Spieler hat bereits einen anderen Platz!", "Fehler");
                return "";
            }

            //Rückgabe
            return ausgewaehlterSpieler;
        }

        private bool checkObSpielerPlatziert(String name, Label lblZiel)
        {
            return (name == lblErsterPlatz.Text && lblErsterPlatz != lblZiel) || (name == lblZweiterPlatz.Text && lblZweiterPlatz != lblZiel) || (name == lblDritterPlatz.Text && lblDritterPlatz != lblZiel);
        }

    }
}
