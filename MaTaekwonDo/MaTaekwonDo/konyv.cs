using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaTaekwonDo
{
    public partial class konyv : Form
    {
        public tartalom t;
        private int catId;
        public konyv(int catId)
        {
            InitializeComponent();
            this.catId = catId;
        }
        #region Gombokkal megnyilo tabok
        private void buttonKep_Click(object sender, EventArgs e)
        {
            /*t = new tartalom();

            t.Show();
            t.megjelenitTab(24);
            this.Hide();*/
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonVizsgaA_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(21);
            this.Hide();*/
        }
        private void buttonSzotar_Click(object sender, EventArgs e)
        {
          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(23);
            this.Hide();*/
        }

        private void buttonJegyz_Click(object sender, EventArgs e)
        {
          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(22);
            this.Hide();*/
        }

        private void buttonRend_Click(object sender, EventArgs e)
        {
          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(20);
            this.Hide();*/
        }

        private void buttonTerem_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(19);
            this.Hide();*/
        }
        private void buttonFejl_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(18);
            this.Hide();*/
        }

        private void buttonTakt_Click(object sender, EventArgs e)
        {
          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(17);
            this.Hide();*/
        }

        private void buttonSzab_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(16);
            this.Hide();*/
        }

        private void buttonKuzdelem_Click(object sender, EventArgs e)
        {

          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(15);
            this.Hide();*/
        }

        private void buttonTortech_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(14);
            this.Hide();*/
        }

        private void buttonTor_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(13);
            this.Hide();*/
        }
        private void buttonSzabaly_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(12);
            this.Hide();*/
        }

        private void buttonAjanlas_Click(object sender, EventArgs e)
        {
            /*t = new tartalom();

            t.Show();
            t.megjelenitTab(0);
            this.Hide();*/
        }
        private void buttonMaTorten_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(3);
            this.Hide();*/
        }
        private void buttonTan_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(4);
            this.Hide();*/
        }

        private void buttonFormagy_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(11);
            this.Hide();*/
        }

        private void buttonMozg_Click(object sender, EventArgs e)
        {
            /*t = new tartalom();

            t.Show();
            t.megjelenitTab(6);
            this.Hide();*/
        }

        private void buttonElet_Click(object sender, EventArgs e)
        {
            /*t = new tartalom();

            t.Show();
            t.megjelenitTab(5);
            this.Hide();*/
        }

        private void buttonOnv_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(10);
            this.Hide();*/
        }

        private void buttonBaz_Click(object sender, EventArgs e)
        {
          /*  t = new tartalom();

            t.Show();
            t.megjelenitTab(7);
            this.Hide();*/
        }
        private void button14_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(9);
            this.Hide();*/
        }

        private void buttonEroelm_Click(object sender, EventArgs e)
        {
           /* t = new tartalom();

            t.Show();
            t.megjelenitTab(8);
            this.Hide();*/
        }

        #endregion

        private void buttonAjanlas_Click_1(object sender, EventArgs e)
        {
            t = new tartalom(catId);
            t.megjelenitTab(1);
            this.Hide();
            if (t.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                t.Dispose();
            }
        }

        private void buttonBev_Click_1(object sender, EventArgs e)
        {
            t = new tartalom(catId);
            t.megjelenitTab(2);
            this.Hide();
            if (t.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                t.Dispose();
            }
        }

        private void buttonTortent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonVissza_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSzotar_Click_1(object sender, EventArgs e)
        {
            t = new tartalom(catId);
            t.megjelenitTab(24);
            this.Hide();
            if (t.ShowDialog(this) == DialogResult.Cancel)
            {
                this.Show();
                t.Dispose();
            }
        }

        private void buttonMaTorten_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonTan_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonBaz_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonElet_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonMozg_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonEroelm_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonOnv_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonFormagy_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonSzabaly_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonKep_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonJegyz_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonVizsgaA_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonRend_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }

        private void buttonTerem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Jelenleg ez a tartalom még nincs kész, ezért nem is elérhető! Megértését köszönjük!");
        }
    }
}
