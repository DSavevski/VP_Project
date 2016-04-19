using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milionarie
{
    public class Question
    {
        public string questionText { get; set; }
        public AnswerA answerA { get; set; }
        public AnswerB answerB { get; set; }
        public AnswerC answerC { get; set; }
        public AnswerD answerD { get; set; }
        public CorrectAnswer correctAnswer { get; set; }
        public ChosenAnswer chosenAnswer { get; set; }

        public static int[] votes = new int[4];

        public bool passed;

        public static Random rand = new Random();
       
        public Question(string qt,string aa,string ab,string ac,string ad,string ca)
        {
            questionText = qt;
            answerA = new AnswerA(aa);
            answerB = new AnswerB(ab);
            answerC = new AnswerC(ac);
            answerD = new AnswerD(ad);
            correctAnswer = new CorrectAnswer(ca);

            passed = false;

            answerA.NUMBER = rand.Next(1, 5);

            do {
                answerB.NUMBER = rand.Next(1, 5);
               } while (answerB.NUMBER == answerA.NUMBER);

            do
            {
                answerC.NUMBER = rand.Next(1, 5);
            } while (answerC.NUMBER == answerB.NUMBER || answerC.NUMBER == answerA.NUMBER);

            do
            {
                answerD.NUMBER = rand.Next(1, 5);
            } while (answerD.NUMBER == answerC.NUMBER || answerD.NUMBER == answerB.NUMBER || answerD.NUMBER == answerA.NUMBER);


            if (correctAnswer.correctAnswer == answerA.answerA)
                correctAnswer.NUMBER = answerA.NUMBER;
            else if (correctAnswer.correctAnswer == answerB.answerB)
                correctAnswer.NUMBER = answerB.NUMBER;
            else  if (correctAnswer.correctAnswer == answerC.answerC)
                correctAnswer.NUMBER = answerC.NUMBER;
            else if (correctAnswer.correctAnswer == answerD.answerD)
                correctAnswer.NUMBER = answerD.NUMBER;

        }

        public string getAnswerNumber(int number)
        {
            if (answerA.NUMBER == number)
                return answerA.answerA;
            else if (answerB.NUMBER == number)
                return answerB.answerB;
            else if (answerC.NUMBER == number)
                return answerC.answerC;
            else return answerD.answerD;
        }

        public bool IsAnswerRight()
        {
            return chosenAnswer.chosenAnswer == correctAnswer.correctAnswer;
        }

        public void joker5050()
        {
            while ((Game.JOCKER5050_1 = rand.Next(1, 5)) == correctAnswer.NUMBER || 
                (Game.JOCKER5050_2 = rand.Next(1, 5)) == correctAnswer.NUMBER || Game.JOCKER5050_2 == Game.JOCKER5050_1);
        }


        public void audience() {
            votes[0] = 0;
            votes[1] = 0;
            votes[2] = 0;
            votes[3] = 0;
            for (int i = 0; i < 100; i++) {
                int broj = rand.Next(1, 101);
                if (answerA.NUMBER == correctAnswer.NUMBER)
                {
                    if (broj < 50)
                        votes[correctAnswer.NUMBER - 1]++;
                    else if (broj < 72 && correctAnswer.NUMBER != answerB.NUMBER)
                        votes[answerB.NUMBER - 1]++;
                    else if (broj < 90 && correctAnswer.NUMBER != answerC.NUMBER)
                        votes[answerC.NUMBER - 1]++;
                    else if (broj <= 100 && correctAnswer.NUMBER != answerD.NUMBER)
                        votes[answerD.NUMBER - 1]++;
                }
                if (answerB.NUMBER == correctAnswer.NUMBER)
                {
                    if (broj < 50)
                        votes[correctAnswer.NUMBER - 1]++;
                    else if (broj < 72 && correctAnswer.NUMBER != answerC.NUMBER)
                        votes[answerB.NUMBER - 1]++;
                    else if (broj < 90 && correctAnswer.NUMBER != answerA.NUMBER)
                        votes[answerC.NUMBER - 1]++;
                    else if (broj <= 100 && correctAnswer.NUMBER != answerD.NUMBER)
                        votes[answerD.NUMBER - 1]++;
                }
                if (answerC.NUMBER == correctAnswer.NUMBER)
                {
                    if (broj < 50)
                        votes[correctAnswer.NUMBER - 1]++;
                    else if (broj < 72 && correctAnswer.NUMBER != answerB.NUMBER)
                        votes[answerB.NUMBER - 1]++;
                    else if (broj < 90 && correctAnswer.NUMBER != answerC.NUMBER)
                        votes[answerC.NUMBER - 1]++;
                    else if (broj <= 100 && correctAnswer.NUMBER != answerA.NUMBER)
                        votes[answerD.NUMBER - 1]++;
                }
                if (answerD.NUMBER == correctAnswer.NUMBER)
                {
                    if (broj < 50)
                        votes[correctAnswer.NUMBER - 1]++;
                    else if (broj < 72 && correctAnswer.NUMBER != answerA.NUMBER)
                        votes[answerB.NUMBER - 1]++;
                    else if (broj < 90 && correctAnswer.NUMBER != answerC.NUMBER)
                        votes[answerC.NUMBER - 1]++;
                    else if (broj <= 100 && correctAnswer.NUMBER != answerB.NUMBER)
                        votes[answerD.NUMBER - 1]++;
                }


            }




        }

        public String callingFriend()
        {

            int randFriend = rand.Next(1, 31);
            if (randFriend < 17)
                return String.Format("I am sure it is {0}", correctAnswer.correctAnswer);
            else if (randFriend < 26)
            {
                return String.Format("I think it is {0}", correctAnswer.correctAnswer);

            }
            else {

                return String.Format(" Sorry, I don't know :( ");

            }

        }
    }
}
