using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class InputHandler : MonoBehaviour
{
    private Command buttonCircle;

    [SerializeField]
    private Transform player;

    protected InputHandler () {}
    private static InputHandler instance = null;

    public static InputHandler Instance {
        get {
            if (InputHandler.instance == null){
                DontDestroyOnLoad (InputHandler.instance);
                InputHandler.instance = new InputHandler ();
            }
            return InputHandler.instance;
        }
    }

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start ()
    {
        /* buttonW = new MoveForward ();
        buttonS = new MoveBackward ();
        buttonA = new MoveLeft ();
        buttonD = new MoveRight ();
        buttonQ = new RotateLeft ();
        buttonE = new RotateRight ();
        buttonSpace = new PauseGame ();
        buttonRMB = new SelectAttackTarget ();
        buttonESC = new Cancel (); */
        buttonCircle = new SelectAttackTarget ();
    }

    void Update ()
    {
        HandleInput ();
    }

    public void HandleInput ()
    {
        if (Input.GetButtonDown ("Select Attack Target"))
        {
            buttonCircle.Execute (player);
        }
    }
}