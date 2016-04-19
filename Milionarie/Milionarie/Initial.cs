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
    public partial class Initial : Form
    {
        public Question q;
        List<Question> easylist;
        List<Question> mediumlist;
        List<Question> hardlist;
        public Initial()
        {
            InitializeComponent();
            q = new Question("Kolku e 2+2", "1", "2", "3", "4", "4");

            easylist = new List<Question>();
            mediumlist = new List<Question>();
            hardlist = new List<Question>();

            Question q11 = new Question("Proizvod od pcela ?", "Otok", "Med", "Mleko", "Sirenje", "Med");
            Question q12 = new Question("PRVI 5-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q13 = new Question("PRVI 5-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q14 = new Question("PRVI 5-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q15 = new Question("PRVI 5-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q21 = new Question("PRVI 10-1", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q22 = new Question("PRVI 10-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q23 = new Question("PRVI 10-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q24 = new Question("PRVI 10-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q25 = new Question("PRVI 10-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q31 = new Question("PRVI 15-1", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q32 = new Question("PRVI 15-2", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q33 = new Question("PRVI 15-3", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q34 = new Question("PRVI 15-4", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            Question q35 = new Question("PRVI 15-5", "TOCNO", "gRESKA", "GRESKA", "greska", "TOCNO");
            easylist.Add(q11);
            easylist.Add(q12);
            easylist.Add(q13);
            easylist.Add(q14);
            easylist.Add(q15);
            mediumlist.Add(q21);
            mediumlist.Add(q22);
            mediumlist.Add(q23);
            mediumlist.Add(q24);
            mediumlist.Add(q25);
            hardlist.Add(q31);
            hardlist.Add(q32);
            hardlist.Add(q33);
            hardlist.Add(q34);
            hardlist.Add(q35);
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            Game game=new Game(easylist,mediumlist,hardlist);
            game.Show();
            this.Hide();
        }
    }
}
