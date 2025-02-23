using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	
	public ScoreboardController scoreboard;
	public GameObject tablePlatform;
	private const float minimumMovedDist = 0.1f;
	private Vector3 startPos;
	private bool wasMoved = false;
    // Start is called before the first frame update
	
	private static Vector3 CopyVector3(Vector3 toCopy) {
		return new Vector3(toCopy.x, toCopy.y, toCopy.z);
	}
    void Start()
    {
        startPos = CopyVector3(transform.position);
    }
	
	float GetBottomYCoordinate() {
		return transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2);
	}
	bool HasBeenMoved() {
		return (Math.Abs(transform.rotation.z % 180) >= 0.01) || (GetBottomYCoordinate() < tablePlatform.transform.position.y);
		// return Vector3.Distance(transform.position, startPos) > minimumMovedDist;
	}
	
	void AcknowledgeMovement() {
		Debug.Log("Moving");
		wasMoved = true;
		++scoreboard.score;
	}
	
	void UnAcknowledgeMovement() {
		Debug.Log("Up Top");
		wasMoved = false;
		--scoreboard.score;
	}
	
    // Update is called once per frame
    void Update()
    {
        if (!wasMoved && HasBeenMoved()) {
			AcknowledgeMovement();
		}
		if (wasMoved && !HasBeenMoved()) {
			UnAcknowledgeMovement();
		}
		
    }
}
