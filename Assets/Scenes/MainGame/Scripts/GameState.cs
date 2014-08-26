using UnityEngine;
using System.Collections;

public abstract class GameState
{
    public GameController _parent;

    public GameState( GameController parent )
    {
        _parent = parent;
    }

    public abstract void Start();

    public abstract void Update();

    public abstract void OnGUI();

    public abstract void OnChangeTo();
}