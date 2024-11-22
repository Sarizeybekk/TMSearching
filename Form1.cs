using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label7.Text = string.Empty;
            label8.Text = string.Empty;
            label9.Text = string.Empty;
            label10.Text = string.Empty;
        }
        void bulYazdir(int k,char[] f)
        {
            label10.Text = string.Empty;
            for (int a = 0; a < k; a++)
                label10.Text = label10.Text + f[a];
                label10.Text = label10.Text + " Bulundu ";
        }
        List<TextBox> serit1 = new List<TextBox>();
        List<TextBox> serit2 = new List<TextBox>();

        private void button1_Click(object sender, EventArgs e)//çalıştır butonumuz
        {
            int blnKSay = 0;//bulunan karaktersayısı
            string bos = "0";
            string Kaynak = txtKaynak.Text.ToString();//gelen veriler degiişkene atanır.
            string Aranan = txtAranan.Text.ToString();//
            Kaynak = Kaynak.Insert(0, bos);
            Kaynak = Kaynak.Insert(Kaynak.Length, bos);
            char[] serit = Kaynak.ToCharArray();//gelenler char array dizisine aktarılır.
            char[] ara = Aranan.ToCharArray();
            for (int j=0; j <Kaynak.Length; j++)
            {
                var kutu1 = new TextBox();
                kutu1.Size = new Size(20, 20);
                kutu1.Location = new Point(10 + j * 25, 190);
                kutu1.Name = "Username" + j;
                kutu1.Tag = "Dinamik";
                kutu1.Text = serit[j].ToString();
                Controls.Add(kutu1);
                serit1.Add(kutu1);
            }
            for (int l = 0; l < Aranan.Length; l++)
            {
                var kutu2 = new TextBox();
                kutu2.Size = new Size(20, 20);
                kutu2.Location = new Point(10 + l * 25, 110);
                kutu2.Name = "Username" + l;
                kutu2.Tag = "Dinamik";
                kutu2.Text = ara[l].ToString();
                Controls.Add(kutu2);
                serit2.Add(kutu2);
            }
            int y = 0;
            for (int i = 0; i < Aranan.Length; i++)
            {
                label7.Text = i + " Aşama " + Aranan[i] + "aranıyor...";
                while (y<Kaynak.Length)
                {
                    serit1[y].BackColor = Color.DeepPink;
                    label8.Text = "arama başladı" + y + "Karaktere bakılıyor";
                    if (serit[y]==ara[i])
                    {
                        blnKSay++;
                        label10.Text = "";
                        bulYazdir(blnKSay, ara);
                        label8.Text = "q" + i;
                        if (blnKSay==Aranan.Length)
                        {
                            serit1[y].BackColor = Color.Red;
                            serit2[i].BackColor = Color.Red;
                            label8.Text = "arama tamamlandı string bulundu";
                            label7.Text = "arama tamamlandı";
                            MessageBox.Show("kelime bulundu");
                            i = Aranan.Length;
                            y = Kaynak.Length;
                            break;
                        }
                        else
                        {
                            serit1[y].BackColor = Color.Red;
                            serit2[i].BackColor = Color.Red;
                            MessageBox.Show(ara[i] + "karakter bulundu");
                            label7.Text = blnKSay + "bulundu bir sonraki karaktere geçilir";
                            label10.Text = "";
                            bulYazdir(blnKSay, ara);
                            y++;
                            break;
                        }
                    }
                    else if (serit[y].ToString()==bos && y>0)
                    {
                        label8.Text = "bulunamadı pozisyon";
                        label7.Text = "arama taamlandı";
                        i = Aranan.Length;
                        y = Kaynak.Length;
                        break;
                    }
                    else
                    {
                        label8.Text = ara[i] + "bulunamadı";
                        y++;
                        i = -1;
                        label9.Text = "";
                        label10.Text = "";
                        break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//exit butonu
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)//reset butonu
        {
            foreach (var textBox in serit1)
            {
                if (textBox.Tag.ToString() == "Dinamik")
                    textBox.Dispose();
            }
            serit2.Clear();
            txtKaynak.Text = string.Empty;
            txtAranan.Text = string.Empty;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtAranan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
