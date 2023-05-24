//NIKS AAN VERANDEREN ANDERS GAAT KAPOET

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quizmanager : MonoBehaviour
{

    //List of questions
    public List<QuestionsAndAnswers> QnA;

    //reference for the options
    public GameObject[] options;

    //current question index
    public int currentQuestion;

    //reference to the quizpanel
    public GameObject Quizpanel;

    //reference to the resultscreen
    public GameObject Resultscreen;

    //reference to the retry button
    public GameObject retryButton;

    //reference to the proceed button
    public GameObject proceedButton;

    public Image QuestionImage;

    //reference for question text
    public Text QuestionTxt;

    //reference to the score text component
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    //on start, 
    private void Start()
    {
        //get the total questions count
        totalQuestions = QnA.Count;

        //set the result screen to false
        Resultscreen.SetActive(false);

        //start generating the first question
        generateQuestion();
    }

    public void retry()
    {
        //on retry, get the active scene and reload that into the index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void proceed()
    {
        Debug.Log("dit werkt lmao");
    }

    //on gameover, set the quizpanel to false and the resultscreen to true
    void GameOver()
    {
        Quizpanel.SetActive(false);
        Resultscreen.SetActive(true);

        ScoreTxt.text = score + "/" + totalQuestions;

        //if score is lower than given number
        if (score < 1)
        {
            //set proceed button to false, retrybutton to true
            proceedButton.SetActive(false);
            retryButton.SetActive(true);
        }
        else
        {
            //otherwise set proceedbutton to true and retrybutton to false
            proceedButton.SetActive(true);
            retryButton.SetActive(false);
        }
    }

    public void correct()
    {
        //add one to the score when you answer correct
        score += 1;

        //remove question that has been taken from the list so it wont be reused
        QnA.RemoveAt(currentQuestion);

        //generate a new question
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //remove question that has been taken from the list so it wont be reused
        QnA.RemoveAt(currentQuestion);

        //generate a new question
        StartCoroutine(waitForNext());
    }

    //wait a second before proceeding to the next question to show whether the question has been answered correctly or not
    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //get the image component                //set the starting color of the buttons
            options[i].GetComponent<Image>().color = options[i].GetComponent<Answerscript>().NormalColor;

            //set all buttons to not correct right before the question loads or during question changing
            options[i].GetComponent<Answerscript>().isCorrect = false;
            //                   get the text component of the buttons    //replace the text with answers
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            //make the buttons clickable again
            options[i].gameObject.GetComponent<Button>().interactable = true;

            //if the question has been answered correctly, go to next question
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                //set the button with the correct answer to true
                options[i].GetComponent<Answerscript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            //grab a random question from the QnA list
            currentQuestion = Random.Range(0, QnA.Count);

            //replace the text with the question asked
            QuestionTxt.text = QnA[currentQuestion].Question;

            QuestionImage.sprite = QnA[currentQuestion].image;

            //set the answers   
            SetAnswers();
        }
        else
        {
            Debug.Log("Geen vragen meer");

            GameOver();
        }



    }
}
