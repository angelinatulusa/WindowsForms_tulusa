using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_tulusa
{
    public partial class MinuOmaVorm : Form
    {
        Random random = new Random();

        TreeView puu;
        Button nupp;
        Button nupp2;
        Button nupp3;
        Label silt;
        CheckBox mruut1;
        CheckBox mruut2;
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        Timer aeg;
        TextBox tekst;
        int x = 150;
        int y = 450;
        public MinuOmaVorm()
        {
            Height = 600;
            Width = 900;
            Text = "Minu oma form koos elementidega";//nazvanie
            BackColor= Color.LightSlateGray;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad=new TreeNode("Elemendid");//vetka
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("Dialog aken-MessangeBox"));
            oksad.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            oksad.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Tekstkast - TextBox"));
            oksad.Nodes.Add(new TreeNode("OmaVorm - MyForm"));
            /*puu.AfterSelect += Puu_AfterSelect1;
            puu.Nodes.Add(oksad);
            puu.DoubleClick += Puu_DoubleClick;
            this.Controls.Add(puu);*/

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);


        }

        /*private void Puu_DoubleClick(object sender, EventArgs e)
        {
            if (t == true)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }

        private void Puu_AfterSelect1(object sender, TreeViewEventArgs e)
        {
            if (t == true)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true; 
            }
        }*/

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            silt = new Label
            {
                Text = "Minu esimene vorm",
                Size = new Size(100, 20),
                Location = new Point(200, 0)
            };
            mruut1 = new CheckBox

            {
                Checked = false,
                Text = "Üks",
                Location = new Point(silt.Left + silt.Width, 0),
                Width = 100,
                Height = 25
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Kaks",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Width = 100,
                Height = 25
            };
            tekst = new TextBox
            {
                Font = new Font("Arial", 34, FontStyle.Italic),
                Location = new Point(350, 400),
                Enabled = true
            };

            if (e.Node.Text== "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.BackColor= Color.LightSkyBlue;
                nupp.Location=new Point(200, 100);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text=="Silt-Label")
            {

                silt.BackColor = Color.LightSalmon;
                silt.ForeColor = Color.DarkBlue;                

                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text=="Dialog aken-MessangeBox")
            {
                MessageBox.Show("Siia kirjuta lause","Kõike lihtsam aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?","sinu valik",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (vastus==DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Töötame edasi","okei");
                }
            }
            else if (e.Node.Text== "Märkeruut-Checkbox")
            {
                mruut1 = new CheckBox

                {
                    Checked = false,
                    Text = "Üks",
                    Location = new Point(silt.Left + silt.Width, 0),
                    Width=100,
                    Height = 25
                };
                //mruut1.Click += Mruut1_Click;
                //mruut1.CheckedChanged += Mruut1_CheckedChanged;
                mruut2 = new CheckBox
                {
                    Checked = false,
                    Text = "Kaks",
                    Location = new Point(silt.Left + silt.Width, mruut1.Height),
                    Width=100,
                    Height = 25
                };
                //mruut2.CheckedChanged += Mruut2_CheckedChanged;
                //mruut2.Click += Mruut2_Click;
                mruut1.CheckedChanged += Mruut1_2_CheckedChanged1;
                mruut2.CheckedChanged += Mruut1_2_CheckedChanged1;
                
                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
            }
            else if (e.Node.Text=="Radionupp-Radiobutton")
            {
                rnupp1 = new RadioButton
                {
                    Text = "Paremale",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height),

                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width+rnupp1.Width, mruut1.Height + mruut2.Height),

                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width, mruut1.Height + mruut2.Height),

                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width + rnupp3.Width, mruut1.Height + mruut2.Height),

                };
                
                pilt = new PictureBox
                {
                    Image = new Bitmap(@"..\..\tthk.png"),
                    Location = new Point(x, y),
                    Size = new Size(100, 100),
                    SizeMode = PictureBoxSizeMode.Zoom
                };  
                rnupp1.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp2.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp3.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp4.CheckedChanged += new EventHandler(Rnuppud_Changed);
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
            }
            else if (e.Node.Text== "Edenemisriba-ProgressBar")
            {
                riba = new ProgressBar
                {
                    Width = 400,
                    Height = 30,
                    Location = new Point(350, 500),
                    Value = 0,
                    Minimum = 0,
                    Maximum = 100,
                    Step = 1,
                    //Dock = DockStyle.Bottom
                };
                nupp3 = new Button
                {
                    Width=50,
                    Height=30,
                    Location=new Point(350,475),
                    BackColor = Color.Lavender,
                };
                nupp3.Click += Nupp3_Click1;
                /*aeg = new Timer();
                aeg.Enabled = true;
                aeg.Tick += Aeg_Tick;*/
                this.Controls.Add(riba);
                this.Controls.Add(nupp3); 
            }
            else if (e.Node.Text== "Tekstkast - TextBox")
            {
                //tekst.MouseDoubleClick += Tekst_MouseDoubleClick; 

                this.Controls.Add(tekst);
            }
            else if (e.Node.Text== "OmaVorm - MyForm")
            {
                OmaVorm oma = new OmaVorm("Muusikat kuulamine","Lülita muusika sisse","Vali muusikat:");
                oma.ShowDialog();
            }
        }
        bool t = false;
        private void Tekst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (t == true)
            {
                tekst.Enabled = false;
            }
            else
            {
                tekst.Enabled = true;
            }
        }
        private void Nupp3_Click1(object sender, EventArgs e)
        {
            riba.PerformStep();
        }

        private void Nupp3_Click(object sender, EventArgs e)
        {
            aeg = new Timer();
            aeg.Enabled = true;
            aeg.Tick += Aeg_Tick;
            
        }

        private void Aeg_Tick(object sender, EventArgs e)
        {
            riba.PerformStep();
        }

        private void Rnuppud_Changed(object sender, EventArgs e)
        {
            if (rnupp1.Checked==true)
            {
                pilt.Location = new Point(x += 30, y);
                rnupp1.Checked = false;
            }
            else if (rnupp2.Checked==true)
            {
                pilt.Location = new Point(x -= 30, y);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked==true)
            {
                pilt.Location = new Point(x, y -= 30);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked==true)
            {
                pilt.Location = new Point(x, y += 30);
                rnupp4.Checked = false;
            }
            /*if (rnupp1.Checked)
            {
                pilt.Location = new Point(pilt.Left + 10, pilt.Top);
                rnupp1.Checked = false;
            }
            if (rnupp2.Checked)
            {
                pilt.Location = new Point(pilt.Left - 10, pilt.Top);
                rnupp2.Checked = false;
            }
            if (rnupp3.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top - 10);
                rnupp3.Checked = false;
            }
            if (rnupp4.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top + 10);
                rnupp4.Checked = false;
            }*/
        }
        private void Mruut1_2_CheckedChanged1(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                Height = 350;
                Width = 600;
                nupp2 = new Button();
                nupp2.Text="siin vajuta";
                nupp2.Height = 30;
                nupp2.Width = 100;
                nupp2.Location = new Point(200, 200);
                nupp2.Click += Nupp2_Click;
                this.Controls.Add(nupp2);
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                Height = 450;
                Width = 750;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                Height = 450;
                Width = 750;
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                Height = 600;
                Width = 900;
            }
        }

        private void Nupp2_Click(object sender, EventArgs e)
        {
            nupp2.BackColor = Color.AliceBlue;
            int red, green, blue;
            red = random.Next(255);
            green = random.Next(255);
            blue = random.Next(255);
            nupp2.BackColor = Color.FromArgb(red, green, blue);
        } 

        private void Mruut2_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                Height = 350;
                Width = 600;
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                Height = 450;
                Width = 750;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                Height = 400;
                Width = 700;
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                Height = 600;
                Width = 900;
            }
        }
        private void Mruut1_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked==true&&mruut2.Checked==true)
            {
                Height = 350;
                Width = 600;
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                Height = 450;
                Width = 750;
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                Height = 400;
                Width = 700;
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                Height = 600;
                Width = 900;
            }
        }
        /*private void Mruut2_Click(object sender, EventArgs e)
        {
            mruut1.ForeColor = Color.White;
            mruut1.Font = new Font("Georgia", 12);
            Height = 600;
            Width = 900;
        }

        private void Mruut1_Click(object sender, EventArgs e)
        {
            mruut2.ForeColor=Color.Aqua;
            mruut2.Font = new Font("Georgia", 12);
            Height = 500;
            Width = 800;
            
        }*/
        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.BackColor = Color.Transparent;//prozracnii cvet
            silt.ForeColor = Color.LightSalmon;
        }
        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.BackColor = Color.LightSalmon;
            silt.ForeColor = Color.DarkBlue;
        }
        private void Nupp_Click(object sender, EventArgs e)
        {
            nupp.BackColor= Color.LightYellow;
            int red, green, blue;
            red = random.Next(255);
            green = random.Next(255);
            blue = random.Next(255);
            nupp.BackColor=Color.FromArgb(red, green, blue);
            BackColor = Color.FromArgb(red, green, blue);
        }
    }
}
