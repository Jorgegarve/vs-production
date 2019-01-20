using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothing = 5f;

    public float initialFOV = 45f;
    public float actionFOV = 30f;
    public float battleFOV = 30f;
    private float currentFOV = 0f;

    private bool rotationFlag = false;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start ()
    {
        initialFOV = GetComponent<Camera> ().fieldOfView;
    }

    // Update is called once per frame
    void Update ()
    {
        CheckCameraRotation ();
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
			transform.parent.DORotate (new Vector3 (transform.parent.eulerAngles.x, Mathf.RoundToInt (transform.parent.eulerAngles.y / 45) * 45 - 45f * Input.GetAxis("Camera Rotation"), transform.parent.eulerAngles.z), 0.2f, RotateMode.Fast).SetUpdate (true).OnComplete (() => 
			{ 
				rotationFlag = false; 
			});
		}
    }

    public void ChangeCameraTarget (Transform newTarget) 
    {
        target = newTarget;
    }

    public void FocusOnAction ()
    {
        currentFOV = Mathf.Lerp (currentFOV, actionFOV, smoothing * Time.unscaledDeltaTime);
        GetComponent<Camera> ().fieldOfView = currentFOV;
    }

    public void FocusOnBattle ()
    {  
        currentFOV = Mathf.Lerp (currentFOV, battleFOV, smoothing * Time.unscaledDeltaTime);
        GetComponent<Camera> ().fieldOfView = currentFOV;
    }

    public void UnFocusOnAction ()
    {
        currentFOV = Mathf.Lerp (currentFOV, initialFOV, smoothing * Time.unscaledDeltaTime);
        GetComponent<Camera> ().fieldOfView = currentFOV;
    }
}