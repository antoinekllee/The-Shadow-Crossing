using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour {

    public string newGameScene;

    public GameObject continueButton;
    public GameObject newGameButton; 

    public string loadGameScene;

    public GameObject saveMenu; 

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Current_Scene"))
        {
            continueButton.SetActive(true);
        } else
        {
            continueButton.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Continue()
    {
        SceneManager.LoadScene(loadGameScene); 
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene); 
    }

    public void OpenNewGameMenu()
    {
        saveMenu.SetActive(true); 
    }

    public void CloseNewGameMenu()
    {
        saveMenu.SetActive(false); 
    }

    public void Exit()
    {
        Application.Quit(); 
    }
}
