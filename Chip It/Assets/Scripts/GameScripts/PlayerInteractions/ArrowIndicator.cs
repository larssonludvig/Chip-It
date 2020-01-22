using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    private PlayerInteraction interaction;
    private Vector2 resetPosition;
    public static ArrowIndicator indicator;

    public Vector2 start;
    public Vector2 end;
    public double arrowScale;
    public int arrowScaleMultiplier = 2;
    public bool mouseDown = false;

    /// <summary>
    /// Runs when instance starts
    /// </summary>
    private void Start() {
        indicator = this;
        this.resetPosition = GetComponent<Transform>().position;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (PlayerInteraction.interaction.pressed) {
            // Button input
            if (Input.GetMouseButtonDown(0)) {
                GetComponent<Transform>().position = PlayerInteraction.interaction.lastPosition;
                this.start = Input.mousePosition;
                this.start = Camera.main.ScreenToWorldPoint(this.start); // Converts mouse positioning from screen to world
                this.mouseDown = true;
            }
            if (Input.GetMouseButtonUp(0)) {
                //GetComponent<Transform>().position = this.resetPosition;
                this.mouseDown = false;
            }
            this.end = Input.mousePosition;
            this.end = Camera.main.ScreenToWorldPoint(this.end); // Converts mouse positioning from screen to world

            // Arrow rotation
            if (this.mouseDown && this.start != this.end) {
                Quaternion rot = new Quaternion();
                if (this.start.x >= this.end.x) {
                    rot.eulerAngles = new Vector3(0, 0, Convert.ToSingle(Math.Atan((this.start.y - this.end.y) / (this.start.x - this.end.x)) * 180 / Math.PI) - 90);
                } else {
                    rot.eulerAngles = new Vector3(0, 0, Convert.ToSingle(Math.Atan((this.start.y - this.end.y) / (this.start.x - this.end.x)) * 180 / Math.PI) - 270);
                }
                this.arrowScale = Math.Sqrt(Math.Pow((this.start.y - this.end.y), 2) + Math.Pow((this.start.x - this.end.x), 2)) * this.arrowScaleMultiplier;
                if (this.arrowScale <= 2) {
                    GetComponent<Transform>().localScale = new Vector3(1, 2, 1);
                } else {
                    GetComponent<Transform>().localScale = new Vector3(1, (float)this.arrowScale, 1);
                }
                GetComponent<Transform>().rotation = rot;
            }
        }

        // Resets arrow indicator
        if (!PlayerInteraction.interaction.pressed && GetComponent<Transform>().position.x != this.resetPosition.x) {
            GetComponent<Transform>().position = this.resetPosition;
        }
    }
}
