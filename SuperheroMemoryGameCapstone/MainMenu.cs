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
    public partial class mainMenu : Form
    {

        public mainMenu()
        {
            InitializeComponent();
        }

        private void buttonMediumLevel_Click(object sender, EventArgs e)
        {
            
            new mediumLevel().Show(); 
        }

        private void buttonHardLevel_Click(object sender, EventArgs e)
        {
            
            new hardLevel().Show(); 
        }

        private void buttonEasyLevel_Click(object sender, EventArgs e)
        {
            new EasyLevel().Show();
        }
    }
}
