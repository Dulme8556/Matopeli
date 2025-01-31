using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matopeli
{
    internal class Mato
    {
        int madonPituus = 1;
        int madonNopeus = 1;
        public string madonSuunta = "E";
        public bool matoElossa = true;
        bool virheIlmoitettu = false;


        Point madonPaa = new Point();
        Point omenanSijainti = new Point();

        List<Point> matoRuudut = new List<Point>();
        List<Label> Vaaleat = new List<Label>();
        private Label[,] gridLabel;

        public void AsetaGridLabel(Pelilauta pelilauta)
        {
            gridLabel = pelilauta.gridLabel;
        }

        public void haeJokaToinen(Pelilauta pelilauta)
        {
            Vaaleat = pelilauta.jokaToinen;
        }

        public void AsetaMadonAlku(int X, int Y)
        {
            madonPaa.X = X;
            madonPaa.Y = Y;
        }

        public void LuoMato()
        {
            Point piste = new Point(madonPaa.X,madonPaa.Y);
            matoRuudut.Add(piste);

            PaivitaMato();
        }

        public void LuoOmena()
        {
            Random random = new Random();
            int rivi = random.Next(0, 15);
            int torni = random.Next(0, 17);

            omenanSijainti.X = rivi;
            omenanSijainti.Y = torni;

            if (matoRuudut.Contains(omenanSijainti))
            {
                LuoOmena();
            }

            else
            {
                gridLabel[rivi, torni].BackColor = Color.Red;
            }
        }

        public void LiikuYlos()
        {
            Point piste = new Point(madonPaa.X - 1, madonPaa.Y);
            matoRuudut.Insert(0, piste);
            madonPaa.X--;

            PaivitaLista(madonPaa);
        }

        public void LiikuAlas()
        {
            Point piste = new Point(madonPaa.X + 1, madonPaa.Y);
            matoRuudut.Insert(0, piste);
            madonPaa.X++;

            PaivitaLista(madonPaa);
        }

        public void LiikuOikea()
        {
            Point piste = new Point(madonPaa.X, madonPaa.Y + 1);
            matoRuudut.Insert(0, piste);
            madonPaa.Y++;

            PaivitaLista(madonPaa);
        }

        public void LiikuVasen()
        {
            Point piste = new Point(madonPaa.X, madonPaa.Y - 1);
            matoRuudut.Insert(0, piste);
            madonPaa.Y--;

            PaivitaLista(madonPaa);
        }

        public void PaivitaLista(Point piste)
        {
            try
            {
                if (matoRuudut.Count > madonPituus)
                {
                    Point poistettava = matoRuudut.Last();
                    Label labelPoistettava = gridLabel[poistettava.X, poistettava.Y];

                    if (Vaaleat.Contains(labelPoistettava))
                    {
                        labelPoistettava.BackColor = Color.FromArgb(0, 255, 0);
                        labelPoistettava.ForeColor = Color.FromArgb(0, 255, 0);
                    }
                    else
                    {
                        labelPoistettava.BackColor = Color.FromArgb(0, 192, 0);
                        labelPoistettava.ForeColor = Color.FromArgb(0, 192, 0);
                    }

                    matoRuudut.RemoveAt(matoRuudut.Count - 1);
                    PaivitaMato();
                }
            }
            catch
            {
                HavisitPelin();
            }
        }

        public void PaivitaMato()
        {
            try
            {
                foreach (Point p in matoRuudut)
                {
                    if (!virheIlmoitettu && matoRuudut.Count(point => point == madonPaa) > 1)
                    {
                        virheIlmoitettu = true;
                        HavisitPelin();
                        MessageBox.Show("Madon pää osuu itseensä!");
                    }
                    gridLabel[p.X, p.Y].BackColor = Color.Black;
                    gridLabel[p.X, p.Y].ForeColor = Color.Black;
                }

                if (madonPaa == omenanSijainti)
                {
                    SyoOmena();
                }
            }
            catch
            {
                HavisitPelin();
            }
        }

        public void SyoOmena()
        {
            madonPituus++;
            LuoOmena();
        }

        public void LiikuJatkuvasti()
        {
            if (madonSuunta == "N")
            {
                LiikuYlos();
            }

            if (madonSuunta == "S")
            {
                LiikuAlas();
            }

            if (madonSuunta == "E")
            {
                LiikuOikea();
            }

            if (madonSuunta == "W")
            {
                LiikuVasen();
            }

            PaivitaMato();
            PaivitaLista(madonPaa);
        }

        public void HavisitPelin()
        {
            matoElossa = false;
        }
    }
}