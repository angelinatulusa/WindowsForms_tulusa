using System;
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
        TreeView puu;
        Button nupp;
        Label silt;
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

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);


        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
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
                silt = new Label { Text = "Minu esimene vorm", 
                    Size=new Size(100,20),
                    Location=new Point(200,0),
                    BackColor= Color.LightSalmon,
                    ForeColor= Color.DarkBlue
                    
                };
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
                    MessageBox.Show("okei","ma pannen aken kinni");
                    this.Close();
                }
            }
        }

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

        Random random = new Random();
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
