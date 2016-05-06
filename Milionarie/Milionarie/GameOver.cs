using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milionarie
{
    public partial class GameOver : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public GameOver()
        {
            InitializeComponent();
        }

        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public GameOver(string money)
        {
            InitializeComponent();
            label2.Text = money;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int a = Question.rand.Next(0, 255);
            int b = Question.rand.Next(0, 255);
            int c = Question.rand.Next(0, 255);
            int d = Question.rand.Next(0, 255);

            label2.ForeColor = Color.FromArgb(a, b, c, d);
        }
        //start new game
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
