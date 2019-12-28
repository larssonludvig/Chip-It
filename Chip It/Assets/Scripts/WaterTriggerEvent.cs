using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaterTriggerEvent: MonoBehaviour
{
    private readonly GameManager manager;
    private readonly PlayerInteraction instance;
    private readonly int delay = 2000;
    private Vector2 resetVelocity;

    /// <summary>
    /// Checks for collision
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            await Task.Delay(delay);
            if (collision.CompareTag("Player")) {
                SetBackPlayer();
            }
        }
    }

    /// <summary>
    /// Sets the player back to last location and adds 1 to the score
    /// </summary>
    public void SetBackPlayer()
    {
        PlayerInteraction.interaction.GetComponent<Rigidbody2D>().position = PlayerInteraction.interaction.lastPosition;
        PlayerInteraction.interaction.GetComponent<Rigidbody2D>().velocity = resetVelocity;
        GameManager.instance.IncreaseScore();
    }
}
