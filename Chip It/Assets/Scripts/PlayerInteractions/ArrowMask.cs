using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMask : MonoBehaviour
{
    private readonly ArrowIndicator indicator;

    private double maskScale;
    private int maskScaleMultiplier = 14;

    // Update is called once per frame
    void Update() {
        GetComponent<Transform>().position = ArrowIndicator.indicator.end;

        if (ArrowIndicator.indicator.mouseDown && ArrowIndicator.indicator.start != ArrowIndicator.indicator.end) {
            Quaternion rot = new Quaternion();
            if (ArrowIndicator.indicator.start.x >= ArrowIndicator.indicator.end.x) {
                rot.eulerAngles = new Vector3(0, 0, Convert.ToSingle(Math.Atan((ArrowIndicator.indicator.start.y - ArrowIndicator.indicator.end.y) / (ArrowIndicator.indicator.start.x - ArrowIndicator.indicator.end.x)) * 180 / Math.PI) - 90);
            }
            else {
                rot.eulerAngles = new Vector3(0, 0, Convert.ToSingle(Math.Atan((ArrowIndicator.indicator.start.y - ArrowIndicator.indicator.end.y) / (ArrowIndicator.indicator.start.x - ArrowIndicator.indicator.end.x)) * 180 / Math.PI) - 270);
            }
            this.maskScale = Math.Sqrt(Math.Pow((ArrowIndicator.indicator.start.y - ArrowIndicator.indicator.end.y), 2) + Math.Pow((ArrowIndicator.indicator.start.x - ArrowIndicator.indicator.end.x), 2)) * this.maskScaleMultiplier;
            if (this.maskScale <= 3.5) {
                GetComponent<Transform>().localScale = new Vector3(5, 3.5f, 1);
            } else {
                GetComponent<Transform>().localScale = new Vector3(5, (float) this.maskScale, 1);
            }
            GetComponent<Transform>().rotation = rot;
        }
    }
}
