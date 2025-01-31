using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matopeli
{
    internal class Pelilauta
    {
        private int riviMaara = 15;
        private int torniMaara = 17;
        private int cellSize = 50;

        public List<Label> jokaToinen = new List<Label>();
        public Label[,] gridLabel;

        public void LuoRistikko(Form form)
        {
            int luku = 0;
            int yOffset = 35;

            gridLabel = new Label[riviMaara, torniMaara];

            for (int i = 0; i < riviMaara; i++)
            {
                for (int j = 0; j < torniMaara; j++)
                {
                    var label = new Label();
                    label.Size = new Size(cellSize, cellSize);
                    label.Location = new Point(j * cellSize, i * cellSize + yOffset);
                    label.BorderStyle = BorderStyle.FixedSingle;

                    label.Text = luku.ToString();
                    label.Font = new Font("Arial", 1, FontStyle.Bold);

                    if (luku % 2 == 0)
                    {
                        label.BackColor = Color.FromArgb(0, 255, 0);
                        label.ForeColor = Color.FromArgb(0, 255, 0);
                        jokaToinen.Add(label);
                    }
                    else
                    {
                        label.BackColor = Color.FromArgb(0, 192, 0);
                        label.ForeColor = Color.FromArgb(0, 192, 0);
                    }

                    gridLabel[i, j] = label;
                    form.Controls.Add(label);
                    luku++;
                }
            }
        }
    }
}