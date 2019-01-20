using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health {
	public int maxHealth;
	public int healthRegeneration;
	public float healthRegTime;

    public Health ()
    {

    }
}

[CreateAssetMenu(fileName = "New Stats", menuName = "Stats", order = 51)]
public class Stats : ScriptableObject
{
    [Header("Health")]
    public Health health = new Health ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
