using UnityEngine;
using System.Collections;

    class State_Rolling : GameState
    {        
        public State_Rolling(GameController parent): base(parent)
        {;}
        
        public override void Start()
        {

        }
        
        public override void Update()
        {
        
        }
        
        public override void OnGUI()
        {
//            GUI.Box( new Rect( 100, 100, 200, 100 ), "Power: " + _value );
        }
        
        public override void OnChangeTo()
        {
            _parent.Ball.Launch(_parent.Angle, _parent.Power);
        }
    }