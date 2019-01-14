using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        private Command buttonW, buttonS, buttonA, buttonD, buttonRMB, buttonESC;

        public Transform player;

        public Vector3 forward, right;
		public float movementSpeed = 4f;

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

        public class EventData
        {
            public KeyCode keyCode = KeyCode.None;
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
            buttonW = new MoveForward();
            buttonS = new MoveBackward();
            buttonA = new MoveLeft();
            buttonD = new MoveRight();
            buttonRMB = new SelectAttackTarget();
            buttonESC = new Cancel();
        }

        void Update()
        {
            HandleInput();
        }

        public void HandleInput ()
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
}