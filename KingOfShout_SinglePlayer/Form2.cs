using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Globalization;
using System.Threading;

namespace KingOfShout_SinglePlayer
{
    public partial class Form2 : Form
    {
        int hp;
        public Form2()
        {
            InitializeComponent();
            hp = 100;
            this.Width = 528;
            this.Height = 646;
            this.panel1.Hide();
            this.panel2.Location = new Point(0, 0);
            this.richTextBox1.ReadOnly = true;
            this.richTextBox2.ReadOnly = true;
            this.label3.Text = "Handsome Chang 張兆宇";
            while (hp > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, Program2.Sentence.Length);
                string Q = Program2.Sentence[index];
                Console.WriteLine(Q);
                Thread.Sleep(2000);
                Program2.answer = Q;
                Program2.recog(Q);
                while (Program2.completed != true)
                {
                    Thread.Sleep(333);
                }
            }
        }

    }

    class Program2
    {
        // Indicate whether asynchronous recognition has finished.
        public static bool completed;
        public static String[] Sentence = {"紅豆生南國",
            "化肥會揮發",
            "安思依知打春竹",
            "單槓盪單槓" ,
            "抱著灰雞上飛機" ,
            "東邊大婆婆之家有一隻白鼻頭大白貓",
            "李家嫂子吃梨， 黎家嫂子吃李",
            "老師愛書怕老鼠， 老鼠咬書怕老師 ",
            "濤濤愛吃姥姥的核桃，姥姥愛吃濤濤的葡萄",
            "白石搭石塔， 白塔白石搭",
            "叢嶺種青松， 青松掛銅鐘",
            "胡乎愛畫虎， 滬虎愛做壺", "山南一個崔粗腿，山北一個崔腿粗" };
        public static string answer;
        public static void recog(string q)
        {
            

            using (SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine(new CultureInfo("zh-TW")))
            {                
                // Sentence to be said
                Choices words = new Choices();
                words.Add(new string[] { q });
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(words);
                Grammar g = new Grammar(gb);
                recognizer.LoadGrammar(g);

                //Create and load the dictation grammar.
                Grammar dictation = new DictationGrammar();
                dictation.Name = "Dictation Grammar";
                recognizer.LoadGrammar(dictation);

                // Attach event handlers to the recognizer.
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(
                    SpeechRecognizedHandler);
                recognizer.RecognizeCompleted +=
                  new EventHandler<RecognizeCompletedEventArgs>(
                    RecognizeCompletedHandler);

                // Assign input to the recognizer.
                recognizer.SetInputToDefaultAudioDevice();

                // Begin asynchronous recognition.
                Console.WriteLine("Starting recognition...");
                completed = false;
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Wait for recognition to finish.
                while (!completed)
                {
                    Thread.Sleep(333);
                }
                Console.WriteLine("Done.");
            }

        }

        static void SpeechRecognizedHandler(
          object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("  Speech recognized:");
            string grammarName = "<not available>";

            Console.WriteLine("  Score - ");
            Console.WriteLine("    " + e.Result.Confidence);

            Console.WriteLine("  Duration - ");
            Console.WriteLine("    " + e.Result.Audio.Duration.TotalSeconds * 1000);


            if (e.Result.Text == answer)
            {
                Console.WriteLine("  Confidence - ");
                Console.WriteLine("    " + e.Result.Confidence);

                Console.WriteLine("  Duration - ");
                Console.WriteLine("    " + e.Result.Audio.Duration.TotalSeconds * 1000);

                Console.WriteLine("  Score - ");
                Console.WriteLine("    " + e.Result.Confidence * 1 / e.Result.Audio.Duration.TotalSeconds * 1000);

            }
            if (e.Result.Grammar.Name != null &&
              !e.Result.Grammar.Name.Equals(string.Empty))
            {
                grammarName = e.Result.Grammar.Name;
            }
            Console.WriteLine(" {0,-17} - {1}",
              grammarName, e.Result.Text);

            if (grammarName.Equals("Exit Grammar") && e.Result.Confidence > 0.8)
            {
                ((SpeechRecognitionEngine)sender).RecognizeAsyncCancel();
            }
        }

        static void RecognizeCompletedHandler(
          object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine("  Recognition completed.");
            completed = true;
        }
    }
}




    

