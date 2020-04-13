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
        private Random random = new Random();

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

        private void btnZufall_Click(object sender, EventArgs e)
        {
            //Lokale Variablen
            int spieleAnzahl = 6; //Legt die Anzahl der Spiele fest
            double spielerAnzahl = listBoxSchueler.Items.Count; //Die gesamte Spieleranzahl im Wettkampf
            int rest = (int)(spielerAnzahl % spieleAnzahl); //Rest wird für gleichmäßige verteilung benötigt
            string[][] nameZuSpiel = new string[spieleAnzahl][];
            string[] spielerListe = zufaelligeSpielerListe();
            int zähler = 0;

            //Verarbeitung
            for (int i = 0; i < spieleAnzahl; i++) //Geht jedes Spiel durch und berechnet die Größe der Liste für eine gleichmäßige Verteilung
            {
                int spielerAnzahlSpiel = (int)Math.Ceiling(spielerAnzahl / spieleAnzahl); //Berechnet die Spieleranzahl pro Spiel, durch aufrunden

                if (rest == 0) //Bei gleichmäßigem Spieler-Spielverhältnis wird die Spielgröße dirket übergeben
                {
                    nameZuSpiel[i] = new string[spielerAnzahlSpiel];
                }
                else if (i >= rest) //wenn nicht wird anzahl der Spieler, für jedes weiteres Spiel, dass größer oder gleich des Rests ist um eines vermindert 
                {
                    spielerAnzahlSpiel--;
                }

                nameZuSpiel[i] = new string[spielerAnzahlSpiel]; //zuweisung der Spieleranzahlgröße pro Spiel
            }

            for (int i = 0; i < nameZuSpiel.Length; i++)
            {
                for (int k = 0; k < nameZuSpiel[i].Length; k++)
                {
                    nameZuSpiel[i][k] = spielerListe[zähler]; //Name eines Spielrs wird zum Spiel zugewiesen
                    zähler++; //Zähler für Spielerlisteneintrag
                }
            }

            //Ausgabe
            listBoxSchueler.Items.Clear();

            for (int i = 0; i < nameZuSpiel.Length; i++)
            {
                for (int k = 0; k < nameZuSpiel[i].Length; k++)
                {
                    //Spieler wird entsprechend dem Fall i zur entsprechenden Listbox zugeordnet
                    switch (i)
                    {
                        case 0:
                            listBoxSpiel_1.Items.Add(nameZuSpiel[0][k]);
                            break;
                        case 1:
                            listBoxSpiel_2.Items.Add(nameZuSpiel[1][k]);
                            break;
                        case 2:
                            listBoxSpiel_3.Items.Add(nameZuSpiel[2][k]);
                            break;
                        case 3:
                            listBoxSpiel_4.Items.Add(nameZuSpiel[3][k]);
                            break;
                        case 4:
                            listBoxSpiel_5.Items.Add(nameZuSpiel[4][k]);
                            break;
                        case 5:
                            listBoxSpiel_6.Items.Add(nameZuSpiel[5][k]);
                            break;
                        default:
                            MessageBox.Show("Zuweisungsfehler!"); //Bei einem Fehler wird dieses gemeldet
                            break;
                    }
                }
            }
        }

        //Methoden
        private string[] zufaelligeSpielerListe()
        {
            //Lokale Varbiablen
            int größe = listBoxSchueler.Items.Count; //Eingabe der Größe
            string[] spielerListe = new string[größe];

            //Verarbeitung
            for (int i = 0; i < spielerListe.Length; i++) //Jedes Element der Spielerliste wird einmal durchgegangen
            {
                string name = listBoxSchueler.Items[random.Next(größe)].ToString(); //Zufälliges Element aus der Spielerliste
                while (spielerListe.Contains(name)) //Überprüft ob das Element bereits einmal in der Liste ist
                {
                    name = listBoxSchueler.Items[random.Next(größe)].ToString(); //Wenn vorhanden, solange bis ein Neues nicht vorhandenes neues Element gefunden wurde
                }
                spielerListe[i] = name; //Übergabe des Elements in die Spielerliste
            }
            //Liste wird als Rückgabewert zurückgegeben
            return spielerListe;
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
