using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject Directional, Power;
    public GameObject DirectionalCursor, PowerCursor;
    public static UIManager instance = null;
    GameObject _cursor;
    public bool Ready = false;

    void Awake()
    {
        UIManager.instance = this;
    }

    public void Start()
    {
        Directional.SetActive( false );
        Power.SetActive( false );

        _cursor = null;

        Ready = true;
    }

    public void SwitchToDirectional()
    {
        StartCoroutine( "DirectionalUpdate" );
    }

    public IEnumerator DirectionalUpdate()
    {
        float cursor_pos = 0;
        int cursor_dir = 1;
        float cursor_max = 2.5f;
        float cursor_speed = 7f;
        Vector3 cursor_origin =  DirectionalCursor.transform.localPosition;
        Vector3 newpos = new Vector3();
        newpos.x = cursor_origin.x;
        newpos.y = cursor_origin.y;
        newpos.z = cursor_origin.z;
        
        Directional.SetActive( true );
        
        while( !Input.anyKeyDown )
        {
            cursor_pos += (cursor_dir * (cursor_speed * Time.deltaTime));
            if (cursor_pos >= cursor_max) {
                cursor_dir = -1;
            } 
            if (cursor_pos <= -cursor_max) {
                cursor_dir = 1;
            }
            newpos.x = cursor_origin.x + cursor_pos;
            DirectionalCursor.transform.localPosition = newpos;
            yield return 0;
        }
        GameController.instance.Angle = (cursor_pos / 2.5f) * 10.0f;
        DirectionalCursor.transform.localPosition = cursor_origin;
        Directional.SetActive(false);
        GameController.instance.SetState(GameController.instance._state_getpower);
        yield return 0;
    }

    public void SwitchToPower()
    {
        StartCoroutine( "PowerUpdate" );
    }
    
    public IEnumerator PowerUpdate()
    {
        float cursor_pos = 0;
        int cursor_dir = 1;
        float cursor_max = 2.5f;
        float cursor_speed = 7f;
        Vector3 cursor_origin =  PowerCursor.transform.localPosition;
        Vector3 newpos = new Vector3();
        newpos.x = cursor_origin.x;
        newpos.y = cursor_origin.y;
        newpos.z = cursor_origin.z;

        Power.SetActive( true );
        while(Input.anyKeyDown){yield return 0;}
        while( !Input.anyKeyDown )
        {
            cursor_pos += (cursor_dir * (cursor_speed * Time.deltaTime));
            if (cursor_pos >= cursor_max) {
                cursor_dir = -1;
            } 
            if (cursor_pos <= -cursor_max) {
                cursor_dir = 1;
            }
            newpos.x = cursor_origin.x + cursor_pos;
            PowerCursor.transform.localPosition = newpos;
            yield return 0;
        }

        cursor_pos += 2.5f;
        GameController.instance.Power = 100.0f + ((cursor_pos / 5.0f) * 300.0f);
        PowerCursor.transform.localPosition = cursor_origin;
        Power.SetActive(false);
        GameController.instance.SetState(GameController.instance._state_rolling);
        yield return 0;
    }

    void Update()
    {
    }
}
