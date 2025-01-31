using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Matopeli
{
    public partial class Peli : Form
    {
        Pelilauta pelilauta = new Pelilauta();
        Mato mato = new Mato();

        private Point matoPaikka;
        private Point suunta;

        private System.Windows.Forms.Timer peliAjastin;


        public Peli()
        {
            InitializeComponent();

            pelilauta.LuoRistikko(this);

            mato.AsetaMadonAlku(7, 3);
            mato.AsetaGridLabel(pelilauta);
            mato.haeJokaToinen(pelilauta);
            mato.LuoMato();
            mato.LuoOmena();

            peliAjastin = new System.Windows.Forms.Timer();
            peliAjastin.Interval = 250;
            peliAjastin.Tick += PeliAjastin_Tick;
            peliAjastin.Start();
        }

        private void PeliAjastin_Tick(object sender, EventArgs e)
        {
            if (mato.matoElossa)
            {
                mato.LiikuJatkuvasti();
            }
            else
            {
                peliAjastin.Stop();
                DialogResult result = MessageBox.Show("H‰visit pelin", "Peli p‰‰ttyi", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void Peli_LiikutaMatoa(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                mato.madonSuunta = "N";
            }

            if (e.KeyCode == Keys.S)
            {
                mato.madonSuunta = "S";
            }

            if (e.KeyCode == Keys.D)
            {
                mato.madonSuunta = "E";
            }

            if (e.KeyCode == Keys.A)
            {
                mato.madonSuunta = "W";
            }
        }
    }
}
