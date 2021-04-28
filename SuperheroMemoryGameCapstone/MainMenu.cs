using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperheroMemoryGame_1_
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        /*private void ButtonMediumLevel_Click(object sender, EventArgs e)
        {
           // MainMenu.ActiveForm.Close();
            new MediumLevel().Show(); 
        }

        private void ButtonHardLevel_Click(object sender, EventArgs e)
        {
           // MainMenu.ActiveForm.Close();
            new HardLevel().Show(); 
        }

        private void ButtonEasyLevel_Click(object sender, EventArgs e)
        {
            
            new EasyLevel().Show();
            
            //MainMenu.ActiveForm.Close();
        }*/

        

        private void StartGame_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                new EasyLevel().Show();
            }
            else if(radioButton2.Checked == true)
            {
                new MediumLevel().Show();

            }
            else if (radioButton3.Checked == true)
            {
                new HardLevel().Show();
            }
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
