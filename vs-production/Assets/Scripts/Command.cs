using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{	
	
	public abstract class Command
	{
		public abstract void Execute (Transform objectTransform);
	}

	public class MoveForward : Command
	{
		public override void Execute (Transform objectTransform)
		{
			Debug.Log ("Doing MoveForwards");
		}
	}

	public class MoveBackward : Command
	{
		public override void Execute (Transform objectTransform)
		{
			Debug.Log ("Doing MoveBackwards");
		}
	}

	public class MoveLeft : Command
	{
		public override void Execute (Transform objectTransform)
		{
			Debug.Log ("Doing MoveLeft");
		}
	}

	public class MoveRight : Command
	{
		public override void Execute (Transform objectTransform)
		{
			Debug.Log ("Doing MoveRight");
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

}