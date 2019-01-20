using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatSystemManager : MonoBehaviour
{
    public GameObject rangeSpherePrefab;
    public bool isRangeSphereEnabled = false;
    private GameObject rangeSphere;

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

    public void TriggerRangeSphere ()
    {
        if (!isRangeSphereEnabled)
        {
            CreateRangeSphere ();
        } else
        {
            DestroyRangeSphere ();
        }
        
    }

    public void CreateRangeSphere ()
    {
        isRangeSphereEnabled = true;
        rangeSphere = Instantiate (rangeSpherePrefab, GameManager.Instance.player.position, Quaternion.identity);
        rangeSphere.transform.DOScale (new Vector3(5, 5, 5), 0.5f).SetUpdate (true).OnComplete ( () => {

        });
    }

    public void DestroyRangeSphere ()
    {
        isRangeSphereEnabled = false;
        Destroy (rangeSphere);
    }
}
