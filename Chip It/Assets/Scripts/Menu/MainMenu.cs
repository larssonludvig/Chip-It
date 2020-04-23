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

    /// <summary>
    /// Loads level 4
    /// </summary>
    public void LevelFour()
    {
        SceneManager.LoadScene(4);
    }

    /// <summary>
    /// Loads level 5
    /// </summary>
    public void LevelFive()
    {
        SceneManager.LoadScene(5);
    }

    /// <summary>
    /// Loads level 6
    /// </summary>
    public void LevelSix()
    {
        SceneManager.LoadScene(6);
    }

    /// <summary>
    /// Loads level 7
    /// </summary>
    public void LevelSeven()
    {
        SceneManager.LoadScene(7);
    }

    /// <summary>
    /// Loads level 8
    /// </summary>
    public void LevelEight()
    {
        SceneManager.LoadScene(8);
    }

    /// <summary>
    /// Loads level 9
    /// </summary>
    public void LevelNine()
    {
        SceneManager.LoadScene(9);
    }

    /// <summary>
    /// Loads level 10
    /// </summary>
    public void LevelTen()
    {
        SceneManager.LoadScene(10);
    }
}
