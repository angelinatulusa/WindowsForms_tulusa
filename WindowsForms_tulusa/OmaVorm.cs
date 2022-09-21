using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_tulusa
{
    public class OmaVorm :Form
    {
        public OmaVorm() { }
        RadioButton nupp1, nupp2;//радиокнопки для выбора песни
        public OmaVorm(string Pealkiri, string Nupp, string Fail) 
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text=Nupp,
                Location=new System.Drawing.Point(50,50),
                Size=new System.Drawing.Size(100,50),
                BackColor=System.Drawing.Color.LightSteelBlue,
                
            };
            nupp.Click += Nupp_Click;
            Label failnimi = new Label
            {
                Text= Fail,
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(150, 50),
                BackColor = System.Drawing.Color.LightSkyBlue,
            };
            nupp1 = new RadioButton//радиокнопка с текстом mixkit, её расположение, размер и цвет фона
            {
                Text="mixkit",
                Location=new System.Drawing.Point(50,200),
                Size=new System.Drawing.Size(100,20),
                BackColor= System.Drawing.Color.LightCyan,
            };
            nupp2 = new RadioButton//радиокнопка с текстом birds, её расположение, размер и цвет фона
            {
                Text = "birds",
                Location = new System.Drawing.Point(150, 200),
                Size = new System.Drawing.Size(100, 20),
                BackColor = System.Drawing.Color.LightCyan,
            };
            this.Controls.Add(nupp);
            this.Controls.Add(failnimi);
            this.Controls.Add(nupp1);//вывод радиокнопки на экран
            this.Controls.Add(nupp2);//вывод радиокнопки на экран
        }
        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender=(Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?","Küsimus",MessageBoxButtons.YesNo);
            if (vastus==DialogResult.Yes)//есди выбрали вариант прослушать музыку
            {
                if (nupp1.Checked==true)//если выбрана эта кнопка, то играет песня mixkit и пишется об этом
                {
                    using (var muusika=new SoundPlayer(@"..\..\mixkit.wav"))
                    {
                        muusika.Play();
                        MessageBox.Show("mängib: mixkit","Muusika");
                        
                    }
                    nupp1.Checked=false;//убирается выбор с этой кнопки и можно потом повторно проиграть ту же песню
                }
                else if (nupp2.Checked==true)//если выбрана эта кнопка, то играет песня birds и пишется об этом
                {
                    using (var muusika = new SoundPlayer(@"..\..\birds.wav"))
                    {
                        muusika.Play();
                        MessageBox.Show("mängib: birds","Muusika");
                        
                    }
                    nupp2.Checked=false;//убирается выбор с этой кнопки и можно потом повторно проиграть ту же песню
                }
                else
                {
                    MessageBox.Show("Mitte midagi ei valitud!");//если не выбрана никакая кнопка, то об этом тоже пишется
                }
                
            }
            else
            {
                MessageBox.Show(":(");//если выбрали вариант не слушать музыку
            }
        }
    }
}
