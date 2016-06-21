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
        const int DAMAGE_TIME = 9;
        BackgroundWorker ha, p;
        static int hp;
        static int monsterHP;
        public static bool completed;
        static double average_score, average_duration, average_confidence;
        static int times;
        public static String[] Sentence = { "紅豆生南國",
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
        static double score, duration, confidence;

        public Form2()
        {
            InitializeComponent();
            
            hp = 15;
            average_score = 0;
            average_duration = 0;
            average_confidence = 0;
            times = 0;
            monsterHP = 450;
            this.Width = 528;
            this.Height = 646;
            this.panel1.Hide();
            this.panel2.Location = new Point(0, 0);
            this.richTextBox1.ReadOnly = true;
            this.richTextBox2.ReadOnly = true;
            this.label3.Text = "Handsome Chang 張兆宇";
            this.label4.Text = "精準度";
            this.label5.Text = "速度";
            this.label6.Text = "攻擊力";
            this.label8.Text = "平均準度";
            this.label9.Text = "平均時間";
            this.label10.Text = "平均攻擊力";
            this.button1.Text = "重來";
            this.button2.Text = "離開";

        }

        static void SpeechRecognizedHandler(
          object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("  Speech recognized:");
            string grammarName = "<not available>";

            Console.WriteLine("  Confidence - ");
            Console.WriteLine("    " + e.Result.Confidence);
            confidence = e.Result.Confidence;

            Console.WriteLine("  Score - ");
            Console.WriteLine("    " + e.Result.Confidence);
            duration = e.Result.Audio.Duration.TotalSeconds * 1000;

            Console.WriteLine("  Duration - ");
            Console.WriteLine("    " + e.Result.Audio.Duration.TotalSeconds * 1000);
            score = e.Result.Confidence * 1 / e.Result.Audio.Duration.TotalSeconds * 1000;

            if (e.Result.Text == answer)
            {
                Console.WriteLine("  Confidence - ");
                Console.WriteLine("    " + e.Result.Confidence);
                confidence = e.Result.Confidence;

                Console.WriteLine("  Duration - ");
                Console.WriteLine("    " + e.Result.Audio.Duration.TotalSeconds * 1000);
                duration = e.Result.Audio.Duration.TotalSeconds * 1000;

                Console.WriteLine("  Score - ");
                Console.WriteLine("    " + e.Result.Confidence * 1 / e.Result.Audio.Duration.TotalSeconds * 1000);
                score = e.Result.Confidence * 1 / e.Result.Audio.Duration.TotalSeconds * 1000;
            }
            completed = true;
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ha = new BackgroundWorker();
            ha.WorkerSupportsCancellation = true;
            ha.WorkerReportsProgress = true;
            ha.DoWork += new DoWorkEventHandler(DoWork);
            ha.ProgressChanged += new ProgressChangedEventHandler(change);
            ha.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Completed);
            ha.RunWorkerAsync();

            p = new BackgroundWorker();
            p.WorkerReportsProgress = true;
            p.WorkerSupportsCancellation = true;
            p.DoWork += new DoWorkEventHandler(killplayer);
            p.ProgressChanged += new ProgressChangedEventHandler(killplayerHP);
            p.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Completed);
            p.RunWorkerAsync();

            Button b = sender as Button;
            b.Enabled = false;
        }
       

        private void killplayerHP(object sender, ProgressChangedEventArgs e)
        {
            hp -= 1;
            this.richTextBox1.Text += "被怪物舔了一口QAQ";
            this.richTextBox1.Text += string.Format("\n 剩下 {0} 格血", hp);
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            this.richTextBox1.ScrollToCaret();
            Shake(this);

            if (e.ProgressPercentage > 1)
            {
                this.playergreen1.Hide();
            }
            if (e.ProgressPercentage > 2)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
            }
            if (e.ProgressPercentage > 3)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();

            }
            if (e.ProgressPercentage > 4)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
            }
            if (e.ProgressPercentage > 5)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
            }
            if (e.ProgressPercentage > 6)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
            }
            if (e.ProgressPercentage > 7)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
            }
            if (e.ProgressPercentage > 8)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
            }
            if (e.ProgressPercentage > 9)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
            }
            if (e.ProgressPercentage > 10)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
                this.playeryellow5.Hide();
            }
            if (e.ProgressPercentage > 11)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
                this.playeryellow5.Hide();
                this.playerred1.Hide();
            }
            if (e.ProgressPercentage > 12)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
                this.playeryellow5.Hide();
                this.playerred1.Hide();
                this.playerred2.Hide();
            }
            if (e.ProgressPercentage > 13)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
                this.playeryellow5.Hide();
                this.playerred1.Hide();
                this.playerred2.Hide();
                this.playerred3.Hide();
            }
            if(e.ProgressPercentage > 14)
            {
                this.playergreen1.Hide();
                this.playergreen2.Hide();
                this.playergreen3.Hide();
                this.playergreen4.Hide();
                this.playergreen5.Hide();
                this.playeryellow1.Hide();
                this.playeryellow2.Hide();
                this.playeryellow3.Hide();
                this.playeryellow4.Hide();
                this.playeryellow5.Hide();
                this.playerred1.Hide();
                this.playerred2.Hide();
                this.playerred3.Hide();
                this.playerred4.Hide();
            }
        }

        private void killplayer(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for(int i = 1; i < 16; i++)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                Thread.Sleep(DAMAGE_TIME * 1000);
                worker.ReportProgress(i+1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ttt = new Form2();
            ttt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static void Shake(PictureBox t)
        {
            var original = t.Location;
            var rnd = new Random(1337);
            const int shake_amplitude = 10;
            for (int i = 0; i < 10; i++)
            {
                t.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                System.Threading.Thread.Sleep(20);
            }
            t.Location = original;
        }

        private static void Shake(Form t)
        {
            var original = t.Location;
            var rnd = new Random(1337);
            const int shake_amplitude = 10;
            for (int i = 0; i < 10; i++)
            {
                t.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                System.Threading.Thread.Sleep(20);
            }
            t.Location = original;
        }

        private void change(object sender, ProgressChangedEventArgs e)
        {
            times += 1;
            monsterHP -= (int)score / 10;
            Shake(this.pictureBox16);
            this.label4.Text = "準確度: " + confidence.ToString("0.00");
            this.label5.Text = "時間:  " + (duration/1000).ToString();
            this.label6.Text = "攻擊力 : " + (score/10).ToString("0.00");

            average_confidence += confidence;
            average_duration += duration/1000;
            average_score += score;

            int damage = (int)score / 10;
            this.richTextBox1.Text += string.Format("狠狠的揍了怪物 {0} 滴血\n", damage);
            this.richTextBox1.Text += string.Format("  怪物剩下 {0} 滴血\n", monsterHP);
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            this.richTextBox1.ScrollToCaret();
            if ((450 - monsterHP)  > 30)
            {
                this.enemygreen1.Hide();
            }if((450 - monsterHP)  > 60)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
            }if((450 - monsterHP) > 90)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
            }
            if((450 - monsterHP)  > 120)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
            }
            if((450 - monsterHP)  > 150)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
            }
            if((450 - monsterHP)  > 180)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
            }
            if((450 - monsterHP)  > 210)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
            }
            if((450 - monsterHP)  > 240)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
            }
            if((450 - monsterHP)  > 270)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
            }
            if((450 - monsterHP)  > 300)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
                this.enemyyellow5.Hide();
            }
            if((450 - monsterHP)  > 330)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
                this.enemyyellow5.Hide();
                this.enemyred1.Hide();
            }
            if((450 - monsterHP)  > 360)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
                this.enemyyellow5.Hide();
                this.enemyred1.Hide();
                this.enemyred2.Hide();
            }
            if((450 - monsterHP)  > 390)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
                this.enemyyellow5.Hide();
                this.enemyred1.Hide();
                this.enemyred2.Hide();
                this.enemyred3.Hide();
            }
            if((450 - monsterHP)  > 420)
            {
                this.enemygreen1.Hide();
                this.enemygreen2.Hide();
                this.enemygreen3.Hide();
                this.enemygreen4.Hide();
                this.enemygreen5.Hide();
                this.enemyyellow1.Hide();
                this.enemyyellow2.Hide();
                this.enemyyellow3.Hide();
                this.enemyyellow4.Hide();
                this.enemyyellow5.Hide();
                this.enemyred1.Hide();
                this.enemyred2.Hide();
                this.enemyred3.Hide();
                this.enemyred4.Hide();
            }
            
        }

        private void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled != true))
            {
                ha.CancelAsync();
                p.CancelAsync();
                panel1.Show();
                panel2.Hide();
                panel1.Location = new Point(0, 0);
                if (monsterHP < 0)
                {
                    this.pictureBox1.Show();
                    this.pictureBox2.Hide();
                }
                else
                {
                    this.pictureBox2.Show();
                    this.pictureBox1.Hide();
                }
                this.label12.Text = (average_confidence / times).ToString("0.00");
                this.label13.Text = (average_duration / times).ToString("0.00");
                this.label14.Text = (average_score / 10 / times).ToString("0.00");
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            while (hp > 0 && monsterHP>0)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                completed = false;
                Random rnd = new Random();
                int index = rnd.Next(0, 13);


                // Indicate whether asynchronous recognition has finished.
                Console.WriteLine(Sentence[index]);

                answer = Sentence[index];
                
                
                this.richTextBox2.Text = answer;
                
                this.richTextBox2.Text += "\n 3...";
                Thread.Sleep(1000);
                this.richTextBox2.Text += "2...";
                Thread.Sleep(1000);
                this.richTextBox2.Text += "1...";
                Thread.Sleep(1000);
                this.richTextBox2.Text += "開始念!!!";
                

                using (SpeechRecognitionEngine recognizer =
                  new SpeechRecognitionEngine(new CultureInfo("zh-TW")))
                {
                    // Sentence to be said
                    Choices words = new Choices();
                    words.Add(new string[] { Sentence[index] });
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
                    worker.ReportProgress(1);
                }
            }            
        }
    }
}