using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OutOfBoundsTriggerEvent: MonoBehaviour
{
    private readonly GameManager instance;
    private readonly PlayerInteraction interaction;
    private readonly int delay = 2000;

    /// <summary>
    /// Checks for collision
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            PlayerInteraction.interaction.triggerBox = true;
            await Task.Delay(this.delay);
            GameManager.instance.SetBackPlayer();
            PlayerInteraction.interaction.triggerBox = false;
        }
    }
}
