using UnityEngine;
using System.Collections;

public class PinBin : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "BowlingBall") {
            GameController.instance.Reset();
        }
    }
}
