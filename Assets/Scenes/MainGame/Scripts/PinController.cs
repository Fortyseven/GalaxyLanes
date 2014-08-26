using UnityEngine;
using System.Collections;

public class PinController : MonoBehaviour
{
    public GameObject BowlingPin;
    public GameObject[] Slots;
    GameObject[] pins;

    public static PinController instance;

    void Awake()
    {
        PinController.instance = this;
    }

    void Start()
    {
        pins = new GameObject[10];

        for( int i = 0; i < pins.Length; i++ )  {
            pins[ i ] = GameObject.Instantiate( BowlingPin, Slots[ i ].transform.position, Slots[ i ].transform.rotation ) as GameObject;
        }

        Reset();
    }

    bool[] GetPinStatus()
    {
        bool[] status = new bool[10];
        for(int i = 0; i < pins.Length; i++) {
            status[i] = IsPinStanding(i);
        }
        return status;
    }

    bool IsPinStanding(int i)
    {
        GameObject pin = pins[i];

        return true;    
    }

    void Update()
    {
    
    }

    void Reset()
    {
        for( int i = 0; i < pins.Length; i++ )  {
            pins[ i ].transform.position = Slots[ i ].transform.position;
            pins[ i ].transform.rotation = Slots[ i ].transform.rotation;
        }
    }

}
