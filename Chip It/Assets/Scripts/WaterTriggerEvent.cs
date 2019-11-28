using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaterTriggerEvent: MonoBehaviour
{
    private readonly PlayerInteraction instance;
    private Vector2 resetVelocity;

    /// <summary>
    /// Checks for collision
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            await Task.Delay(2000);
            SetBackPlayer();
        }
    }

    /// <summary>
    /// Sets the player back to last location and adds 1 to the score
    /// </summary>
    public void SetBackPlayer() {
        PlayerInteraction.instance.GetComponent<Rigidbody2D>().position = PlayerInteraction.instance.lastPosition;
        PlayerInteraction.instance.GetComponent<Rigidbody2D>().velocity = resetVelocity;
        PlayerInteraction.instance.IncreaseScore();
    }
}
