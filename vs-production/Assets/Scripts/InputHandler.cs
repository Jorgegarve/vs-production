using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        public Transform player;
        private Command buttonW, buttonS, buttonA, buttonD, buttonRMB, buttonESC;

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
            if (Input.GetKeyDown (KeyCode.A))
            {
                buttonA.Execute (player);
            }
            else if (Input.GetKeyDown (KeyCode.D))
            {
                buttonD.Execute (player);
            }
            else if (Input.GetKeyDown (KeyCode.S))
            {
                buttonS.Execute (player);
            }
            else if (Input.GetKeyDown (KeyCode.W))
            {
                buttonW.Execute (player);
            }
            else if (Input.GetMouseButtonDown (1))
            {
                buttonRMB.Execute (player);
            }
            else if (Input.GetKeyDown (KeyCode.Escape))
            {
                buttonESC.Execute (player);
            }
        }
    }
}