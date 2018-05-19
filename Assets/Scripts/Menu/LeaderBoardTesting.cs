using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardTesting : MonoBehaviour {

    struct TestCase {
        public int firstPScore;
        public int secondPScore;
        public int[] highscores;
        public int[] resultingHighscores;
    }

    public static void TestAwake() {
        TestCase[] tests = new TestCase[2];

        //test number 0
        {
            tests[0].firstPScore = 1000;
            tests[0].secondPScore = 10001;
            tests[0].highscores = new int[10];
            for (int i = 0; i < tests[0].highscores.Length; i++) {
                tests[0].highscores[i] = (i + 1) * 1000;
            }
            {
                tests[0].resultingHighscores = new int[10];
                for (int i = 0; i < tests[0].highscores.Length - 1; i++) {
                    tests[0].resultingHighscores[i] = (i + 2) * 1000;
                }
                tests[0].resultingHighscores[9] = tests[0].secondPScore;
            }
        }

        {
            tests[1].firstPScore = 5000;
            tests[1].secondPScore = 5000;
            tests[1].highscores = new int[10];
            for (int i = 0; i < tests[0].highscores.Length; i++)
            {
                tests[1].highscores[i] = (i + 1) * 1000;
            }
            {
                tests[1].resultingHighscores = new int[10];
                for (int i = 0; i < tests[0].highscores.Length; i++)
                {
                    tests[1].resultingHighscores[i] = (i + 1) * 1000;
                }
                tests[1].resultingHighscores[3] = tests[1].secondPScore;
                tests[1].resultingHighscores[2] = tests[1].firstPScore;
                tests[1].resultingHighscores[1] = 4000;
                tests[1].resultingHighscores[0] = 3000;
            }
        }

        if (!TestAwake(tests)) Debug.LogError("Test cases do not return expected values in LeaderBoardTesting!");
    }

    static bool TestAwake(TestCase[] cases) {
        foreach (TestCase tc in cases) {
            int[] temp = TestAwake(tc.firstPScore, tc.secondPScore, tc.highscores);
            for(int i = 0; i < temp.Length; i++) {
                if(temp[i] != tc.resultingHighscores[i]) return false;
            } 
        }
        return true;
    }

    static int[] TestAwake(int firstPlayerScore, int secondPlayerScore, int[] highscores) {
        //int[] highscores = new int[10];

        for (int i = highscores.Length - 1; i >= 0; i--) {
            if (highscores[i] < firstPlayerScore) {
                ReplaceScoreTesting(i, firstPlayerScore, highscores);
                break;
            }
        }

        for (int i = highscores.Length - 1; i >= 0; i--) {
            if (highscores[i] < secondPlayerScore) {
                ReplaceScoreTesting(i, secondPlayerScore, highscores);
                break;
            }
        }
        return highscores;
    }

    static void ReplaceScoreTesting(int index, int valueToPlace, int[] array) {
        int a = array[index];
        array[index] = valueToPlace;

        if (index > 0) {
            ReplaceScoreTesting(index - 1, a, array);
        }
    }
}
