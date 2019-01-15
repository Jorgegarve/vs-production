using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


public class InputHandler : MonoBehaviour
{
    private Command buttonW, buttonS, buttonA, buttonD, buttonQ, buttonE, buttonRMB, buttonESC;

    public Transform player;

    public Vector3 forward, right;
    public float movementSpeed = 4f;

    public delegate void OnMoving ();
    public OnMoving onMoving;

    public delegate void OnIdle ();
    public OnIdle onIdle;

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
        buttonW = new MoveForward ();
        buttonS = new MoveBackward ();
        buttonA = new MoveLeft ();
        buttonD = new MoveRight ();
        buttonQ = new RotateLeft ();
        buttonE = new RotateRight ();
        buttonRMB = new SelectAttackTarget ();
        buttonESC = new Cancel ();
    }

    void Update ()
    {
        HandleInput ();
    }

    public void HandleInput ()
    {
        // WARNING: The following if sentence doesn't take into account the movement keys rebind
        if ((!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D)) ||
            (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)) || (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)))
        {
            onIdle ();
        } else
        {
            if (Input.GetKey (KeyCode.A))
            {
                buttonA.Execute (player);
            }
            if (Input.GetKey (KeyCode.D))
            {
                buttonD.Execute (player);
            }
            if (Input.GetKey (KeyCode.S))
            {
                buttonS.Execute (player);
            }
            if (Input.GetKey (KeyCode.W))
            {
                buttonW.Execute (player);
            }
        }
        if (Input.GetKeyDown (KeyCode.E))
        {
            buttonQ.Execute (Camera.main.transform);
        }
        if (Input.GetKeyDown (KeyCode.Q))
        {
            buttonE.Execute (Camera.main.transform);
        }
        
        if (Input.GetMouseButtonDown (1))
        {
            buttonRMB.Execute (player);
        }
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            buttonESC.Execute (player);
        }
    }
}