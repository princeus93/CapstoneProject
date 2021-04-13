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

        private void ButtonMediumLevel_Click(object sender, EventArgs e)
        {
            new MediumLevel().Show(); 
        }

        private void ButtonHardLevel_Click(object sender, EventArgs e)
        { 
            new HardLevel().Show(); 
        }

        private void ButtonEasyLevel_Click(object sender, EventArgs e)
        {
            new EasyLevel().Show();
        }
    }
}
