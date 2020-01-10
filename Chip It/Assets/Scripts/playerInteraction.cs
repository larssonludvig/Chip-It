using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private readonly GameManager instance;
    public static PlayerInteraction interaction;

    public Vector2 lastPosition;

    // Variables for the mouse
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 newVelocity;
    private readonly int speedMultiplier = 6;

    /// <summary>
    /// Starts an instance
    /// </summary>
    private void Start() {
        interaction = this;
    }

    /// <summary>
    /// Upadtes the last location of the player
    /// </summary>
    private void Update() {
        if (this.GetComponent<Rigidbody2D>().velocity.x == 0 && this.GetComponent<Rigidbody2D>().velocity.y == 0 && this.lastPosition != this.GetComponent<Rigidbody2D>().position) {
            this.lastPosition = this.GetComponent<Rigidbody2D>().position;
        }
    }


    /// <summary>
    /// Checks if mouse button 1 is pressed down
    /// </summary>
    private void OnMouseDown() {
        this.startPosition = Input.mousePosition;
        this.startPosition = Camera.main.ScreenToWorldPoint(this.startPosition); // Converts mouse positioning from screen to world
    }

    /// <summary>
    /// Checks if mouse button 1 is released
    /// </summary>
    private void OnMouseUp() {
        this.endPosition = Input.mousePosition;
        this.endPosition = Camera.main.ScreenToWorldPoint(this.endPosition); // Converts mouse positioning from screen to world 

        if (this.GetComponent<Rigidbody2D>().velocity.x <= 0.1 && this.GetComponent<Rigidbody2D>().velocity.y <= 0.1 && GameManager.instance.finish != true) {
            this.newVelocity = VelocityCalculation(this.startPosition, this.endPosition);
            this.GetComponent<Rigidbody2D>().velocity = this.newVelocity;
            GameManager.instance.IncreaseScore();
        }
    }

    /// <summary>
    /// Calculates the differences between start and end position for mouse and produce a new velocity
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private Vector2 VelocityCalculation(Vector2 start , Vector2 end) {
        Vector2 velocity = start;
        velocity.x = -(end.x - start.x) * this.speedMultiplier;
        velocity.y = -(end.y - start.y) * this.speedMultiplier;
        return velocity;
    }
}
