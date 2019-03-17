using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace MaTaekwonDo
{
    public partial class nevjegy : Form
    {
        public nevjegy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            labelTelSzam.Text = "+36 20 275-4112";
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            kuldesLevelet("tari.lilla2@gmail.com");
            DialogResult dialog = MessageBox.Show(this, "Sikeres küldés", "Info", MessageBoxButtons.OK);
            if (dialog == DialogResult.OK)
            {
                this.Close();
            }

        }
        /// <summary>
        /// Egy megadott email-ről (matkdkarbantarto@gmail.com) küld üzenetet
        /// A feladónál mindenképpen meg kell adni egy email címet vagy nevet, de nem arról fog a levél érkezni
        /// Az egyszerűség kedvéért azért is érkezik egy email címről, mert a host gmail-es fiókokat támogat.
        /// </summary>
        /// <param name="cimzett"></param>
        public void kuldesLevelet(string cimzett)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(cimzett);
            mail.To.Add("tari.lilla2@gmail.com");
            mail.From = new MailAddress("matkdkarbantarto@gmail.com");
            mail.Subject = textBoxTargy.Text;

            mail.Body = "A feladó:"+textBoxFelado.Text+"\n Tárgy:"+textBoxUzenet.Text;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; 
            smtp.Credentials = new System.Net.NetworkCredential
                 ("matkdkarbantarto@gmail.com", "123asd456FGH"); 
            smtp.Port = 587;

            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
