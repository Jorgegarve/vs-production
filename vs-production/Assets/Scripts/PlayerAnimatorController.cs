using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator an;
    private PlayerMovementController playerMovementController;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator> ();
        playerMovementController = GetComponent<PlayerMovementController> ();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovementState ();
    }

    private void CheckMovementState ()
    {
        if (playerMovementController.IsWalking ())
        {
            OnWalking ();
        } else if (playerMovementController.IsRunning ())
        {
            OnRunning ();
        } else
        {
            OnIdle ();
        }
    }

    private void OnIdle ()
    {
        an.SetBool ("isWalking", false);
        an.SetBool ("isRunning", false);
    }

    private void OnWalking ()
    {
        an.SetBool ("isWalking", true);
        an.SetBool ("isRunning", false);
    }

    private void OnRunning ()
    {
        an.SetBool ("isWalking", false);
        an.SetBool ("isRunning", true);
    }
}
