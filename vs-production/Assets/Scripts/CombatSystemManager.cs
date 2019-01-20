using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystemManager : MonoBehaviour
{
    protected CombatSystemManager () {}
	private static CombatSystemManager instance = null;

    public static CombatSystemManager Instance {
        get {
            if (CombatSystemManager.instance == null){
                DontDestroyOnLoad (CombatSystemManager.instance);
                CombatSystemManager.instance = new CombatSystemManager ();
            }
            return CombatSystemManager.instance;
        }
    }

	private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
