using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestLogical: MonoBehaviour
{
    public Text questionText;
    public Text NumberOfLevels;
    public Text ResultsText;

    private List<TestData> questions = new List<TestData>();

    private int currentQuestionIndex = 0;
    private int numberOfQuestion = 1;

    private int Hyperthymic = 0;
    private int Anxious = 0;
    private int Dysthymic = 0;
    private int Pedantic = 0;
    private int Excitable = 0;
    private int Emotional = 0;
    private int Outdated = 0;
    private int Demonstrative = 0;
    private int Cyclothymna = 0;
    private int Exalted = 0;

    [SerializeField] private GameObject Tests;
    [SerializeField] private GameObject Results;

    private void Start()
    {
        LoadQuestionsFromJson();
        DisplayCurrentQuestion();
       
    }

    private void LoadQuestionsFromJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("TestQuestionWithKey");
        string json = jsonFile.text;
        string wrappedJson = "{\"questions\":" + json + "}";
        TestQuestionData questionData = JsonUtility.FromJson<TestQuestionData>(wrappedJson);
        questions = questionData.questions;
    }

    private void DisplayCurrentQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex].question;
            string questionKey = questions[currentQuestionIndex].key.ToString();
            int keyInt = int.Parse(questionKey);
            Debug.Log(keyInt);
        }
        else
        {
            Debug.Log("Питання закінчилися");
            Tests.SetActive(false);
            Results.SetActive(true);

            int[] scores = new int[]
            {
                Hyperthymic * 3,
                Anxious * 3,
                Dysthymic * 3,
                Pedantic * 2,
                Excitable * 3,
                Emotional * 3,
                Outdated * 2,
                Demonstrative * 2,
                Cyclothymna * 3,
                Exalted * 6
            };

            string[] resultNames = new string[]
            {
                "Гіпертимна",
                "Тривожна",
                "Дистимна",
                "Педантична",
                "Збудлива",
                "Емотивна",
                "Застаріваюча",
                "Демонстративна",
                "Циклотимна",
                "Екзальтована"
            };

            for (int i = 0; i < scores.Length; i++)
            {
                for (int j = i + 1; j < scores.Length; j++)
                {
                    if (scores[j] > scores[i])
                    {
                        int tempScore = scores[i];
                        scores[i] = scores[j];
                        scores[j] = tempScore;

                        string tempName = resultNames[i];
                        resultNames[i] = resultNames[j];
                        resultNames[j] = tempName;
                    }
                }
            }

            string resultText = " ";

            for (int i = 0; i < scores.Length; i++)
            {
                resultText += resultNames[i] + ": " + scores[i] + "\n";
            }

            ResultsText.text = resultText;
        }
    }

    public void OnNoButtonClick()
    {
        currentQuestionIndex++;
        numberOfQuestion++;
        NumberOfLevels.text = "Питання " + numberOfQuestion + "/88";
        ScoreUpdateNO();
        DisplayCurrentQuestion();
    }

    public void OnYesButtonClick()
    {
        currentQuestionIndex++;
        numberOfQuestion++;
        NumberOfLevels.text = "Питання " + numberOfQuestion + "/88";
        ScoreUpdateYES();
        DisplayCurrentQuestion();
    }

    private void ScoreUpdateYES()
    {
        string questionKey = questions[currentQuestionIndex - 1].key.ToString();
        int keyInt = int.Parse(questionKey);

        if (keyInt > 0)
        {
            if (keyInt == 1)
            {
                Hyperthymic++;
                Debug.Log("Hyperthymic: " + Hyperthymic);
            }

            if (keyInt == 2)
            {
                Anxious++;
                Debug.Log("Anxious: " + Anxious);
            }

            if (keyInt == 3)
            {
                Dysthymic++;
                Debug.Log("Dysthymic: " + Dysthymic);
            }

            if (keyInt == 4)
            {
                Pedantic++;
                Debug.Log("Pedantic: " + Pedantic);
            }

            if (keyInt == 5)
            {
                Excitable++;
                Debug.Log("Excitable: " + Excitable);
            }

            if (keyInt == 6)
            {
                Emotional++;
                Debug.Log("Emotional: " + Emotional);
            }

            if (keyInt == 7)
            {
                Outdated++;
                Debug.Log("Outdated: " + Outdated);
            }

            if (keyInt == 8)
            {
                Demonstrative++;
                Debug.Log("Demonstrative: " + Demonstrative);
            }

            if (keyInt == 9)
            {
                Cyclothymna++;
                Debug.Log("Cyclothymna: " + Cyclothymna);
            }

            if (keyInt == 10)
            {
                Exalted++;
                Debug.Log("Exalted: " + Exalted);
            }
        }
        
    }

    private void ScoreUpdateNO()
    {
        string questionKey = questions[currentQuestionIndex - 1].key.ToString();
        int keyInt = int.Parse(questionKey);

        if (keyInt < 0)
        {
            keyInt = -keyInt;

            if (keyInt == 1)
            {
                Hyperthymic++;
                Debug.Log("Hyperthymic: " + Hyperthymic);
            }

            if (keyInt == 2)
            {
                Anxious++;
                Debug.Log("Anxious: " + Anxious);
            }

            if (keyInt == 3)
            {
                Dysthymic++;
                Debug.Log("Dysthymic: " + Dysthymic);
            }

            if (keyInt == 4)
            {
                Pedantic++;
                Debug.Log("Pedantic: " + Pedantic);
            }

            if (keyInt == 5)
            {
                Excitable++;
                Debug.Log("Excitable: " + Excitable);
            }

            if (keyInt == 6)
            {
                Emotional++;
                Debug.Log("Emotional: " + Emotional);
            }

            if (keyInt == 7)
            {
                Outdated++;
                Debug.Log("Outdated: " + Outdated);
            }

            if (keyInt == 8)
            {
                Demonstrative++;
                Debug.Log("Demonstrative: " + Demonstrative);
            }

            if (keyInt == 9)
            {
                Cyclothymna++;
                Debug.Log("Cyclothymna: " + Cyclothymna);
            }

            if (keyInt == 10)
            {
                Exalted++;
                Debug.Log("Exalted: " + Exalted);
            }
        }
    }
}

