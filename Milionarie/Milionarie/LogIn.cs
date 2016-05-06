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
    public partial class LogIn : Form
    {
        public Initial initial;

        public LogIn()
        {
            InitializeComponent();
           
        }

        public LogIn(Initial initial)
        {
            InitializeComponent();
            this.initial = initial;

        }

        private void button1_Click(object sender, EventArgs e)
        {
          if(textBox1.Text=="admin" && textBox2.Text=="admin")
                {
                Settings sett = new Settings(initial);
                sett.initial = initial;
                sett.Show();
                sett.init();
                this.Hide();
            }

            else{
                MessageBox.Show("Wrong username or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initial.Show();
            this.Hide();
        }
    }
}
