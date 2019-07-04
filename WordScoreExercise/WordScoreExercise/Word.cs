using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordScoreExercise
{
    class Word
    {
        private int _wordScore = -1;
        public string WordLetters { get; set; }

        public static Dictionary<char, int> AlphabetScores { get; set; }

        public int WordScore
        {
            get
            {
                if (_wordScore == -1)
                {
                    CalculateScore();
                    return _wordScore;
                }
                else
                {
                    return _wordScore;
                }

            }

        }

        public void CalculateScore()
        {
            int score = 0;
            foreach (char wordLetter in this.WordLetters)
            {
                score += AlphabetScores[wordLetter];
            }
            this._wordScore = score;
            //return score;
        }

    }
}
