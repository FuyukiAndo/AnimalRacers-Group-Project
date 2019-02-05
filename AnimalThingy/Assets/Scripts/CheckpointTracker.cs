using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
	public List<int> CheckpointsPassed
	{
		get
		{
			return checkPointsPassed;
		}
	}
	private List<int> checkPointsPassed;
	private int lastCheckpointPassed = 0;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Checkpoint>())
		{
			Checkpoint checkPoint = other.GetComponent<Checkpoint>();
			if (CheckpointManager.Instance.passInSequence)
			{
				if (checkPoint.Index == lastCheckpointPassed + 1)
				{
					checkPointsPassed.Add(checkPoint.Index);
					lastCheckpointPassed = checkPoint.Index;
					return;
				}
			}
			else
			{
				foreach (var index in checkPointsPassed)
				{
					if (index == checkPoint.Index)
					{
						return;
					}
				}
				checkPointsPassed.Add(checkPoint.Index);
			}
		}
	}

	public Vector2 GetCurrentPosition()
	{
		return transform.position;
	}

	public int GetCurrentCheckpointIndex()
	{
		return checkPointsPassed[checkPointsPassed.Count - 1];
	}
}