using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VierGewinnt
{
    public class KI : Spieler
    {
        private Random rand = new Random();
        bool korrekt = false;
        int spalte;

        public void FindeZug(VierGewinnt spiel)
        {
            if (spiel.spielerAmZug == spiel.com) {
                do
                {
                    // spielt in eine zufällige Spalte
                    spalte = rand.Next(1, spiel.anzSpalten);
                    spiel.aktSpalte = spalte - 1;
                    if (spiel.spielfeld[0, spiel.aktSpalte] == " ")
                        korrekt = true;
                } while (!korrekt);
                spiel.SetzeFigur(spalte, "gelb");
            }
        }
    }
}
