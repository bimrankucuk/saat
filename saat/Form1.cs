using System;
using System.Windows.Forms;

namespace saat
{
    public partial class Form1 : Form
    {
        //kronometre için tanımlandı
        int[] dizi1 = new int[4];
        //saat ve tarih değerleri için tanımlandı
        int[] dizi2 = new int[3];
        //zamanlayıcı için tanımlandı
        int[] dizi3 = new int[2];

        //kronometre için yapıldı
        void saat()
        {
           
            dizi1[0]++;
            if(dizi1[0]==59)
            {
                dizi1[1]++;
                dizi1[0] = 0;
                if (dizi1[1] == 59)
                {
                    dizi1[2]++;
                    dizi1[1] = 0;
                    if (dizi1[2] == 59)
                    {
                        dizi1[3]++;
                        dizi1[2] = 0;
                        if (dizi1[3] == 24)
                            dizi1[3] = 0;
                    }
                    
                }
            }
            label7.Text = string.Join(":", dizi1[3].ToString(), dizi1[2].ToString(), dizi1[1].ToString(), dizi1[0].ToString());


        }
        void zamanlayici()
        {

            dizi3[0]--;
            if (dizi3[0] == 0)
            {
                if (dizi3[1] == 0)
                {
                    timer3.Enabled = false;
                    comboBox3.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = false;
                    pictureBox2.Visible = true;
                }
                else
                {
                    dizi3[1]--;
                    dizi3[0] = 59;
                }
            }
            label12.Text = string.Join(":", dizi3[1].ToString(), dizi3[0].ToString());

        }
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //saat ve taih oluşturuldu
            DateTime zaman = DateTime.Now;
            
            //saat dizi ye aktarıldı
            dizi2[0] = zaman.Second;
            dizi2[1] = zaman.Minute;
            dizi2[2] = zaman.Hour;
            //label2 ve label5 e tarih yazdırıldı
            label2.Text = zaman.ToShortDateString();
            label6.Text = zaman.ToShortDateString();
            label9.Text = zaman.ToShortDateString();
            //dizi2 stringe değiştirildi ve saat label a yazdırılabilir
            label1.Text = string.Join(":", dizi2[2].ToString(), dizi2[1].ToString(), dizi2[0].ToString());
            label5.Text = string.Join(":", dizi2[2].ToString(), dizi2[1].ToString(), dizi2[0].ToString());
            label8.Text = string.Join(":", dizi2[2].ToString(), dizi2[1].ToString(), dizi2[0].ToString());
           
            // kurulan alarm ile saat kontrol ediliyor
            if (b == dizi2[1].ToString() && a == dizi2[2].ToString())
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;

            }



        }

        private void iptal_Click(object sender, EventArgs e)
        {
            kur.Enabled = true;
            comboBox2.Enabled = true;
            comboBox1.Enabled = true;
            iptal.Enabled = false;
            pictureBox1.Visible = false;
            a = Convert.ToString(dizi2[2] - 1);

        }
        string a, b;

       

        

       
        
        private void kaydet_Click(object sender, EventArgs e)
        {
            int c = 1;
            sıfırla.Enabled = true;
            timer2.Enabled = true;
            listBox1.Items.Add(label7.Text);
            temizle.Enabled = true;

        }

        private void sıfırla_Click(object sender, EventArgs e)
        {
            sıfırla.Enabled = false;
            timer2.Enabled = false;
            dizi1[0] = 0;
            dizi1[1] = 0;
            dizi1[2] = 0;
            dizi1[3] = 0;
            label7.Text = string.Join(":", dizi1[3].ToString(), dizi1[2].ToString(), dizi1[1].ToString(), dizi1[0].ToString());

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            saat();
            
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            temizle.Enabled = false;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox3.Enabled = false;
            button2.Enabled = true;
            timer3.Enabled = true;
            pictureBox2.Visible = false;
            dizi3[0] = 59;
            dizi3[1] = Convert.ToInt32(comboBox3.Text)-1;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            comboBox3.Enabled = true;
            button2.Enabled = false;
            timer3.Enabled = false;
            dizi3[0] = 0;
            dizi3[1] = 0;
           
            label12.Text = string.Join(":", dizi3[1].ToString(), dizi3[0].ToString());

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            zamanlayici();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void kur_Click(object sender, EventArgs e)
        {
            
            kur.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            iptal.Enabled = true;

            a = comboBox1.Text;
            b = comboBox2.Text;
        }
    }
}
