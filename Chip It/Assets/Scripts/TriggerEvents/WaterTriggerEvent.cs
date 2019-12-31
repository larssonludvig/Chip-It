using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaterTriggerEvent: MonoBehaviour
{
    private readonly GameManager instance;
    private readonly int delay = 2000;

    /// <summary>
    /// Checks for collision
    /// </summary>
    /// <param name="collision"></param>
    private async void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            await Task.Delay(delay);
            if (collision.CompareTag("Player")) {
                GameManager.instance.SetBackPlayer();
            }
        }
    }
}
