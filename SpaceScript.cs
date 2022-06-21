using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceScript : MonoBehaviour
{
    public Text openingText;                // The text of the opening scene
    public Text closingText;                // The text of the final scene
    public GameObject roket;                // Image of a rocket
    public AudioSource sound;               // Music
    private Animation anim;                 // Animation for the rocket
    public string playerName;               // Player's nickname
    public int countSpeech;                 // Dialog count
    public float cooldownOutputTime = 6f;   // The time after which the text will be switched
    private float nextOutputTime = 0f;      // The time after which the text is switched
    private float volume;                   // Volume
    private int count = 0;                  // Number of subtitles

    // Switching text in the opening scene
    private void OutputOpenningText()
    {
        // When will the next switch be
        nextOutputTime = Time.time + cooldownOutputTime;


        // Getting information about Animation
        anim = roket.GetComponent<Animation>();

        // Music volume
        sound.volume = volume;

        // Switching text, starting sound and animation
        switch (count)
        {
            case 3: openingText.text = AllTextScript.spaceText[count]; anim.Play("RoketAnimation"); sound.Play(); break;
            case 6: SceneManager.LoadScene(2); break;
            default: openingText.text = AllTextScript.spaceText[count]; break;
        }
        count++;
    }


    // Switching text in the final scene
    private void OutputClosingText()
    {
        // When will the next switch be
        nextOutputTime = Time.time + cooldownOutputTime;

        // Getting information about Animation
        anim = roket.GetComponent<Animation>();

        // Music volume
        sound.volume = volume;

        // Switching text, starting sound and animation
        switch (count)
        {
            case 0: closingText.text = AllTextScript.endText[count]; anim.Play(); sound.Play(); break;
            case 4: SceneManager.LoadScene(0); break;
            default: closingText.text = AllTextScript.endText[count]; break;
        }
        count++;
    }

    // The button for skipping the opening scene
    public void ButtonSkip()
    {
        SceneManager.LoadScene(2);
    }

    // The button for skipping a scene in the final scene
    public void ButtonEnd()
    {
        SceneManager.LoadScene(0);
    }

    // Getting information
    private void GetInformationOfGame()
    {
        playerName = PlayerPrefs.GetString("playerName");
        countSpeech = PlayerPrefs.GetInt("countSpeech");
        volume = PlayerPrefs.GetFloat("volume");
    }

    // Start is called before the first frame update
    void Start()
    {
        GetInformationOfGame();
    }


    // Update is called once per frame
    void Update()
    {
        // If the dialog counter is 0, then the opening scene is started, otherwise the final one
        if (countSpeech == 0)
            if (Time.time > nextOutputTime)
                OutputOpenningText();
        else if (countSpeech > 1)
            if (Time.time > nextOutputTime)
                OutputClosingText();
    }
}
