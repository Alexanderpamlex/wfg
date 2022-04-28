using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfgame
{
    public partial class Form1 : Form
    {   

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };


        private void AssignIconsToSqures()
        {
            
            foreach(Control control in tableLayoutPanel1.Controls)
            {

                Label iconlabel = control as Label;
                if (iconlabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconlabel.Text = icons[randomNumber];
                    iconlabel.ForeColor = iconlabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }

            }

        }

        Label firstClick = null;
        Label secondClick = null;

        private void CheckForWinner()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if(iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor) return;
                }


            }

            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();

        }



        public Form1()
        {
            InitializeComponent();
            AssignIconsToSqures();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true) return;

            Label clickedLabel = sender as Label;
            
            if(clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black) return;
                
                if(firstClick == null)
                {
                    firstClick = clickedLabel;
                    firstClick.ForeColor = Color.Black;
                    return;
                }


                secondClick = clickedLabel;
                secondClick.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClick.Text == secondClick.Text) {

                    firstClick = null;
                    secondClick = null;
                    return;
                }


                timer1.Start();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();

            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            firstClick = null;
            secondClick = null;

        }
    }
}
