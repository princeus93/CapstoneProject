using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SuperheroMemoryGame_1_
{
    public partial class EasyLevel : Form
    {
        public EasyLevel()
        {
            InitializeComponent();
        }

        bool allowClick = false;
        PictureBox firstGuess;
        readonly Random rnd = new Random();
        readonly Timer clickTimer = new Timer();
        int time = 60;
        readonly Timer timer = new Timer { Interval = 1000 };
        double guessCount = 0;
        double correctGuessCount = 0;

        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.CaptainAmericaNew,
                    Properties.Resources.AntManNew,
                    Properties.Resources.BlackPantherNew,
                    Properties.Resources.ArrowNew,
                    Properties.Resources.NewVision,
                    Properties.Resources.IronmanNew
                };
            }
        }

        //Game timer function
        private void StartGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBoxLoseGame();
                    //MessageBox.Show("Out of time");
                    //ResetImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);

                label1.Text = "00: " + time.ToString();
            };
        }

        private void ResetImages()
        {
            foreach (var pic in PictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            SetRandomImages();
            time = 60;
            timer.Start();

        }

        

        private void HideImages()
        {
            try
            {
                foreach (var pic in PictureBoxes)
                {
                    pic.Image = Properties.Resources.NewQuestionMark;
                }
            } catch{
                MessageBox.Show("error, restarting");
                ResetImages();
                label4.ResetText();
                label3.ResetText();
                label2.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
        }

        private PictureBox GetFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, PictureBoxes.Count());
            }
            while (PictureBoxes[num].Tag != null);
            return PictureBoxes[num];
        }

        private void SetRandomImages()
        {
            //do
            // {
            foreach (var image in Images)
            {
                GetFreeSlot().Tag = image;
                GetFreeSlot().Tag = image;
            }
            // while (getFreeSlot().Tag == null);   
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        //Game lost message box
        private void MessageBoxLoseGame()
        {

            string message = "Out of time! \n Would you like to try again?";
            string title = "Game Over";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                label3.ResetText();
                label2.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            {
                EasyLevel.ActiveForm.Close();
                new MainMenu().Show();
            }
        }

        //Game won message box
        private void MessageBoxWinGame()
        {
            string message = "You WIN! \n Do you want to play again?";
            string title = "Game Won";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ResetImages();
                label4.ResetText();
                label3.ResetText();
                label2.ResetText();
                correctGuessCount = 0;
                guessCount = 0;
            }
            else if (result == DialogResult.No)
            {
                EasyLevel.ActiveForm.Close();
                new MainMenu().Show();
            }
        }

        public void DisplayGuessCount()
        {
            //double cGCount = correctGuessCount;
            // gCount = guessCount;
            if (guessCount % 2 == 0)
            {

                // gCount =  gCount / 2;
                label2.Text = (guessCount/2).ToString();
            }
            else
            {
                return;
            }
            // label2.Text = guessCount.ToString(); 
        }

        private void DisplayAccuracy()
        {
            // NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            double cGCount = correctGuessCount;
            double gCount = guessCount;

            double accuracyOfPicks;

            //totalPicks = guessCount;
            // correctPicks = correctGuessCount;
            if (cGCount < 1 || gCount < 1)
            {
                accuracyOfPicks = 0;
            }
            else
            {
                accuracyOfPicks = (cGCount / gCount) * 2;
            }
            label3.Text = accuracyOfPicks.ToString("P", CultureInfo.InvariantCulture);
            //return accuracyOfPicks;
        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            guessCount++;
            var pic = (PictureBox)sender;
            DisplayGuessCount();
            DisplayAccuracy();

            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;


            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                correctGuessCount++;
                label4.Text = correctGuessCount.ToString();
                pic.Visible = firstGuess.Visible = false;

                {
                    firstGuess = pic;

                }

                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();

            }


            firstGuess = null;
            //Checks for any visible pictures, returns if yes, else stops timer & displays Win 
            if (PictureBoxes.Any(p => p.Visible)) { return; }
            else { timer.Stop(); MessageBoxWinGame(); }
        }


        //Starts game
        private void StartGame(object sender, EventArgs e)
        {
            allowClick = true;
            SetRandomImages();
            HideImages();
            StartGameTimer();

            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;
        }

        private void EasyLevel_Load(object sender, EventArgs e)
        {

        }
    }
}
