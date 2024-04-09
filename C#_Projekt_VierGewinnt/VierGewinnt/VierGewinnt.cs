using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace VierGewinnt
{
    public partial class VierGewinnt : UserControl
    {
        public Spieler person, com;
        public readonly int anzSpalten = 7, anzZeilen = 6;
        public Spieler spielerAmZug;
        public int anzGesetzteSteine = 0, aktSpalte = 0, aktZeile = 5;

        private bool gewonnen = false, timer = false;


        readonly KI AI = new();

        public char[,] spielfeld;

        public VierGewinnt()
        {
            InitializeComponent();
            // spielfeld instantiieren und alle Elemente mit ' ' belegen
            spielfeld = new char[anzZeilen, anzSpalten];
            for (int i = 0; i < spielfeld.GetLength(0); i++)
                for (int j = 0; j < spielfeld.GetLength(1); j++)
                    spielfeld[i, j] = ' ';


            person = new Spieler()
            {
                name = "Spieler",
                spielfigur = 'X'
            };

            com = new KI()
            {
                name = "KI",
                spielfigur = '0'
            };
            spielerAmZug = person;
        }


        public void Spielen()
        {
            // Ruft entweder auf, dass die KI am Zug ist oder der Spieler selbst
            if (spielerAmZug == com)
                AI.FindeZug(this);
        }

        private void Row1_Click(object sender, EventArgs e)
        {
            aktSpalte = 0;
            SetzeFigur(0, Color.Red);
        }

        private void Row2_Click(object sender, EventArgs e)
        {
            aktSpalte = 1;
            SetzeFigur(1, Color.Red);
        }

        private void Row3_Click(object sender, EventArgs e)
        {
            aktSpalte = 2;
            SetzeFigur(2, Color.Red);
        }

        private void Row4_Click(object sender, EventArgs e)
        {
            aktSpalte = 3;
            SetzeFigur(3, Color.Red);
        }

        private void Row5_Click(object sender, EventArgs e)
        {
            aktSpalte = 4;
            SetzeFigur(4, Color.Red);
        }

        private void Row6_Click(object sender, EventArgs e)
        {
            aktSpalte = 5;
            SetzeFigur(5, Color.Red);
        }

        private void Row7_Click(object sender, EventArgs e)
        {
            aktSpalte = 6;
            SetzeFigur(6, Color.Red);
        }

        public async void SetzeFigur(int reihe, Color farbe)
        {
            anzGesetzteSteine++;
            txt_anzZug.Text = anzGesetzteSteine.ToString();

            if (spielerAmZug == person)
                Disable_Button();


            // "Animiertes" fallen lassen der Spielsteine
            int zeilen = 0;

            timer = false;

            while (zeilen < 6)
            {
                if (timer)
                    break;
                if (zeilen != 0)
                    await Task.Delay(500);
                Drop();
                zeilen++;
            }

            void Drop()
            {
                // festlegen, in welcher Spalte der Stein "fallen" gelassen wird
                switch (reihe)
                {
                    case 0:
                        SetzeReihe(row1_line1, row1_line2, row1_line3, row1_line4, row1_line5, row1_line6);
                        break;
                    case 1:
                        SetzeReihe(row2_line1, row2_line2, row2_line3, row2_line4, row2_line5, row2_line6);
                        break;
                    case 2:
                        SetzeReihe(row3_line1, row3_line2, row3_line3, row3_line4, row3_line5, row3_line6);
                        break;
                    case 3:
                        SetzeReihe(row4_line1, row4_line2, row4_line3, row4_line4, row4_line5, row4_line6);
                        break;
                    case 4:
                        SetzeReihe(row5_line1, row5_line2, row5_line3, row5_line4, row5_line5, row5_line6);
                        break;
                    case 5:
                        SetzeReihe(row6_line1, row6_line2, row6_line3, row6_line4, row6_line5, row6_line6);
                        break;
                    default:
                        SetzeReihe(row7_line1, row7_line2, row7_line3, row7_line4, row7_line5, row7_line6);
                        break;
                }
            }

            void SetzeReihe(Control line1, Control line2, Control line3, Control line4, Control line5, Control line6)
            {
                // "fallen" lassen, der Spielsteine für die Richtigen Zeilen
                if (CheckSetzen(zeilen))
                {
                    switch (zeilen)
                    {
                        case 0:
                            line1.BackColor = farbe;
                            break;
                        case 1:
                            line2.BackColor = farbe;
                            line1.BackColor = Color.Silver;
                            break;
                        case 2:
                            line3.BackColor = farbe;
                            line2.BackColor = Color.Silver;
                            break;
                        case 3:
                            line4.BackColor = farbe;
                            line3.BackColor = Color.Silver;
                            break;
                        case 4:
                            line5.BackColor = farbe;
                            line4.BackColor = Color.Silver;
                            break;
                        default:
                            line6.BackColor = farbe;
                            line5.BackColor = Color.Silver;
                            break;
                    }
                }
                else
                    timer = true;
            }

            if (HatSpielGewonnen(aktZeile, aktSpalte))
                Stop();

            Txt_Ausgabe();

            spielerAmZug = spielerAmZug == person ? com : person;   // wechselt spielerAmZug

            if (gewonnen)
                spielerAmZug = null;

            if (spielerAmZug == com)
                Disable_Button();
            else if (spielerAmZug == person)
                Enable_Button();


            Spielen();  // Das Spiel wird fortgesetzt
        }

        private void Stop()
        {
            // Die Methode sorgt dafür, dass nicht weitergespielt werden kann
            gewonnen = true;
            Disable_Button();
        }

        private void Btn_beenden_Click(object sender, EventArgs e)
        {
            // Damit wird das Programm beendet
            Application.Exit();
        }

        private void Btn_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public void Disable_Button()
        {
            // Disabled die Buttons
            row1.Enabled = false;
            row2.Enabled = false;
            row3.Enabled = false;
            row4.Enabled = false;
            row5.Enabled = false;
            row6.Enabled = false;
            row7.Enabled = false;
        }

        public void Enable_Button()
        {
            // Enabled die Buttons (aber nur die, wo das oberste Element noch frei ist)
            Button[] rows = { row1, row2, row3, row4, row5, row6, row7 };

            for (int i = 0; i < rows.Length; i++)
            {
                if (spielfeld[0, i] == ' ')
                    rows[i].Enabled = true;
                else
                    rows[i].Enabled = false;
            }
        }

        private bool CheckSetzen(int zeilen)
        {
            // überprüft ob der nächste Spielstein platziert werden kann
            if (zeilen <= 4)
            {
                if (spielfeld[zeilen + 1, aktSpalte] == ' ')
                    return true;
                else if (spielfeld[0, aktSpalte] == ' ' && zeilen == 0)
                {
                    spielfeld[zeilen, aktSpalte] = spielerAmZug.spielfigur;
                    aktZeile = zeilen;
                    return true;
                }
                else if (spielfeld[zeilen, aktSpalte] == ' ')
                {
                    spielfeld[zeilen, aktSpalte] = spielerAmZug.spielfigur;
                    aktZeile = zeilen;
                    return true;
                }
                else
                    return false;
            }
            else if (spielfeld[5, aktSpalte] == ' ')
            {
                spielfeld[5, aktSpalte] = spielerAmZug.spielfigur;
                aktZeile = zeilen;
                return true;
            }
            else
                return false;
        }

        public bool HatSpielGewonnen(int zeile, int spalte, char[,] virtuellesSpielfeld = null, char? spielstein = null)
        {
            // ermittle im Feld die Anzahl der an Position [zeile, spalte] angrenzenden
            // mit stein übereinstimmenden Steine. Sind es mindestens vier gleiche, dann
            // liefere true zurück, ansonsten false. Mache das in folgende Richtungen:

            char[,] feld = virtuellesSpielfeld ?? spielfeld;
            char stein = (char)((spielstein == null) ? feld[zeile, spalte] : spielstein);
            int anz = 1;

            // horizontal nach rechts und links:
            for (int j = spalte + 1; anz < 4 && j < anzSpalten && feld[zeile, j] == stein; j++)
                anz++;

            for (int j = spalte - 1; anz < 4 && j >= 0 && feld[zeile, j] == stein; j--)
                anz++;

            if (anz >= 4)
                return true;

            // vertikal nach unten:
            anz = 1;

            for (int i = zeile + 1; anz < 4 && i < anzZeilen && feld[i, spalte] == stein; i++)
                anz++;

            if (anz >= 4)
                return true;


            // Diagonale rechts oben nach links unten:
            anz = 1;

            // nach rechts oben
            for (int i = zeile + 1, j = spalte - 1; anz < 4 && i < anzZeilen && j >= 0 && feld[i, j] == stein; i++, j--)
                anz++;

            // nach links unten
            for (int i = zeile - 1, j = spalte + 1; anz < 4 && i >= 0 && j < anzSpalten && feld[i, j] == stein; i--, j++)
                anz++;

            if (anz >= 4)
                return true;


            // Diagonale links oben nach rechts unten:
            anz = 1;

            // nach links oben
            for (int i = zeile - 1, j = spalte - 1; anz < 4 && i >= 0 && j >= 0 && feld[i, j] == stein; i--, j--)
                anz++;

            for (int i = zeile + 1, j = spalte + 1; anz < 4 && i < anzZeilen && j < anzSpalten && feld[i, j] == stein; i++, j++)
                anz++;

            if (anz >= 4)
                return true;

            return false;
        }

        private void Txt_Ausgabe()
        {
            // Ausgabe, wer am Zug ist und/oder wer gewonnen hat
            if (gewonnen)
                if (spielerAmZug == person)
                    txt_info.Text = "Du hat das Spiel gewonnen.";
                else
                    txt_info.Text = "KI hat das Spiel gewonnen.";
            else
                if (spielerAmZug != person)
                    txt_info.Text = "Du bist ist am Zug.";
                else
                    txt_info.Text = "KI ist am Zug.";
        }
    }
}