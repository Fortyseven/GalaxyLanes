using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject BowlingBall;
    BowlingBall _bowling_ball;

    int _cur_frame, _cur_throw;

    public enum GameState {
        GET_ANGLE,
        GET_POWER,
        ROLLING,
        SCORE
    };

    GameState _state;

    /******************************************************/
    void Start()
    {
        _bowling_ball = BowlingBall.GetComponent<BowlingBall>();
        _bowling_ball.Reset();
    }

    /******************************************************/
    void Update()
    {
        switch(_state) {
            case GameState.GET_ANGLE:
                if ( Input.anyKeyDown ) {
//                    _bowling_ball.Launch( Random.Range( -10f, 10f ), 100.0f );
                    _bowling_ball.Launch( 25.0f, 400.0f );
                    SetState(GameState.ROLLING);
                }
                break;
            case GameState.ROLLING:
                if ( Input.anyKeyDown ) {
                    _bowling_ball.Reset();
                    Reset();
                }
                break;
        }
    }

    /******************************************************/
    void Reset()
    {
        _cur_frame = 0;
        _cur_throw = 0;

        SetState(GameState.GET_ANGLE);
    }

    /******************************************************/
    void OnGUI()
    {

        GUI.TextArea(new Rect(0,0, 100, 100), 
                     "FRAME: " + _cur_frame + "\n" +
                     "THROW: " + _cur_throw + "\n"
                     );
    }


    /******************************************************/
    public void SetState(GameState state) 
    {
        OnStateChange(state);
        _state = state;
    }

    /******************************************************/
    private void OnStateChange(GameState new_state)
    {
        Debug.Log("State = " + new_state);
        switch(new_state) 
        {
            case GameState.GET_ANGLE:
                break;
            case GameState.GET_POWER:
                break;
            case GameState.ROLLING:
                break;
            case GameState.SCORE:
                break;
        }
    }

}
