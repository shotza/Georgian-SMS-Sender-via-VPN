using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
//by Shota Abzhandadze
namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gagzavna_Click(object sender, EventArgs e)
        {

            SubmitData();
        }
        private void SubmitData()
        {
            try
            {
                string a = nomeri.Text;
                string[] lst = a.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string b = textisveli.Text;

                WebRequest request = WebRequest.Create("http://YOURADDRESS/mt/oneway?username=YOURUSERNAME&password=YOURPASSWORD&client_id=YOURCLIENTID&service_id=YOURSERVICEID&to=" + a + "&text=" + b);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-unlencoded";

                Stream stream = request.GetRequestStream();
                stream.Close();

                WebResponse response = request.GetResponse();
                stream = response.GetResponseStream();

                StreamReader sr = new StreamReader(stream);
                MessageBox.Show(sr.ReadToEnd());

                sr.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void textisveli_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Shota Abzhandadze");
        }
    }
}
