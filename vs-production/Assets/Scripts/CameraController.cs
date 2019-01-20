﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Camera camera;

    public float smoothing = 5f;

    public bool rotationFlag = false;

    public bool isFocusing = false;

    public float initialFOV = 45f;
    public float actionFOV = 30f;
    public float battleFOV = 30f;
    private float currentFOV = 0f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start ()
    {
        camera = GetComponent<Camera> ();
        initialFOV = camera.fieldOfView;
        currentFOV = initialFOV;
    }

    // Update is called once per frame
    void Update ()
    {
        CheckCameraRotation ();

        if (isFocusing)
        {
            FocusOnAction ();
        } else
        {
            UnFocusOnAction ();
        }
    }

    void LateUpdate () 
    {
        Vector3 targetCameraPosition = target.position;
        transform.parent.position = Vector3.Lerp (transform.parent.position, targetCameraPosition, smoothing * Time.unscaledDeltaTime);
    }

    public void CheckCameraRotation ()
    {
        if (!rotationFlag) {

			rotationFlag = true;
			transform.parent.DORotate (new Vector3 (transform.parent.eulerAngles.x, Mathf.RoundToInt (transform.parent.eulerAngles.y / 45) * 45 - 45f * Input.GetAxisRaw ("Camera Rotation"), transform.parent.eulerAngles.z), 0.2f, RotateMode.Fast).SetUpdate (true).OnComplete (() => 
			{ 
				rotationFlag = false; 
			});
        } 
    }

    public void ChangeCameraTarget (Transform newTarget) 
    {
        target = newTarget;
    }

    public void TriggerCameraFocus ()
    {
        isFocusing = !isFocusing;
    }

    public void FocusOnAction ()
    {
        currentFOV = Mathf.Lerp (currentFOV, actionFOV, smoothing * Time.unscaledDeltaTime);
        camera.fieldOfView = currentFOV;
    }

    public void FocusOnBattle ()
    {  
        currentFOV = Mathf.Lerp (currentFOV, battleFOV, smoothing * Time.unscaledDeltaTime);
        camera.fieldOfView = currentFOV;
    }

    public void UnFocusOnAction ()
    {
        currentFOV = Mathf.Lerp (currentFOV, initialFOV, smoothing * Time.unscaledDeltaTime);
        camera.fieldOfView = currentFOV;
    }
}