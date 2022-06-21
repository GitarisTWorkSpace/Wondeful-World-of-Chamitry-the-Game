using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SixthTaskScript : MonoBehaviour
{
    public Text taskText;                           // The text of the task displayed on the screen
    public Text incorrectText;                      // The text that is displayed if the player answered incorrectly
    public GameObject imageAnswer;                  // Image with the answer
    public GameObject inputFieldFourth;             // Text Input objects
    public GameObject inputFieldFifth;              //
    public GameObject table;                        // Solubility table
    public string playerName;                       // Player's nickname
    public int answerView;                          // Will the answers be visible
    public float cooldownOutputTime = 1.5f;         // The time after which the error message text disappears
    private float nextOutputTime = 0f;              // The time after which the text disappears
    private bool scoreOne, scoreTwo, scoreThree;    // Did the player answer correctly
    private string textFourth, textFifth;           // Player's entered text
    private int count = 1;                          // Number of player errors
    private bool tableActive;                       // Is the table active

    // The button activates and deactivates the table
    public void ButtonOfTable()
    {
        if (!tableActive)
            tableActive = true;
        else
        {
            table.SetActive(false);
            tableActive = false;
        }
    }

    // Reads the value from the Dropdown UI element
    public void AnswerOne(int value)
    {
        // The correctness of the player's answer is checked
        if (value == 1)
            scoreOne = true;
        else
            scoreOne = false;
    }

    // Reads the value from the Dropdown UI element
    public void AnswerTwo(int value)
    {
        // The correctness of the player's answer is checked
        if (value == 2)
            scoreTwo = true;
        else
            scoreTwo = false;
    }

    // Reads the value from the Dropdown UI element
    public void AnswerThree(int value)
    {
        // The correctness of the player's answer is checked
        if (value == 2)
            scoreThree = true;
        else
            scoreThree = false;
    }

    // Getting the entered text
    public void GetInputText()
    {
        textFourth = inputFieldFourth.GetComponent<Text>().text;
        textFifth = inputFieldFifth.GetComponent<Text>().text;
    }

    // The button responsible for checking the response
    public void ButtonCheckAnswer()
    {
        GetInputText();

        // If the player answered correctly, then he returns to the dialogue scene, otherwise the text is displayed stating that he made a mistake.
        if (scoreOne && scoreTwo && scoreThree && textFourth == "Барий" && textFifth == "N")
            SceneManager.LoadScene(2);
        else
        {
            // Time of text disappearance
            nextOutputTime = Time.time + cooldownOutputTime;
            AnswerView();
        }
    }

    // Shows the response if the value of the desired variable matches
    private void AnswerView()
    {
        // Checking the variable and the number of errors
        if (answerView == 1 && count <= 3)
        {
            // A message to the player that he made a mistake so many times
            incorrectText.text = "Неверно " + count + "/3";
            count++;
        }
        else if (answerView == 0 || count > 3)
        {
            incorrectText.text = "Неправильно";
        }
        // After 3 frivolous answers, a picture with the correct answers will be displayed
        if (count == 3)
            imageAnswer.SetActive(true);
    }

    // Getting information
    private void GetInformationOfGame()
    {
        playerName = PlayerPrefs.GetString("playerName");
        taskText.text = AllTextScript.questionText[5];
    }

    // Start is called before the first frame update
    void Start()
    {
        GetInformationOfGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Getting information about whether to output a response after 3 errors
        answerView = PlayerPrefs.GetInt("answerView");
        // Deleting Text
        if (Time.time > nextOutputTime)
            incorrectText.text = "";
    }
}
