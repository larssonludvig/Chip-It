using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoleTriggerEvent : MonoBehaviour
{
    private readonly GameManager instance;
    private readonly PlayerInteraction interaction;
    private Vector2 resetVelocity;
    private bool active = false;
    private readonly int delay = 2000;

    /// <summary>
    /// Checks for collision
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        this.active = true;
        
        PlayerInteraction.interaction.triggerBox = true;
        await Task.Delay(this.delay);
        if (this.active) {
            GameManager.instance.LevelComplete();
            PlayerInteraction.interaction.triggerBox = false;
        }
    }

    /// <summary>
    /// Checks if the player leaves the triggerbox
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.active = false;
    }
}
