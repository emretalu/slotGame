using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace slotGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int[] timers = new int[3];

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lblKalan.Text) > 0)
                {
                    lblKalan.Text = (Convert.ToInt32(lblKalan.Text) - 1).ToString();
                    timer1.Interval = 100;
                    timer2.Interval = 250;
                    timer3.Interval = 400;
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    timer4.Start();
                    zorlukToolStripMenuItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Jeton atın.");
                }
            }
            catch (OverflowException oex)
            {
                MessageBox.Show("çok büyük bir değer girişi yapıldı.\n" + oex.Message);
            }
            catch (Exception genelHata)
            {
                MessageBox.Show("Hata Oluştu.\n" + genelHata.Message);
            }
        }

        int zorluk = 5;

        private void kolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zorluk = 3;
            ortaToolStripMenuItem.Checked = false;
            zorToolStripMenuItem.Checked = false;
        }
        private void ortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zorluk = 5;
            kolayToolStripMenuItem.Checked = false;
            zorToolStripMenuItem.Checked = false;
        }

        private void zorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zorluk = 10;
            kolayToolStripMenuItem.Checked = false;
            ortaToolStripMenuItem.Checked = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timers[0] = rnd.Next(zorluk);
            pictureBox1.Image = imgList1.Images[timers[0]];
            timer1.Interval += 60;
            if (timer1.Interval >= 1000) 
            {
                timer1.Stop();
            }           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timers[1] = rnd.Next(zorluk);
            pictureBox2.Image = imgList1.Images[timers[1]];
            timer2.Interval += 50;
            if (timer2.Interval >= 1000)
            {
                timer2.Stop();
            }   
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timers[2] = rnd.Next(zorluk);
            pictureBox3.Image = imgList1.Images[timers[2]];
            timer3.Interval += 40;
            if (timer3.Interval >= 1000)
            {
                timer3.Stop();
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int sayi = Convert.ToInt32(numericUpDown1.Value.ToString());
                int hesap = Convert.ToInt32(lblHesap.Text);
                int kalan = Convert.ToInt32(lblKalan.Text);
                if (hesap >= sayi * 2)
                {
                    lblKalan.Text = (kalan + sayi).ToString();
                    lblHesap.Text = (hesap - sayi * 2).ToString();
                    numericUpDown1.Value = 0;
                }
                else
                {
                    MessageBox.Show("O kadar jeton alacak paran yok.");
                }
            }
            catch (OverflowException oex)
            {
                MessageBox.Show("çok büyük bir değer girişi yapıldı.\n" + oex.Message);
            }
            catch (Exception genelHata)
            {
                MessageBox.Show("Hata Oluştu.\n" + genelHata.Message);
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = timer3.Interval;
                if (timer3.Interval >= 1000)
                {
                    zorlukToolStripMenuItem.Enabled = true;
                    button1.Enabled = true;
                    timer4.Stop();
                    if (timers[0] == timers[1] && timers[1] == timers[2])
                    {
                        int kazan = 0;
                        if (timers[0] == 6)
                        {
                            kazan = zorluk * 10;
                        }
                        else
                        {
                            kazan = zorluk * 5;
                        }
                        lblHesap.Text = (Convert.ToInt32(lblHesap.Text) + kazan).ToString();
                        MessageBox.Show(kazan.ToString() + " TL kazandınız.");
                    }
                    else if (timers[0] == timers[1])
                    {
                        lblHesap.Text = (Convert.ToInt32(lblHesap.Text) + zorluk * 3).ToString();
                        MessageBox.Show((zorluk * 3).ToString() + " TL kazandınız.");
                    }
                    else if (timers[1] == timers[2])
                    {
                        lblHesap.Text = (Convert.ToInt32(lblHesap.Text) + zorluk * 3).ToString();
                        MessageBox.Show((zorluk * 3).ToString() + " TL kazandınız.");
                    }
                    else if (timers[0] == timers[2])
                    {
                        lblHesap.Text = (Convert.ToInt32(lblHesap.Text) + zorluk * 3).ToString();
                        MessageBox.Show((zorluk * 3).ToString() + " TL kazandınız.");
                    }
                    else
                    {
                        MessageBox.Show("Bugün şanslı gününüzde değilsiniz galiba :)");
                    }
                }
            }
            catch (Exception genelHata)
            {
                MessageBox.Show("Hata Oluştu.\n" + genelHata.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Oyundan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Yine bekleriz :D");
                Application.Exit();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Oyunu yeniden başlatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
