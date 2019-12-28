using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public readonly PlayerInteraction interaction;

    private int score = 0;

    public bool finish = false;
    private int once = 0;

    /// <summary>
    /// Starts an instance
    /// </summary>
    private void Start() {
        instance = this;
    }

    /// <summary>
    /// Checks if game is still live
    /// </summary>
    private void Update(){
        if (this.finish != false && this.once == 0) {
            Debug.Log("GOOOLE!");
            this.once++;
        }
    }

    /// <summary>
    /// Increases the score by 1
    /// </summary>
    public void IncreaseScore() {
        score++;
        Debug.Log(score);
    }

    /// <summary>
    /// Game is stoped due to end of hole.
    /// </summary>
    public void StopGame() {
        GameManager.instance.finish = true;
    }
}
