#Милионер - проект, Визуелно програмирање
##### Изработиле:
######Драган Савевски и Димитар Рабаџиски
#1. Опис на проектот
Станува збор за познатата игра Кој сака да биде милионер, повеќе информации може да се најдат на следниов [линк](https://en.wikipedia.org/wiki/Millionaire). Најголем дел од правилата во играта ги задржавме и тука.
###1.1 Oпис на почетната форма
При стартот на играта имаме 2 опции play копче и settings. Во settings треба да се логираме. Се отвара нова форма кадешто се избира ниво на прашање пришто се појавуваат сите прашања од селектираното ниво. Може да се избрише или додане ново прашање, а има и информација за тоа колку прашања има од секое ниво.
###1.2 Како се игра ?
Има 15 прашања, 3 џокери за помош (50-50,повикај пријател и публика), 3 нивоа на прашања лесни, средни и тешки. Доколку не се одговори точно некое прашање и кое спаѓа во лесните се добива 0 денари, а за средните и тешките има соодветна сума.
#Опис на имплементацијата
На почетокот во класата Initial се вчитуваат прашањата од датоека кои се зачивани се следниов формат Teжина на прашање|Прашање|Одговор1|Одговор2|Oдговор3|Одговор4|Точен одговор. Ги читаме со следниот метод.
```c#
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
```
Главните податоци кои се чуваат во класата Game, која всушност е сцената.
```c#
/// <summary>
        /// Shows which question we are currently on
        /// </summary>
        public static int CURRENT_Q = 1;
        /// <summary>
        /// Background music player
        /// </summary>
        public WMPLib.WindowsMediaPlayer bg = new WMPLib.WindowsMediaPlayer();
         /// <summary>
        /// answer music
        /// </summary>
        public WMPLib.WindowsMediaPlayer answer = new WMPLib.WindowsMediaPlayer();
        /// <summary>
        /// list of easy questions
        /// </summary>
        List<Question> easylist;
        /// <summary>
        /// medium list questions
        /// </summary>
        List<Question> mediumlist;
        /// <summary>
        /// hard list questions
        /// </summary>
        List<Question> hardlist;
```
Во класата Questions, во која се чуваат следниве податоци, кадешто AnswerA,AnswerB се класи за репрезентација на одговорот
```c#
 public string questionText { get; set; }
        public AnswerA answerA { get; set; }
        public AnswerB answerB { get; set; }
        public AnswerC answerC { get; set; }
        public AnswerD answerD { get; set; }
        public CorrectAnswer correctAnswer { get; set; }
        public ChosenAnswer chosenAnswer { get; set; }
        /// <summary>
        /// Which level the question belongs to.
        /// </summary>
        public int level;
       
        /// <summary>
        /// Audience votes for a certain question
        /// </summary>
        public static int[] votes = new int[4];
        /// <summary>
        /// Whether the question has passed
        /// </summary>
        public bool passed;
        /// <summary>
        /// Random object used for which field the answer text will be displayed on.
        /// Different game, different places for each answer
        /// </summary>
        public static Random rand = new Random();
```
Со помош на следниот метод го земаме следното прашање.
```c#
 /// <summary>
        /// Gets the next question.
        /// </summary>
        /// <returns>Question
        /// </returns>
        public Question getQuestion()
        {   
            if (CURRENT_Q <= 5)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, easylist.Count);
                    currentQuestion = easylist.ElementAt(idx);
                    currentQuestion.level = 1;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }
            else if (CURRENT_Q > 5 && CURRENT_Q <= 10)
            {
                while (true)
                {
                    idx = Question.rand.Next(0, mediumlist.Count);
                    
                    currentQuestion = mediumlist.ElementAt(idx);
                    currentQuestion.level = 2;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }
            else
            {
                while (true)
                {
                    idx = Question.rand.Next(0, hardlist.Count);
                    
                    currentQuestion = hardlist.ElementAt(idx);
                    currentQuestion.level = 3;

                    if (currentQuestion.passed == false)
                    {
                        return currentQuestion;
                    }
                }

            }

        }
```
При имплементацијата на џокерот повикај пријател можно е да се генерираат 3 вредности.Сигурен одговор, најверојатно точен и постои можност пријателот да него знае одговорот. Тоа е имплементирано на следниот начин:
```c#
 public string callingFriend()
        {

            int randFriend = rand.Next(1, 31);
            if (randFriend < 17)
                return string.Format("Сигурен сум дека е {0}", correctAnswer.correctAnswer);
            else if (randFriend < 26)
            {
                return string.Format("Мислам дека е {0}", correctAnswer.correctAnswer);

            }
            else {

                return string.Format("Извини, но не знам :( ");

            }

        }
```
Аналогно на методот повикај пријател, слично е имплементиран и џокерот повикај публика со таа разлика што се симулираат повеќе рандом броеви.
