using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CombatSystemManager : MonoBehaviour
{
    public List<GameObject> reachableEnemies;

    public GameObject rangeSpherePrefab;
    public float rangeSphereRadius = 5f;
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
        rangeSphere.transform.DOScale (new Vector3(rangeSphereRadius, rangeSphereRadius, rangeSphereRadius), 0.5f).SetUpdate (true).OnComplete ( () => {
            
        });
        DetectEnemiesInsideSphere ();
    }

    private void DetectEnemiesInsideSphere ()
    {
        int layerMask = 1 << 10;
        Collider[] hitColliders = Physics.OverlapSphere (this.transform.position, rangeSphereRadius, layerMask);

        int i = 0;
        foreach (Collider hit in hitColliders) 
        {
            reachableEnemies.Add (hit.gameObject);
            i++;
        }

        Debug.Log (i + " enemies detected!");
    }

    private void ClearReachableEnemiesList ()
    {
        reachableEnemies.Clear ();
    }

    public void DestroyRangeSphere ()
    {
        ClearReachableEnemiesList ();
        isRangeSphereEnabled = false;
        Destroy (rangeSphere);
    }
}
