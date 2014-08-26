using UnityEngine;
using System.Collections;

class State_GetAngle : GameState
{
    const float Granularity = 1.0f;
    float _value;
    
    public State_GetAngle(GameController parent): base(parent)
    {;}
    
    public override void Start()
    {
        _value = 0;
    }
    
    public override void Update()
    {
//        if ( Input.GetKeyDown( KeyCode.LeftArrow ) || Input.GetKeyDown( KeyCode.UpArrow ) )
//        {
//            _value -= Granularity;
//        } else if ( Input.GetKeyDown( KeyCode.RightArrow ) || Input.GetKeyDown( KeyCode.DownArrow ) )
//        {
//            _value += Granularity;
//        }  else if (Input.anyKeyDown){
//            _parent.Angle = _value;
//            _parent.SetState(_parent._state_getpower);
//        }
    }
    
    public override void OnGUI()
    {
//        GUI.Box( new Rect( 100, 100, 200, 100 ), "Angle: " + _value );
    }
    
    public override void OnChangeTo()
    {
        UIManager.instance.SwitchToDirectional();
    }
}