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
    public partial class Form1 : Form
    {
        public Question q;

        public Form1()
        {
            InitializeComponent();
            q = new Question("Kolku e 2+2", "1", "2", "3", "4", "4");
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Game game=new Game();
            game.Show();
            this.Hide();
        }
    }
}
