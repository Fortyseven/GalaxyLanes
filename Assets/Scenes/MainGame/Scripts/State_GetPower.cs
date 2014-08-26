using UnityEngine;
using System.Collections;

class State_GetPower : GameState
{
    const float Granularity = 10.0f;
    float _value;
    
    public State_GetPower(GameController parent): base(parent)
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
//        } else if (Input.anyKeyDown){
//            _parent.Power = _value;
//            _parent.SetState(_parent._state_rolling);
//        }
    }
    
    public override void OnGUI()
    {
        //GUI.Box( new Rect( 100, 100, 200, 100 ), "Power: " + _value );
    }
    
    public override void OnChangeTo()
    {
        UIManager.instance.SwitchToPower();
    }
}