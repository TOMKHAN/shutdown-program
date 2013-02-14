using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShutdownProgram
{
    public partial class ShutdownApp : Form
    {
        public ShutdownApp()
        {
            InitializeComponent();
            statusnaLabela.Text = "Bok!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt1.Text.Trim().Length == 0 & txt2.Text.Trim().Length == 0)
                {
                    statusnaLabela.Text = "Greška: Niste zadali vrijeme u minutama ili satima!";
                    return;
                }
                else
                {
                    if (txt1.Text.Trim().Length != 0)
                    {
                        Provjera objekt = new Provjera();
                        bool provjera = objekt.sviNumeric(txt1.Text);
                        if (provjera == false)
                        {
                            statusnaLabela.Text = "Unesite samo brojeve!";
                        }
                        else
                        {
                            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\izvrsi.bat");
                            string vrijednost = txt1.Text;
                            int vri = Convert.ToInt32(vrijednost);
                            int vri1 = vri * 60 * 60;
                            string vrijednost1 = Convert.ToString(vri1);

                            file.WriteLine(@"shutdown -s -t " + vrijednost1);
                            file.Close();

                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = @"C:\izvrsi.bat";
                            proc.Start();
                            statusnaLabela.Text = "Obavljeno!";
                        }
                    }
                    else
                    {
                        Provjera objekt = new Provjera();
                        bool provjera = objekt.sviNumeric(txt2.Text);
                        if (provjera == false)
                        {
                            statusnaLabela.Text = "Unesite samo brojeve!";
                        }
                        else
                        {
                            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\izvrsi.bat");
                            string vrijednost = txt2.Text;
                            int vri = Convert.ToInt32(vrijednost);
                            int vri1 = vri * 60;
                            string vrijednost1 = Convert.ToString(vri1);
                            file.WriteLine(@"shutdown -s -t " + vrijednost1);
                            file.Close();

                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = @"C:\izvrsi.bat";
                            proc.Start();
                            statusnaLabela.Text = "Obavljeno!";
                        }
                    }
                }
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "NOOOOOOOOO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\izvrsi2.bat");
            string vrijednost = txt1.Text;
            file.WriteLine(@"shutdown -a");
            file.Close();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = @"C:\izvrsi2.bat";
            proc.Start();
        }

        private void napraviOvo(object sender, FormClosingEventArgs e)
        {
            File.Delete(@"C:\izvrsi.bat");
            File.Delete(@"C:\izvrsi2.bat");
        }

        private void txt1_Enter(object sender, EventArgs e)
        {
            if (txt2.Text.Trim().Length != 0)
            {
                txt2.Text = "";
            }
            txt2.Enabled = false;   
        }

        private void ShutdownApp_MouseClick(object sender, MouseEventArgs e)
        {
            txt2.Enabled = true;
            txt1.Enabled = true;
        }

        private void txt2_Enter(object sender, EventArgs e)
        {
            if (txt1.Text.Trim().Length != 0)
            {
                txt1.Text = "";
            }
            txt1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1.Text.Trim().Length == 0 & txt2.Text.Trim().Length == 0)
            {
                statusnaLabela.Text = "Greška: Niste zadali vrijeme u minutama ili satima!";
                return;
            }
            else
            {
                if (txt1.Text.Trim().Length != 0)
                {
                    Provjera objekt = new Provjera();
                    bool provjera = objekt.sviNumeric(txt1.Text);
                    if (provjera == false)
                    {
                        statusnaLabela.Text = "Unesite samo brojeve!";
                    }
                    else
                    {
                        string vrijednost = txt1.Text;
                        double vrijednost1 = Convert.ToDouble(vrijednost);
                        DateTime da = DateTime.Now.AddHours(vrijednost1);
                        string output = string.Format("{0:HH:mm:ss tt}", da.ToString());
                        string output1 = String.Format("{0:t}", output);
                        labela1.Text = "Gasi se " + output1 + ".";
                        statusnaLabela.Text = "Ok?";
                    }
                }
                else
                {
                    Provjera objekt = new Provjera();
                    bool provjera = objekt.sviNumeric(txt2.Text);
                    if (provjera == false)
                    {
                        statusnaLabela.Text = "Unesite samo brojeve!";
                    }
                    else
                    {
                        string vrijednost = txt2.Text;
                        double vrijednost1 = Convert.ToDouble(vrijednost);
                        DateTime oneMinuteFromNow = DateTime.Now.AddMinutes(vrijednost1);
                        string output = string.Format("{0:HH:mm:ss tt}", oneMinuteFromNow.ToString());
                        string output1 = String.Format("{0:t}", output);
                        labela1.Text = "Gasi se " + output1 + ".";
                        statusnaLabela.Text = "Ok?";
                    }
                }
            }
            
        }
    }
}
