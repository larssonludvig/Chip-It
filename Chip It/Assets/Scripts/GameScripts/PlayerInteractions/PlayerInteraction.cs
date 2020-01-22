using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerInteraction : MonoBehaviour
{
    private readonly GameManager instance;
    public static PlayerInteraction interaction;

    public Vector2 lastPosition;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 newVelocity;
    private Vector2 resetVelocity;
    private readonly int speedMultiplier = 6;
    public bool pressed = false;
    public bool triggerBox = false;

    /// <summary>
    /// Starts an instance
    /// </summary>
    private void Start() {
        interaction = this;
        resetVelocity = this.GetComponent<Rigidbody2D>().velocity;
        this.lastPosition = this.GetComponent<Rigidbody2D>().position;
    }

    /// <summary>
    /// Runs every update
    /// </summary>
    private async void Update() {
        // Resets the velocity if it is to low
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.15 && this.lastPosition != this.GetComponent<Rigidbody2D>().position && this.GetComponent<Rigidbody2D>().velocity != this.resetVelocity) {
            await Task.Delay(200);
            if (this.GetComponent<Rigidbody2D>().velocity.magnitude < 0.15) {
                ResetVelocity();
                if (!this.triggerBox) {
                    this.lastPosition = this.GetComponent<Rigidbody2D>().position;
                }
            }
        }
    }

    /// <summary>
    /// Checks if mouse button 1 is pressed down
    /// </summary>
    private void OnMouseDown() {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude == 0) {
            this.startPosition = Input.mousePosition;
            this.startPosition = Camera.main.ScreenToWorldPoint(this.startPosition); // Converts mouse positioning from screen to world
            this.pressed = true;
        }
    }

    /// <summary>
    /// Checks if mouse button 1 is released
    /// </summary>
    private void OnMouseUp() {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude == 0 && GameManager.instance.finish != true) {
            this.endPosition = Input.mousePosition;
            this.endPosition = Camera.main.ScreenToWorldPoint(this.endPosition); // Converts mouse positioning from screen to world 
            this.newVelocity = VelocityCalculation(this.startPosition, this.endPosition);
            this.GetComponent<Rigidbody2D>().velocity = this.newVelocity;
            GameManager.instance.IncreaseScore();
            this.pressed = false;
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

    /// <summary>
    /// Resets the velocity of the player
    /// </summary>
    public void ResetVelocity() {
        this.GetComponent<Rigidbody2D>().velocity = this.resetVelocity;
    }
}
