using UnityEngine;
using UnityEngine.UI;

public class Answerscript : MonoBehaviour
{
    //button is set to false by default if not correct
    public bool isCorrect = false;

    //reference to quizmanager
    public quizmanager quizmanager;

    public Color NormalColor = new Color32(65, 65, 65, 255);
      
    public Button button1, button2, button3, button4;

    public Button[] buttons;

    private void Start()
    {
        //set the starting color to a specific color, grey in this case
        button1.GetComponent<Button>();
        button2.GetComponent<Button>();
        button3.GetComponent<Button>();
        button4.GetComponent<Button>();

        //startColor = GetComponent<Image>().color = new Color32(65, 65, 65, 255);
    }

    private void Update()
    {
        buttons = new Button[]
        {
            button1, button2, button3, button4
        };
    }

    public void disableButton()
    {
        foreach(Button button in buttons)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void Answer()
    {
        if (isCorrect)
        {
            //after the button has been clicked, make it unclickable
            //gameObject.GetComponent<Button>().interactable = false;
            disableButton();
            //set color of button to green
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct answer");            
            quizmanager.correct();
        }
        else
        {
            //after the button has been clicked, make it unclickable
            //gameObject.GetComponent<Button>().interactable = false;
            disableButton();
            //set color of button to red
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong answer u asshat");
            quizmanager.wrong();
        }
    }
}
