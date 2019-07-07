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
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\WordScoreExercise\Data\american-words.txt"));
            string[] actual;
            actual = Program_Accessor.ReadInputWords(path);
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
            string[] words = { "balkanizes", "food" }; 
            List<string> wordMatches = new List<string>(); 
            int requiredScore = 100; 
            Program_Accessor.BuildLetterScoreMapping();        
            Program_Accessor.FindWordsWithRequiredScore(words, wordMatches, requiredScore);
            Assert.AreEqual(wordMatches[0], "balkanizes");
        }


        /// <summary>
        ///A fail test for FindWordsWithRequiredScore
        ///</summary>
        [TestMethod()]
        [DeploymentItem("WordScoreExercise.exe")]
        public void FindWordsWithRequiredZeroScoreTest()
        {
            string[] words = { "balkanizes", "food" }; 
            Program_Accessor.BuildLetterScoreMapping();   
            List<string> wordMatches = new List<string>(); 
            int requiredScore = 0;
            Program_Accessor.FindWordsWithRequiredScore(words, wordMatches, requiredScore);
            Assert.AreEqual(wordMatches.Count,0);
            
        }

     
    }
}
