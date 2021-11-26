using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This method will trigger when we click the play button
   public void OnClickingPlay()
    {
        SceneManager.LoadScene("Level1");
    }

    //This method will trigger when we click the Quit button
    public void OnClickingQuit()
    {
        Debug.Log("You are out of the game");
        Application.Quit();
    }
}
