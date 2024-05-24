using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject optionspanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("I am in play");
    }

    public void Options()
    {
        optionspanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit(); // why
        //Debug.Log("I am in quit this is jyst for me poopy");
    }

}
