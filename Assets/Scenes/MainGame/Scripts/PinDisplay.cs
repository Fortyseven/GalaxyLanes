using UnityEngine;
using System.Collections;

public class PinDisplay : MonoBehaviour
{
    public Sprite[] PinsUp, PinsDown;
    bool[] _pins = new bool[10];
    SpriteRenderer[] _pinSlots;

    // Use this for initialization
    void Start()
    {
        _pinSlots = GetComponentsInChildren<SpriteRenderer>();
        SetPins(new bool[10] {true,false,true,false,true,false,true,false,true, true});
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void SetPins( bool[] pins )
    {
        for( int i = 0; i < 10; i++ )
        {
            _pins[ i ] = pins[ i ];
            _pinSlots[ i ].sprite = _pins[ i ] ? PinsUp[ i ] : PinsDown[ i ];
        }
    }

    void ResetPins()
    {
        for(int i = 0; i < 10; i++) {
            _pins[i] = true;
            _pinSlots[ i ].sprite = PinsUp[ i ];
        }
    }

}
