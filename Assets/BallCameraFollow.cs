using UnityEngine;
using System.Collections;

public class BallCameraFollow : MonoBehaviour
{
    public GameObject BowlingBallTarget;

    public Vector3 Offset;

    void Start()
    {
        // Get initial position settings
//        _offs = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = BowlingBallTarget.transform.position;

        //newpos.y += Offset.y; //7.75f;
        newpos.x = 0;
        newpos.y = Offset.y;
        newpos.z = Mathf.Clamp(newpos.z + Offset.z, -100, 92.0f); //-26.35f;

        transform.position = newpos;
    }
}
