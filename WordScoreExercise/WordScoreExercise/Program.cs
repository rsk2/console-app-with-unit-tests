using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace WordScoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int requiredScore;
            requiredScore = GetRequiredScore();
            List<string> wordMatches = new List<string>();
            string[] words;
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Data\american-words.txt"));
            words = ReadInputWords(path);
            if (words != null)
            {
                BuildLetterScoreMapping();
                FindWordsWithRequiredScore(words, wordMatches, requiredScore);
                PrintMatchedWords(wordMatches);
            }
            Console.ReadLine();
        }

        private static int GetRequiredScore()
        {
            int requiredScore;
            Console.WriteLine("Enter required word score: ");
            string line = Console.ReadLine();
            requiredScore = Convert.ToInt32(line);
            return requiredScore;
        }

        private static string[] ReadInputWords(string fileLocation)
        {
            string[] words;
           
            try
            {
                words = File.ReadAllLines(fileLocation);
                return words;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Input folder doesn't exist at the application location.");
                return null;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Input file american-words.txt doesn't exist in the Input folder.");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        private static void FindWordsWithRequiredScore(string[] words, List<string> wordMatches, int requiredScore)
        {
            for (int i = 0; i < words.Count(); i++)
            {
                Word newWord = new Word();
                newWord.WordLetters = words[i];
               
                if (newWord.WordScore == requiredScore)
                    wordMatches.Add(newWord.WordLetters);
            }
        }

        private static void PrintMatchedWords(List<string> wordMatches)
        {
            foreach (string w in wordMatches)
            {
                Console.WriteLine(w);
            }
        }

        private static void BuildLetterScoreMapping()
        {
            Dictionary<char, int> alphabetToInt = new Dictionary<char, int>();
            int punctuationStart = 32, punctuationEnd = 47, upperCaseAlphabetStart = 65, upperCaseAlphabetEnd = 90, 
                lowerCaseAlphabetStart=97,lowerCaseAlphabetEnd=122 ;


            for (int i = punctuationStart,score=0; i <= punctuationEnd; i++)
            { 
                alphabetToInt.Add(Convert.ToChar(i), score);
               
            }
            for (int i = upperCaseAlphabetStart, score = 1; i <= upperCaseAlphabetEnd; i++, score++)
            {
                alphabetToInt.Add(Convert.ToChar(i), score);
              
            }

            for (int i = lowerCaseAlphabetStart, score = 1; i <= lowerCaseAlphabetEnd; i++, score++)
            {
                alphabetToInt.Add(Convert.ToChar(i), score);
                
            }
            Word.AlphabetScores = alphabetToInt;
            Console.WriteLine();
        }
    }
}
