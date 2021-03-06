﻿using System;
using System.Speech.Recognition;
using System.Globalization;
using System.Threading;

namespace program
{
    class Program
    {
        // Indicate whether asynchronous recognition has finished.
        static bool completed;
        static String Sentence = "紅豆生南國";
        static void Main(string[] args)
        {

            using (SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine(new CultureInfo("zh-TW")))
            {

                // Create and load the exit grammar.
                Grammar exitGrammar = new Grammar(new GrammarBuilder("離開"));
                exitGrammar.Name = "Exit Grammar";
                recognizer.LoadGrammar(exitGrammar);

                // Sentence to be said
                Choices words = new Choices();
                words.Add(new string[] { Sentence });
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
                Thread.Sleep(TimeSpan.FromSeconds(3));
                recognizer.RecognizeAsyncCancel();
                Console.WriteLine("Done.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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

            /*  Console.WriteLine("  Audio level - ");
            foreach (var haha in e.Result.Alternates)
             {
                 Console.WriteLine("FCUK" + haha.Text);
                 foreach (var qq in haha.ReplacementWordUnits)
                 {

                 }
             }
             */

            if (e.Result.Text == Sentence)
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