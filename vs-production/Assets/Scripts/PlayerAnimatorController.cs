using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator an;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator> ();
        InputHandler.Instance.onIdle += OnIdle;
        InputHandler.Instance.onMoving += OnMoving;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnIdle ()
    {
        an.SetBool ("isMoving", false);
    }

    private void OnMoving ()
    {
        an.SetBool ("isMoving", true);
    }
}
