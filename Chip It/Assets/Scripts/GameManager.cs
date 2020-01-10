using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private readonly PlayerInteraction interaction;

    private int score = 0;

    private Vector2 resetVelocity;

    public bool finish = false;

    public GameObject completeLevelUI;

    /// <summary>
    /// Starts an instance
    /// </summary>
    private void Start() {
        instance = this;
    }

    /// <summary>
    /// Checks if game is still live
    /// </summary>
    private void Update() {
        if (Input.GetKeyDown("escape")) {
            Application.Quit();
        }
    }

    /// <summary>
    /// Increases the score by 1
    /// </summary>
    public void IncreaseScore() {
        score++;
    }

    public int GetScore() {
        return score;
    }

    /// <summary>
    /// Sets the player back to last location and adds 1 to the score
    /// </summary>
    public void SetBackPlayer() {
        PlayerInteraction.interaction.GetComponent<Rigidbody2D>().position = PlayerInteraction.interaction.lastPosition;
        PlayerInteraction.interaction.GetComponent<Rigidbody2D>().velocity = resetVelocity;
        GameManager.instance.IncreaseScore();
    }

    /// <summary>
    /// Game is stoped due to end of hole.
    /// </summary>
    public void LevelComplete() {
        this.finish = true;
        completeLevelUI.SetActive(true);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }
}
