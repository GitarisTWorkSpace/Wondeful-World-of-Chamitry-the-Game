using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject inputField;       // Input for nickname
    public GameObject panelOfSettings;  // Settings Panel
    public string playerName;           // Player's nickname
    private int countSpeech;            // Dialog count
    private bool settingsActive;        // Is the settings panel active

    // The game continuation button takes you to the main stage
    public void ContinueGameButton()
    {
        SceneManager.LoadScene(2);
    }

    // The settings panel button activates and deactivates it
    public void ButtonOfSettings()
    {
        if (!settingsActive)
            settingsActive = true;
        else
        {
            panelOfSettings.SetActive(false);
            settingsActive = false;
        }
    }


    // Exit game button
    public void ExitGameButton()
    {
        Application.Quit();
    }


    // New Game button
    public void NewGameButton()
    {
        countSpeech = 0; // Reset the counter
        playerName = inputField.GetComponent<Text>().text; // Entering the player's nickname

        // If the player does not enter anything or enters a space, then the nickname automatically gets the value
        if (playerName == "" || playerName == " ")
            playerName = "(O_O)";

        SetInformationOfGame(); // Saving game information

        SceneManager.LoadScene(1); // Loading the opening scene
    }


    // Saving game information
    private void SetInformationOfGame()
    {
        PlayerPrefs.SetInt("countSpeech", countSpeech);
        PlayerPrefs.SetString("playerName", playerName);
    }
}
