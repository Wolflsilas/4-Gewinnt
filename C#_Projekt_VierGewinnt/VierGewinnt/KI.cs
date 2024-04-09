using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace VierGewinnt
{
    public class KI : Spieler
    {
        private readonly Random rand = new();
        bool korrekt;
        int spalte, value_spalte = - 1, anz = 0; // Dient nur als Zähler, wie oft er versuchen soll etwas zu umgehen

        public void FindeZug(VierGewinnt spiel)
        {

            // kopiere das spielfeld:
            char[,] virtuellesFeld = spiel.spielfeld.Clone() as char[,];


            int FindeSiegSpalte(char spielfigur)
            {
                if (spiel.anzGesetzteSteine > 4)
                {
                    // Suche eine Spalte, mit der die neu gesetzte Spielfigur das Spiel beenden kann
                    for (int spalte = 0; spalte < spiel.anzSpalten; spalte++)
                    {
                        // suche das oberste freie Feld int spalte
                        int zeile = 0;
                        while (zeile < spiel.anzZeilen && spiel.spielfeld[zeile, spalte] == ' ')
                            zeile++;
                        zeile--;

                        if (zeile >= 0)
                        {   // Spalte ist frei
                            virtuellesFeld[zeile, spalte] = spielfigur; // Stein setzen
                            if (spiel.HatSpielGewonnen(zeile, spalte, virtuellesFeld))
                                return spalte; // Das ist die SiegSpalte
                            virtuellesFeld[zeile, spalte] = ' '; // Setzen des Steins zurücknehmen
                        }
                    }

                }
                    return -1; // Keine Siegspalte gefunden
            }

            // Versucht einen Sieg in zwei Zügen zu finden oder verhindern
            int ZweiZuegeSieg (char spielfigur)
            {
                if (spiel.anzGesetzteSteine >= 3)
                {
                    for (int spalte = 0; spalte < spiel.anzSpalten; spalte++)
                    {
                        // suche das oberste freie Feld int spalte
                        int zeile = 0;
                        while (zeile < spiel.anzZeilen && spiel.spielfeld[zeile, spalte] == ' ')
                            zeile++;
                        zeile--;

                        if (zeile >= 1)
                        {
                            // if verknüpfungen die für Horizontal und Diagonal in / \ Test Steine setzen und überprüfen ob sie damit gewinnen können

                            // Horizontal rechts
                            switch (zeile){
                                case 5: // prüft, ob zeile 5 oder < ist um die if Anweisung zu verändern
                                    if (spalte < spiel.anzSpalten - 1 && virtuellesFeld[zeile, spalte + 1] == ' ')
                                        if (horizontal_rechts() > 0)
                                            return value_spalte; // kann in 2 Zügen gewonnen werden
                                    break;

                                case < 5:
                                    if (spalte < spiel.anzSpalten - 1 && virtuellesFeld[zeile, spalte + 1] == ' ' && virtuellesFeld[zeile + 1, spalte + 1] != ' ')
                                        if (horizontal_rechts() > 0)
                                            return value_spalte;
                                    break;

                            }
                            int horizontal_rechts()
                            {
                                virtuellesFeld[zeile, spalte] = spielfigur;         // Setzt temporären Teststein 1
                                virtuellesFeld[zeile, spalte + 1] = spielfigur;     // Setzt temporären Teststein 2

                                if (spiel.HatSpielGewonnen(zeile, spalte + 1, virtuellesFeld))  // Überprüft ob mit den Temporären Teststeinen gewonnen werden kann
                                {
                                    virtuellesFeld[zeile, spalte] = ' ';
                                    virtuellesFeld[zeile, spalte + 1] = ' ';
                                    if (spalte < 5 && virtuellesFeld[zeile, spalte + 2] == spielfigur)
                                        value_spalte = spalte + 1;
                                    else
                                        value_spalte = spalte;
                                    return spalte;
                                }
                                virtuellesFeld[zeile, spalte] = ' ';
                                virtuellesFeld[zeile, spalte + 1] = ' ';
                                return -1;
                            }

                            // Diagonal rechts oben /
                            if (zeile > 0 && spalte < spiel.anzSpalten - 1 && virtuellesFeld[zeile - 1, spalte + 1] == ' ' && virtuellesFeld[zeile, spalte + 1] != ' ')
                            {
                                virtuellesFeld[zeile, spalte] = spielfigur;
                                virtuellesFeld[zeile - 1, spalte + 1] = spielfigur;

                                if (spiel.HatSpielGewonnen(zeile - 1, spalte + 1, virtuellesFeld))
                                {
                                    virtuellesFeld[zeile, spalte] = ' ';
                                    virtuellesFeld[zeile - 1, spalte + 1] = ' ';
                                    return spalte;
                                }
                                virtuellesFeld[zeile, spalte] = ' ';
                                virtuellesFeld[zeile - 1, spalte + 1] = ' ';
                            }

                            // Diagonal links unten /
                            if (zeile < spiel.anzZeilen - 1 && spalte > 0 && virtuellesFeld[zeile + 1, spalte - 1] == ' ' && virtuellesFeld[zeile, spalte - 1] != ' ')
                            {
                                virtuellesFeld[zeile, spalte] = spielfigur;
                                virtuellesFeld[zeile + 1, spalte - 1] = spielfigur;

                                if (spiel.HatSpielGewonnen(zeile + 1, spalte - 1, virtuellesFeld))
                                {
                                    virtuellesFeld[zeile, spalte] = ' ';
                                    virtuellesFeld[zeile + 1, spalte - 1] = ' ';
                                    return spalte;
                                }
                                virtuellesFeld[zeile, spalte] = ' ';
                                virtuellesFeld[zeile + 1, spalte - 1] = ' ';
                            }

                            // Diagonal rechts unten \
                            if (zeile < 4)
                            {
                                if (zeile < spiel.anzZeilen - 1 && spalte < spiel.anzSpalten - 1 && virtuellesFeld[zeile + 1, spalte + 1] == ' ' && virtuellesFeld[zeile + 2, spalte + 1] != ' ')
                                {
                                    virtuellesFeld[zeile, spalte] = spielfigur;
                                    virtuellesFeld[zeile + 1, spalte + 1] = spielfigur;

                                    if (spiel.HatSpielGewonnen(zeile + 1, spalte + 1, virtuellesFeld))
                                    {
                                        virtuellesFeld[zeile, spalte] = ' ';
                                        virtuellesFeld[zeile + 1, spalte + 1] = ' ';
                                        return spalte;
                                    }
                                    virtuellesFeld[zeile, spalte] = ' ';
                                    virtuellesFeld[zeile + 1, spalte + 1] = ' ';
                                }

                            }

                            // Diagonal links oben \
                            if (zeile > 0 && spalte > 0 && virtuellesFeld[zeile - 1, spalte - 1] == ' ' && virtuellesFeld[zeile, spalte - 1] != ' ')
                            {
                                virtuellesFeld[zeile, spalte] = spielfigur;
                                virtuellesFeld[zeile - 1, spalte - 1] = spielfigur;

                                if (spiel.HatSpielGewonnen(zeile - 1, spalte - 1, virtuellesFeld))
                                {
                                    virtuellesFeld[zeile, spalte] = ' ';
                                    virtuellesFeld[zeile - 1, spalte - 1] = ' ';
                                    return spalte;
                                }
                                virtuellesFeld[zeile, spalte] = ' ';
                                virtuellesFeld[zeile - 1, spalte - 1] = ' ';
                            }
                        }
                    }
                }
                return -1;
            }


            // versucht zuerst selbst zu Gewinnen
            spalte = FindeSiegSpalte('0');
            if (spalte >= 0)
            {
                spiel.aktSpalte = spalte;
                spiel.SetzeFigur(spalte, Color.Yellow);
                return;
            }

            // versucht Siegeszug vom Gegner zu verhindern
            spalte = FindeSiegSpalte('X');
            if (spalte >= 0)
            {
                spiel.aktSpalte = spalte;
                spiel.SetzeFigur(spalte, Color.Yellow);
                return;
            }

            // Versucht einen Gewinn in 2 Zügen zu verhindern
            spalte = ZweiZuegeSieg('X');
            if (spalte >= 0)
            {
                spiel.aktSpalte = spalte;
                spiel.SetzeFigur(spalte, Color.Yellow);
                return;
            }

            // Versucht selbst in 2 Zügen zu gewinnen
            spalte = ZweiZuegeSieg('0');
            if (spalte >= 0)
            {
                spiel.aktSpalte = spalte;
                spiel.SetzeFigur(spalte, Color.Yellow);
                return;
            }


            if (spiel.spielerAmZug == spiel.com)
            {
                do
                {
                    korrekt = false;
                    // spielt in eine zufällige Spalte in den ersten 4 Spielzügen in die Mitte des Spielfeldes
                    if (spiel.anzGesetzteSteine <= 4)
                        spalte = rand.Next(2, 5);
                    else // sonst nur zufällige Spalten
                        spalte = rand.Next(0, spiel.anzSpalten);

                    korrekt = (spiel.spielfeld[0, spalte] == ' ');
                    spiel.aktSpalte = spalte;
                    spiel.aktZeile = FindeZeile(spalte);

                    // wenn in die von der KI geworfene Spalte mit dem nächsten Zug von Person gewonnen werden kann
                    if (korrekt && spiel.aktZeile >= 0 && spiel.aktZeile < 5) 
                    {
                        if (anz > 4)
                            korrekt = true;
                        else if (spiel.HatSpielGewonnen(spiel.aktZeile + 1, spalte, null, 'X'))
                            korrekt = false;
                        else
                            anz++;
                    }
                } while (!korrekt);
                spiel.SetzeFigur(spalte, Color.Yellow);
            }

            int FindeZeile(int spalte)
            {
                // gibt die Zeile von der aktuellen Spalte zurück
                for (int i = 0; i < spiel.anzZeilen; i++)
                {
                    if (virtuellesFeld[i, spalte] != ' ')
                        if (i < 0)
                            return -1;
                        else
                            return i - 1;
                }
                return 5;
            }
        }
    }
}