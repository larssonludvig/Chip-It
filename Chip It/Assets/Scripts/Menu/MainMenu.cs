using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Closes the game
    /// </summary>
    public void Quitgame() {
        Application.Quit();
    }

    /// <summary>
    /// Loads level 1
    /// </summary>
    public void LevelOne() {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Loads level 2
    /// </summary>
    public void LevelTwo(){
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Loads level 3
    /// </summary>
    public void LevelThree() {
        SceneManager.LoadScene(3);
    }
}
