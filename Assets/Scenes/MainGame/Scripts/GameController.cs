using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public GameObject BowlingBall;
    BowlingBall _bowling_ball;

    public BowlingBall Ball {
        get { return _bowling_ball; }
    }

    int _cur_frame, _cur_throw;

    float _selected_angle = 0;
    float _selected_power = 0;

    public float Angle {
        get {return _selected_angle;}
        set {_selected_angle = value;}
    }
    public float Power {
        get {return _selected_power;}
        set {_selected_power = value;}
    }

    public 
    GameState _state_getangle, 
              _state_getpower,
              _state_rolling;

    GameState _current_state;

    bool _ready;

    void Awake()
    {
        GameController.instance = this;
    }

    /******************************************************/
    void Start()
    {
        _ready = false;
        _bowling_ball = BowlingBall.GetComponent<BowlingBall>();
        _bowling_ball.Reset();

        _state_getangle = new State_GetAngle(this);
        _state_getpower = new State_GetPower(this);
        _state_rolling = new State_Rolling(this);

        _current_state = null;

        StartCoroutine("StartupWait");
    }

    /******************************************************/
    IEnumerator StartupWait()
    {
        while(!UIManager.instance.Ready) {yield return 0;}
        SetState( _state_getangle );
        _ready = true;
        yield return 0;
    }

    /******************************************************/
    void Update()
    {
        if (!_ready) return;

        if (_current_state != null)
            _current_state.Update();
    }

    /******************************************************/
    public void Reset()
    {
        _cur_frame = 0;
        _cur_throw = 0;
        Ball.Reset();
        SetState( _state_getangle );
    }

    /******************************************************/
    void OnGUI()
    {
        if (!_ready) return;

        GUI.TextArea( new Rect( 0, 0, 100, 100 ), 
            "FRAME: " + _cur_frame + "\n" +
            "THROW: " + _cur_throw + "\n"
        );
        _current_state.OnGUI();
    }


    /******************************************************/
    public void SetState( GameState state )
    {
        _current_state = state;
        _current_state.OnChangeTo();
    }
}
