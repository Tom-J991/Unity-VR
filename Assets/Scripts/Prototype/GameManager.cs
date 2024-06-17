using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private GameManager instance = null;

    public EventSystem eventSystem = null;

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
