using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Milionarie
{
    public partial class Initial : Form
    {
        public Question q;
        public  List<Question> easylist;
        public  List<Question> mediumlist;
        public  List<Question> hardlist;

        public WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public Initial()
        {
            InitializeComponent();
            wplayer.settings.setMode("loop", true);
            wplayer.URL = "intro.mp3";
            

            easylist = new List<Question>();
            mediumlist = new List<Question>();
            hardlist = new List<Question>();   
                   
            read();
        }

       

        public void read()
        {
            string line = "";
            string[] parts;
            char delimiter = '|';


            using (StreamReader read = new StreamReader("Questions.txt"))

            {   
                while (read.EndOfStream == false)
                {
                    line = read.ReadLine();

                    parts = line.Split(delimiter);
                    Question question = new Question(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);

                    if (parts[0].Equals("1"))
                    {
                        easylist.Add(question);

                    }
                    if (parts[0].Equals("2"))
                    {
                        mediumlist.Add(question);

                    }
                    if (parts[0].Equals("3"))
                    {
                        hardlist.Add(question);

                    }
                }
                read.Close();
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(easylist, mediumlist, hardlist);
            game.Show();
            wplayer.controls.stop();
            Hide();
        }

        public void write()
        {

            //StringBuilder str = new StringBuilder();
            using (StreamWriter write = new StreamWriter("Questions.txt"))
            {

                for (int i = 0; i < easylist.Count; i++)
                {
                    StringBuilder str = new StringBuilder();
                    Question a = easylist.ElementAt(i);
                    string aa = "1|";
                    str.Append(aa);
                    aa = a.questionText;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerA.answerA;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerB.answerB;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerC.answerC;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerD.answerD;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.correctAnswer.correctAnswer;
                    str.Append(aa);
                    String aaa = str.ToString();
                    write.WriteLine(aaa);
                }

                for (int i = 0; i < mediumlist.Count; i++)
                {
                    StringBuilder str = new StringBuilder();
                    Question a = mediumlist.ElementAt(i);
                    string aa = "2|";
                    str.Append(aa);
                    aa = a.questionText;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerA.answerA;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerB.answerB;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerC.answerC;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerD.answerD;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.correctAnswer.correctAnswer;
                    str.Append(aa);
                    String aaa = str.ToString();
                    write.WriteLine(aaa);
                }
                for (int i = 0; i < hardlist.Count; i++)
                {
                    StringBuilder str = new StringBuilder();
                    Question a = hardlist.ElementAt(i);
                    string aa = "3|";
                    str.Append(aa);
                    aa = a.questionText;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerA.answerA;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerB.answerB;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerC.answerC;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.answerD.answerD;
                    str.Append(aa);
                    aa = "|";
                    str.Append(aa);
                    aa = a.correctAnswer.correctAnswer;
                    str.Append(aa);
                    String aaa = str.ToString();
                    write.WriteLine(aaa);
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn(this);
            wplayer.controls.stop();
            logIn.initial = this;
            logIn.Show();

            this.Hide();
        }
    }
}
