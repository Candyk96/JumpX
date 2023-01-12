using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour {


	public void startGame()
    {
        SceneManager.LoadScene("Map1");
    }

    
    public void quitGame()
    {
        Application.Quit();
    }

}
