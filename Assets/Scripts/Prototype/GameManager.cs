using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global game manager. Keeps track of game objects. (Singleton)
/// </summary>
public class GameManager
{
    static private GameManager instance = null;

    public bool gameStarted = false; // Has the game started yet?

    public EventSystem eventSystem = null; // Keep global reference to the current active event system, null if not active.

    public void OnStart()
    {
        Random.InitState((int)Time.timeSinceLevelLoad);
    }

    public void SetEventSystem(EventSystem eventSystem)
    {
        this.eventSystem = eventSystem;
    }

    static public GameManager Instance()
    {
        if (instance == null)
            instance = new GameManager();

        return instance;
    }
}
