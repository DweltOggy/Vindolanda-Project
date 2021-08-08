using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public List<Question> questions;

    public List<Question> questionsEasy;
    public List<Question> questionsMed;
    public List<Question> questionsHard;

    public List<Question> questionsMix;

    public Button[] options;

    public GameObject MainScreen;
    public GameObject ScoreScreen;

    public int current;

    public int score;
    int total;

    public int reward;

    public Text QuestionText;
    public Text title;
    public Text scoreText;
    public Text winLossText;
    public Button returnButton;

    private void Start()
    {
        title.text = "Test";
        if (objectives.GameController.Instance)
        {
            switch(objectives.GameController.Instance.quizStage)
            {
                case 0:
                    questions = questionsEasy;
                    title.text = "Easy DIfficulty";
                    break;

                case 1:
                    questions = questionsMed;
                    title.text = "Medium Difficulty";
                    break;

                case 2:
                    questions = questionsHard;
                    title.text = "Hard Difficulty";
                    break;

                default:
                    questions = questionsMix;
                    title.text = "Mixed Difficulty";
                    break;
            }
        }
        score = 0;
        total = questions.Count;

        returnButton.onClick.RemoveAllListeners();
        returnButton.onClick.AddListener(returnToTavern);

        for (int i = 0; i < options.Length; i++)
        {
            Button buttonElemant = options[i];
            buttonElemant.onClick.RemoveAllListeners();
            buttonElemant.onClick.AddListener(() => buttonClick(buttonElemant));
        }
        generate();
    }

    void generate()
    {
        if (questions.Count > 0)
        {
            current = Random.Range(0, questions.Count);

            QuestionText.text = questions[current].question;
            set();
        }
        else
        {
            gameOver();
        }
    }

    void gameOver()
    {
        scoreText.text = score.ToString() + " / " + total.ToString();

        if(((float)score/(float)total) > 0.5)
        {
            winLossText.text = "You Won this Time!";
            if (objectives.GameController.Instance)
            {
                Player.Instance.addMoney(reward * objectives.GameController.Instance.quizStage);
                objectives.GameController.Instance.quizStage++;
            }
            
        }

        MainScreen.SetActive(false);
        ScoreScreen.SetActive(true);
    }

    public void correct()
    {
        questions.RemoveAt(current);
        generate();
    }

    void set()
    {
        for( int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].GetComponentInChildren<Text>().text = questions[current].answers[i];
        
            if(questions[current].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }

    public void returnToTavern()
    {
        LevelLoader.Instance.loadLevel("Tavern");
    }

    public void buttonClick(Button button)
    {
        if(button.GetComponent<Answer>().isCorrect)
        {
            Debug.Log("correct");
            score++;
            correct();
        }
        else 
        {
            correct();
            Debug.Log("wrong");
        }
    }

}
