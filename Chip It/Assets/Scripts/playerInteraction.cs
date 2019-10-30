using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Variables for the mouse
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 newVelocity;
    private float speedMultiplier = 5;

    // Start is called before the first frame update
    private void Start() {}

    // Update is called once per frame
    private void Update() { }

    // Checks if mouse button 1 is pressed down
    private void OnMouseDown() {
        this.startPosition = Input.mousePosition;
        this.startPosition = Camera.main.ScreenToWorldPoint(this.startPosition); // Converts mouse positioning from screen to world
    }

    // Checks if mouse button 1 is released
    private void OnMouseUp() {
        this.endPosition = Input.mousePosition;
        this.endPosition = Camera.main.ScreenToWorldPoint(this.endPosition); // Converts mouse positioning from screen to world 

        if (this.GetComponent<Rigidbody2D>().velocity.x == 0 && this.GetComponent<Rigidbody2D>().velocity.y == 0) {
            this.newVelocity = VelocityCalculation(this.startPosition, this.endPosition);

            this.GetComponent<Rigidbody2D>().velocity = this.newVelocity;
        }
    }

    // Runs when mouse 1 is pressed
    private void OnMouseDrag() {}

    // Calculates the differences between start and end position for mouse and produce a new velocity
    private Vector2 VelocityCalculation(Vector2 start , Vector2 end) {
        Vector2 velocity = start;
        velocity.x = -(end.x - start.x) * this.speedMultiplier;
        velocity.y = -(end.y - start.y) * this.speedMultiplier;
        return velocity;
    }
}
