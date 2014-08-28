using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour
{
    Vector3 _start_position;
    Quaternion _start_rotation;

    void Start()
    {
        _start_position = transform.position;
        _start_rotation = transform.rotation;
        Reset();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        transform.position = _start_position;
        transform.rotation = _start_rotation;

        rigidbody.Sleep();
    }

    public void Launch(float angle, float power)
    {
        //angle = 0; 
        //power = 350.0f;

        power = power * 0.5f;
        Debug.Log("Launched at angle " + angle + ", power " + power);
        Vector3 force = Vector3.forward * power;//250.0f;
        force.x += angle*2;
        rigidbody.AddForce( force );
        rigidbody.AddTorque( Vector3.right * 100.0f );
    }
}
