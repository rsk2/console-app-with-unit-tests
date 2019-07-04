using WordScoreExercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WordScoreExerciseUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ProgramTest and is intended
    ///to contain all ProgramTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ReadInputWords
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WordScoreExercise.exe")]
        public void ReadInputWordsTest()
        {
            
            String fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
             String fullAppPath = Path.GetDirectoryName(fullAppName);
            string path = fullAppPath+ @"\Input\american-words.txt";
            string localPath = new Uri(path).LocalPath;
            string[] actual;
            actual = Program_Accessor.ReadInputWords(localPath);
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///A test for BuildLetterScoreMapping
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WordScoreExercise.exe")]
        public void BuildLetterScoreMappingNotNullTest()
        {           
            Program_Accessor.BuildLetterScoreMapping();           
            Assert.IsNotNull(Word.AlphabetScores);
          }

        /// <summary>
        ///A test for FindWordsWithRequiredScore
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WordScoreExercise.exe")]
        public void FindWordsWithRequiredScoreTest()
        {
            string[] words = { "balkanizes", "food" }; // TODO: Initialize to an appropriate value
            //List<Word_Accessor> inputWords = null; // TODO: Initialize to an appropriate value
            List<string> wordMatches = new List<string>(); // TODO: Initialize to an appropriate value
            int requiredScore = 100; // TODO: Initialize to an appropriate value
            Program_Accessor.BuildLetterScoreMapping();        
            Program_Accessor.FindWordsWithRequiredScore(words, wordMatches, requiredScore);
            Assert.AreEqual(wordMatches[0], "balkanizes");
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A fail test for FindWordsWithRequiredScore
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WordScoreExercise.exe")]
        public void FindWordsWithRequiredZeroScoreTest()
        {
            string[] words = { "balkanizes", "food" }; // TODO: Initialize to an appropriate value
            //List<Word_Accessor> inputWords = null; // TODO: Initialize to an appropriate value
            Program_Accessor.BuildLetterScoreMapping();   
            List<string> wordMatches = new List<string>(); // TODO: Initialize to an appropriate value
            int requiredScore = 0; // TODO: Initialize to an appropriate value
            Program_Accessor.FindWordsWithRequiredScore(words, wordMatches, requiredScore);
            Assert.AreEqual(wordMatches.Count,0);
            
        }

     
    }
}
