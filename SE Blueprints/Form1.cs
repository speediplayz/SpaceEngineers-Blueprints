using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Blueprints
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
            /*
            Blueprint bp = new Blueprint("StalinMan", @"C:\Users\jakub\OneDrive\Desktop", false);

            
            bp.AddBlock(0, 0, 0, new Vector3(255,   0,   0));
            bp.AddBlock(0, 1, 0, new Vector3(255, 255,   0));
            bp.AddBlock(0, 2, 0, new Vector3(255, 255, 255));
            bp.AddBlock(0, 3, 0, new Vector3(0,   255,   0));
            bp.AddBlock(0, 4, 0, new Vector3(0,   255, 255));
            bp.AddBlock(0, 5, 0, new Vector3(0,   0,   255));
            bp.AddBlock(0, 6, 0, new Vector3(0,   0,   0  ));
            

            for(int x = 0; x < image.Width; x++)
            {
                for(int y = 0; y < image.Height; y++)
                {
                    Color c = image.GetPixel(x, y);
                    if(c.A > 10)
                    {
                        bp.AddBlock(x, y, 0, new Vector3(c.R, c.G, c.B));
                    }
                }
            }

            bp.Save();
            */
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = @"Image Files (*.png, *.jpg, *.jpeg, *.bmp)|*.png; *.jpg; *.jpeg; *.bmp";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);

                Blueprint bp = new Blueprint(txtName.Text, txtPath.Text, chkLarge.Checked);

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color c = image.GetPixel(x, y);
                        if (c.A > 10)
                        {
                            bp.AddBlock(x, y, 0, new Vector3(c.R, c.G, c.B));
                        }
                    }
                }

                bp.Save();
            }
        }
    }
}
