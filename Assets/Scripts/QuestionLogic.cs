using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Required for Scene switching

public class QuestionLogic : MonoBehaviour
{
    public int currentQuestionIndex = 0 ;
    public int score;
    public Question currentQuestion;
    public List<Question> QuestionList;

    public TextMeshProUGUI questionTextDisplay;
    public TextMeshProUGUI buttonOneDisplay;
    public TextMeshProUGUI buttonTwoDisplay;

    public GameObject EndImage;
    public Sprite winSprite;
    public Sprite loseSprite;

    public TextMeshProUGUI timerDisplay;
    public bool gameRunning = false;
    public float timeRemaining;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameRunning = true;
        EndImage.SetActive(false);
        LoadQuestion(QuestionList[0]);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameRunning)
        {

            timeRemaining -= Time.deltaTime;

            float displaytime = Mathf.CeilToInt(timeRemaining);

            timerDisplay.text = displaytime.ToString();

            if (timeRemaining < 0)
            {
                LoseQuestion();
            }
        }
        else 
        {
            timerDisplay.gameObject.SetActive(false);
        }


    }


    public void LoadQuestion(Question question)
    {
        currentQuestion = question;
        timeRemaining = 5;
        questionTextDisplay.text = question.questionText;
        buttonOneDisplay.text = question.awnsers[0].text;
        buttonTwoDisplay.text = question.awnsers[1].text;
    }

    public void PressAwnserButton(int buttonID) 
    {

        if (currentQuestion.awnsers[buttonID].isCorrect) { WinQuestion(); }
        else { LoseQuestion(); }

    
    }

    public void WinQuestion() 
    {

        score++;
        currentQuestionIndex++;

        if (currentQuestionIndex >= QuestionList.Count) 
        {
            EndGame();
            SceneManager.LoadScene(sceneName:"Dialogue");
            return;
        }

        LoadQuestion(QuestionList[currentQuestionIndex]);
    }

    public void LoseQuestion()
    {

        score--;
        currentQuestionIndex++;


        if (currentQuestionIndex >= QuestionList.Count)
        {
            EndGame();
            return;
        }


        LoadQuestion(QuestionList[currentQuestionIndex]);

    }

    public void EndGame() 
    {
        gameRunning = false;
        EndImage.SetActive(true);

        if (score > 2) 
        {
            EndImage.GetComponent<Image>().sprite = winSprite;
            
        }
        else 
        {
            EndImage.GetComponent<Image>().sprite = loseSprite;
        }
    
    
    }


}
