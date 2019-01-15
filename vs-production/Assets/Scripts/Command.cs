using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public abstract class Command
{
	public abstract void Execute (Transform objectTransform);

	public virtual void Pause () { }

	public virtual void Move (Transform objectTransform) { }

	public virtual void Rotate (Transform objectTransform) { }
}

public class PauseGame : Command {

	public override void Execute(Transform objectTransform) 
	{
		Pause ();
	}

	public override void Pause() 
	{
		GameManager.Instance.Pause ();
	}
}

public class MoveForward : Command
{
	public override void Execute (Transform objectTransform)
	{
		Move (objectTransform);
		InputHandler.Instance.onMoving ();
	}

	public override void Move (Transform objectTransform) 
	{
		InputHandler.Instance.forward = Camera.main.transform.forward;
		InputHandler.Instance.forward.y = 0;
		InputHandler.Instance.forward = Vector3.Normalize (InputHandler.Instance.forward);

		Vector3 upMovement = InputHandler.Instance.forward * InputHandler.Instance.movementSpeed * Time.unscaledDeltaTime;
		
		Vector3 heading = Vector3.Normalize (upMovement);

		objectTransform.forward += heading;
		objectTransform.position += upMovement;
	}
}

public class MoveBackward : Command
{
	public override void Execute (Transform objectTransform)
	{
		Move (objectTransform);
		InputHandler.Instance.onMoving ();
	}

	public override void Move (Transform objectTransform) 
	{
		InputHandler.Instance.forward = Camera.main.transform.forward;
		InputHandler.Instance.forward.y = 0;
		InputHandler.Instance.forward = Vector3.Normalize (InputHandler.Instance.forward);

		Vector3 upMovement = - InputHandler.Instance.forward * InputHandler.Instance.movementSpeed * Time.unscaledDeltaTime;
		
		Vector3 heading = Vector3.Normalize (upMovement);

		objectTransform.forward += heading;
		objectTransform.position += upMovement;
	}
}

public class MoveLeft : Command
{
	public override void Execute (Transform objectTransform)
	{
		Move (objectTransform);
		InputHandler.Instance.onMoving ();
	}

	public override void Move (Transform objectTransform) 
	{
		InputHandler.Instance.forward = Camera.main.transform.forward;
		InputHandler.Instance.forward.y = 0;
		InputHandler.Instance.forward = Vector3.Normalize (InputHandler.Instance.forward);
		InputHandler.Instance.right = Quaternion.Euler (new Vector3(0, 90, 0)) * InputHandler.Instance.forward;

		Vector3 rightMovement = - InputHandler.Instance.right * InputHandler.Instance.movementSpeed * Time.unscaledDeltaTime;
		
		Vector3 heading = Vector3.Normalize (rightMovement);

		objectTransform.forward += heading;
		objectTransform.position += rightMovement;
	}
}

public class MoveRight : Command
{
	public override void Execute (Transform objectTransform)
	{
		Move (objectTransform);
		InputHandler.Instance.onMoving ();
	}

	public override void Move (Transform objectTransform) 
	{
		InputHandler.Instance.forward = Camera.main.transform.forward;
		InputHandler.Instance.forward.y = 0;
		InputHandler.Instance.forward = Vector3.Normalize (InputHandler.Instance.forward);
		InputHandler.Instance.right = Quaternion.Euler (new Vector3(0, 90, 0)) * InputHandler.Instance.forward;

		Vector3 rightMovement = InputHandler.Instance.right * InputHandler.Instance.movementSpeed * Time.unscaledDeltaTime;
		
		Vector3 heading = Vector3.Normalize (rightMovement);

		objectTransform.forward += heading;
		objectTransform.position += rightMovement;
	}
}

public class RotateLeft : Command
{
	private bool rotationFlag = false;

	public override void Execute (Transform objectTransform)
	{
		Rotate (objectTransform);
	}

	public override void Rotate (Transform objectTransform) 
	{
		if (!rotationFlag) {

			rotationFlag = true;
			objectTransform.parent.DORotate (new Vector3 (objectTransform.parent.eulerAngles.x, Mathf.RoundToInt (objectTransform.parent.eulerAngles.y / 45) * 45 - 45f * - 1, objectTransform.parent.eulerAngles.z), 0.2f, RotateMode.Fast).SetUpdate (true).OnComplete (() => 
			{ 
				rotationFlag = false; 
			});
		}
	}
}

public class RotateRight : Command
{
	private bool rotationFlag = false;

	public override void Execute (Transform objectTransform)
	{
		Rotate (objectTransform);
	}

	public override void Rotate (Transform objectTransform) 
	{
		if (!rotationFlag) {

			rotationFlag = true;
			objectTransform.parent.DORotate (new Vector3 (objectTransform.parent.eulerAngles.x, Mathf.RoundToInt (objectTransform.parent.eulerAngles.y / 45) * 45 - 45f * 1, objectTransform.parent.eulerAngles.z), 0.2f, RotateMode.Fast).SetUpdate (true).OnComplete (() => 
			{ 
				rotationFlag = false; 
			});
		}
	}
}

public class SelectAttackTarget : Command
{
	public override void Execute (Transform objectTransform)
	{
		Debug.Log ("Doing SelectAttackTarget");
	}
}

public class Cancel : Command
{
	public override void Execute(Transform objectTransform)
	{
		Debug.Log ("Doing Cancel");
	}
}

public class DoNothing : Command
{
	public override void Execute(Transform objectTransform)
	{
		Debug.Log ("Doing DoNothing");
	}
}