using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public abstract class Command
{
	public abstract void Execute (Transform objectTransform);
}

public class PauseGame : Command {

	public override void Execute(Transform objectTransform) 
	{
		GameManager.Instance.Pause ();
	}
}

public class SelectAttackTarget : Command
{
	public override void Execute (Transform objectTransform)
	{
		GameManager.Instance.Pause ();
		GameManager.Instance.cameraController.TriggerCameraFocus ();
		CombatSystemManager.Instance.TriggerRangeSphere ();
		objectTransform.GetComponent<PlayerAnimatorController> ().OnIdle ();
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