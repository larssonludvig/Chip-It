using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    // Variables for the mouse
    private Vector2 startPosition;
    private Vector2 endPosition;

    // Start is called before the first frame update
    private void Start() {}

    // Update is called once per frame
    private void Update() {}

    // Checks if mouse button 1 is pressed down
    private void OnMouseDown() {
        startPosition = Input.mousePosition;
        startPosition = Camera.main.ScreenToWorldPoint(startPosition); // Converts mouse positioning from screen to world

        Debug.Log(startPosition);
    }

    // Checks if mouse button 1 is released
    private void OnMouseUp() {
        endPosition = Input.mousePosition;
        endPosition = Camera.main.ScreenToWorldPoint(endPosition); // Converts mouse positioning from screen to world

        Debug.Log(endPosition);
        Debug.Log(VectorCalculation(startPosition, endPosition));
    }

    // Runs when mouse 1 is pressed
    private void OnMouseDrag() {}

    // Calculates the differences between x1 and x2 and the same for y
    private Vector2 VectorCalculation(Vector2 start , Vector2 end) {
        Vector2 difference = start;
        difference.x = -(end.x - start.x);
        difference.y = -(end.y - start.y);
        return difference;
    }
}
