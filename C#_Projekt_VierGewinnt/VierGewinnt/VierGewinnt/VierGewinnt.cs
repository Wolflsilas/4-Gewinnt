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
        public int anz_Spielgzug = 0, aktSpalte = 0;

        KI AI = new KI();

        public string[,] spielfeld;

        public VierGewinnt()
        {
            InitializeComponent();
            // spielfeld instantiieren und alle Elemente mit ' ' belegen
            spielfeld = new string[anzZeilen, anzSpalten];
            for (int i = 0; i < spielfeld.GetLength(0); i++)
                for (int j = 0; j < spielfeld.GetLength(1); j++)
                    spielfeld[i, j] = " ";


            person = new Person()
            {
                name = "Spieler",
                spielfigur = "X"
            };

            com = new KI()
            {
                name = "KI",
                spielfigur = "0"
            };
            spielerAmZug = person;
        }


        public void Spielen()
        {
            if (spielerAmZug == com)
                AI.FindeZug(this);
            else
                spielerAmZug = person;
        }

        private void row1_Click(object sender, EventArgs e)
        {
            SetzeFigur(1, "rot");
            aktSpalte = 0;
        }

        private void row2_Click(object sender, EventArgs e)
        {
            aktSpalte = 1;
            SetzeFigur(2, "rot");
        }

        private void row3_Click(object sender, EventArgs e)
        {
            aktSpalte = 2;
            SetzeFigur(3, "rot");
        }

        private void row4_Click(object sender, EventArgs e)
        {
            aktSpalte = 3;
            SetzeFigur(4, "rot");
        }

        private void row5_Click(object sender, EventArgs e)
        {
            aktSpalte = 4;
            SetzeFigur(5, "rot");
        }

        private void row6_Click(object sender, EventArgs e)
        {
            aktSpalte = 5;
            SetzeFigur(6, "rot");
        }

        private void row7_Click(object sender, EventArgs e)
        {
            aktSpalte = 6;
            SetzeFigur(7, "rot");
        }

        public async void SetzeFigur(int reihe, string coulor)
        {
            // Feststellen welche Farbe er spielen muss
            Color color;
            if (coulor == "rot")
                color = Color.Red;
            else
                color = Color.Yellow;

            if (spielerAmZug == person)
                Disable_Button();
            

            // "Animiertes" fallen lassen der Spielsteine
            int zeilen = 0;
            if (reihe == 1)
            {
                while (zeilen < 6)
                {

                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row1_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row1_line2.BackColor = color;
                            row1_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row1_line3.BackColor = color;
                            row1_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row1_line4.BackColor = color;
                            row1_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row1_line5.BackColor = color;
                            row1_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row1_line6.BackColor = color;
                            row1_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else if (reihe == 2)
            {
                while (zeilen < 6)
                {

                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row2_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row2_line2.BackColor = color;
                            row2_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row2_line3.BackColor = color;
                            row2_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row2_line4.BackColor = color;
                            row2_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row2_line5.BackColor = color;
                            row2_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row2_line6.BackColor = color;
                            row2_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else if (reihe == 3)
            {
                while (zeilen < 6)
                {

                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row3_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row3_line2.BackColor = color;
                            row3_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row3_line3.BackColor = color;
                            row3_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row3_line4.BackColor = color;
                            row3_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row3_line5.BackColor = color;
                            row3_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row3_line6.BackColor = color;
                            row3_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else if (reihe == 4)
            {
                while (zeilen < 6)
                {
                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row4_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row4_line2.BackColor = color;
                            row4_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row4_line3.BackColor = color;
                            row4_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row4_line4.BackColor = color;
                            row4_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row4_line5.BackColor = color;
                            row4_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row4_line6.BackColor = color;
                            row4_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else if (reihe == 5)
            {
                while (zeilen < 6)
                {
                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row5_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row5_line2.BackColor = color;
                            row5_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row5_line3.BackColor = color;
                            row5_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row5_line4.BackColor = color;
                            row5_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row5_line5.BackColor = color;
                            row5_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row5_line6.BackColor = color;
                            row5_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else if (reihe == 6)
            {
                while (zeilen < 6)
                {
                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row6_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row6_line2.BackColor = color;
                            row6_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row6_line3.BackColor = color;
                            row6_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row6_line4.BackColor = color;
                            row6_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row6_line5.BackColor = color;
                            row6_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row6_line6.BackColor = color;
                            row6_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            else
            {
                while (zeilen < 6)
                {
                    if (CheckSetzen(zeilen))
                    {
                        if (zeilen + 1 == 1)
                        {
                            row7_line1.BackColor = color;
                        }
                        else if (zeilen + 1 == 2)
                        {
                            row7_line2.BackColor = color;
                            row7_line1.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 3)
                        {
                            row7_line3.BackColor = color;
                            row7_line2.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 4)
                        {
                            row7_line4.BackColor = color;
                            row7_line3.BackColor = Color.Silver;
                        }
                        else if (zeilen + 1 == 5)
                        {
                            row7_line5.BackColor = color;
                            row7_line4.BackColor = Color.Silver;
                        }
                        else
                        {
                            row7_line6.BackColor = color;
                            row7_line5.BackColor = Color.Silver;
                        }
                        // await Task.Delay(500);
                        zeilen++;
                    }
                    else
                        break;
                }
            }
            spielerAmZug = spielerAmZug == person ? com : person;
            anz_Spielgzug++;

            if (spielerAmZug == com)
                Disable_Button();
            else
                Enable_Button();

            Spielen();
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
            // Enabled die Buttons
            Button[] rows = { row1, row2, row3, row4, row5, row6, row7 };

            for (int i = 0; i < rows.Length; i++)
            {
                if (spielfeld[0, i] == " ")
                    rows[i].Enabled = true;
                else
                    rows[i].Enabled = false;
            }
        }

        private bool CheckSetzen(int zeilen)
        {
            // überprüft ob der nächste Spielstein platziert werden kann
            // TODO: Irgendein Bug ist noch in den if und else Anweisungen + Versuch der Label[,] Arrays
            
            if (zeilen <= 4)
            {
                //MessageBox.Show($"| {spielfeld[0, 0]}   | {spielfeld[0, 1]}   | {spielfeld[0, 2]}   | {spielfeld[0, 3]}   | {spielfeld[0, 4]}   | {spielfeld[0, 5]}   | {spielfeld[0, 6]}   |\n" +
                //                $"| {spielfeld[1, 0]}   | {spielfeld[1, 1]}   | {spielfeld[1, 2]}   | {spielfeld[1, 3]}   | {spielfeld[1, 4]}   | {spielfeld[1, 5]}   | {spielfeld[1, 6]}   |\n" +
                //                $"| {spielfeld[2, 0]}   | {spielfeld[2, 1]}   | {spielfeld[2, 2]}   | {spielfeld[2, 3]}   | {spielfeld[2, 4]}   | {spielfeld[2, 5]}   | {spielfeld[2, 6]}   |\n" +
                //                $"| {spielfeld[3, 0]}   | {spielfeld[3, 1]}   | {spielfeld[3, 2]}   | {spielfeld[3, 3]}   | {spielfeld[3, 4]}   | {spielfeld[3, 5]}   | {spielfeld[3, 6]}   |\n" +
                //                $"| {spielfeld[4, 0]}   | {spielfeld[4, 1]}   | {spielfeld[4, 2]}   | {spielfeld[4, 3]}   | {spielfeld[4, 4]}   | {spielfeld[4, 5]}   | {spielfeld[4, 6]}   |\n" +
                //                $"| {spielfeld[5, 0]}   | {spielfeld[5, 1]}   | {spielfeld[5, 2]}   | {spielfeld[5, 3]}   | {spielfeld[5, 4]}   | {spielfeld[5, 5]}   | {spielfeld[5, 6]}   |\n");
                if (spielfeld[zeilen + 1, aktSpalte] == " ")
                {
                    return true;
                }
                else if (spielfeld[0, aktSpalte] == " " && zeilen == 0)
                {
                    spielfeld[zeilen, aktSpalte] = spielerAmZug.spielfigur;
                    return true;
                }
                else if (spielfeld[zeilen, aktSpalte] == " ")
                {
                    spielfeld[zeilen, aktSpalte] = spielerAmZug.spielfigur;
                    return true;
                }
                else
                    return false;
            }
            else if (spielfeld[5, aktSpalte] == " ")
            {
                spielfeld[5, aktSpalte] = spielerAmZug.spielfigur;
                return true;
            }
            else
                return false;
            
        }
    }
}
