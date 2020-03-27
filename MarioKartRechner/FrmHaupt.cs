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
    public partial class FrmHaupt : Form
    {
        //Globale Variablen
        private List<string> alleSpieler = new List<string>();
        private List<string> nichtAusgewaehlteSpieler = new List<string>();

        public FrmHaupt()
        {
            InitializeComponent();
        }

        //Laden der Form
        private void FrmHaupt_Load(object sender, EventArgs e)
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

        private void btnSpiel_1_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_1);
        }

        private void btnSpiel_2_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_2);

        }

        private void btnSpiel_3_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_3);
        }

        private void btnSpiel_4_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_4);
        }

        private void btnSpiel_5_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_5);
        }

        private void btnSpiel_6_Click(object sender, EventArgs e)
        {
            spielerZuSpiel(listBoxSpiel_6);
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
            //Lokale Variablen
            string ausgewaehlterSpieler = "";
            //Eingabe
            if (listBoxFinalesSpiel.SelectedItem != null)
                ausgewaehlterSpieler = listBoxFinalesSpiel.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Bitte wähle den 1. Platz aus!", "Fehler");
                return;
            }
                
            //Ausgabe
            lblErsterPlatz.Text = ausgewaehlterSpieler;
        }

        private void btnZweiterPlatz_Click(object sender, EventArgs e)
        {
            //Lokale Variablen
            string ausgewaehlterSpieler = "";
            //Eingabe
            if (listBoxFinalesSpiel.SelectedItem != null)
                ausgewaehlterSpieler = listBoxFinalesSpiel.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Bitte wähle den 2. Platz aus!", "Fehler");
                return;
            }
            //Ausgabe
            lblZweiterPlatz.Text = ausgewaehlterSpieler;
        }

        private void btnDritterPlatz_Click(object sender, EventArgs e)
        {
            //Lokale Variablen
            string ausgewaehlterSpieler = "";
            //Eingabe
            if (listBoxFinalesSpiel.SelectedItem != null)
                ausgewaehlterSpieler = listBoxFinalesSpiel.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Bitte wähle den 3. Platz aus!", "Fehler");
                return;
            }
            //Ausgabe
            lblDritterPlatz.Text = ausgewaehlterSpieler;
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

        //Methoden
        private void btnZufall_Click(object sender, EventArgs e)
        {
            //Alles zurücksetzen
            zuruecksetzen();

            //Lokale Variablen
            int spieleAnzahl = 6;
            List<string> uebrigeSpieler = new List<string>(alleSpieler);
            string[,] nameZuSpiel = new string[spieleAnzahl, uebrigeSpieler.Count / spieleAnzahl]; //Liste mit Anzahl der Spiele in 1. Dimenson und anzahl der Spieler in 2. Dimension
            Random zufall = new Random();

            //Verarbeitung
            for (int spiel = 0; spiel <= nameZuSpiel.GetUpperBound(0); spiel++) //Alle Felder der 1(0). Dimension durchgehen
            {
                for (int spieler = 0; spieler <= nameZuSpiel.GetUpperBound(1); spieler++) //Alle Felder der 2(1). Dimension durchgehen
                {
                    string name = uebrigeSpieler[zufall.Next(0, uebrigeSpieler.Count)]; //Zufälliger name
                    nameZuSpiel[spiel, spieler] = name; //Name zu Spiel hinzufügen
                    uebrigeSpieler.Remove(name); //Name aus übrigen Spielern entfernen

                }
            }

            //Ausgabe
            listBoxSchueler.Items.Clear();
            for (int i = 0; i < nameZuSpiel.GetUpperBound(1) + 1; i++) //Alle Felder der 2(1). Dimension durchgehen
            {
                //Spieler in Spiele(Listboxen) hinzufügen
                listBoxSpiel_1.Items.Add(nameZuSpiel[0, i]);
                listBoxSpiel_2.Items.Add(nameZuSpiel[1, i]);
                listBoxSpiel_3.Items.Add(nameZuSpiel[2, i]);
                listBoxSpiel_4.Items.Add(nameZuSpiel[3, i]);
                listBoxSpiel_5.Items.Add(nameZuSpiel[4, i]);
                listBoxSpiel_6.Items.Add(nameZuSpiel[5, i]);
            }
        }

        //Methoden
        private void spielerZuSpiel(ListBox listBoxZiel)
        {
            if (listBoxSchueler.SelectedIndices.Count == 0) //Abfrage ob Spieler ausgewählt sind
                return;

            //Lokale Variablen
            string[] ausgewaehlterSchueler = new string[1];

            //Verarbeitung
            if (listBoxZiel.Items.Count != 0) //Abfrage ob das listboxZiel Leer ist
            {
                foreach (string name in listBoxZiel.Items) //Hinzufügen der alten Namen aus dem Listboxziel zu den nichtausgewählten Schülern
                    nichtAusgewaehlteSpieler.Add(name);
            }

            listBoxZiel.Items.Clear(); //Ziel-Listbox alle Items entfernen
            Array.Resize(ref ausgewaehlterSchueler, listBoxSchueler.SelectedIndices.Count); //Anpassen der Liste auf Selektierte Spieler

            foreach (int i in listBoxSchueler.SelectedIndices) //Alle ausgewählten Spieler werden durchgegangen
            {
                string name = listBoxSchueler.Items[i].ToString(); //Name des ausgewählten Spieler
                ausgewaehlterSchueler[i] = name; //Name zu ausgewälte Schüler hinzufügen
                nichtAusgewaehlteSpieler.Remove(name); //Name aus auszuwählender Schülerliste entfernen
            }

            //Ausgabe
            foreach (string name in ausgewaehlterSchueler) //Ausgewählten Schüler zum listboxZiel hinzufügen
                listBoxZiel.Items.Add(name);

            listBoxSchueler.Items.Clear();
            foreach (string name in nichtAusgewaehlteSpieler) //Auszuwählende Schüler aktualisieren
                listBoxSchueler.Items.Add(name);
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
    }
}
