using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VierGewinnt
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VierGewinnt spiel = new()
            {
                person = new Spieler()
                {
                    name = "Spieler",
                    spielfigur = 'X'
                },

                com = new KI()
                {
                    name = "KI",
                    spielfigur = '0'
                }
            };

            spiel.Spielen();

            Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
