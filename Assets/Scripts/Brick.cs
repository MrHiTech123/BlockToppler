using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	
	private const float minimumMovedDist = 0.001f;
	private Vector3 startPos;
    // Start is called before the first frame update
	
	private static Vector3 CopyVector3(Vector3 toCopy) {
		return new Vector3(toCopy.x, toCopy.y, toCopy.z);
	}
    void Start()
    {
        startPos = CopyVector3(transform.position);
    }
	
	bool HasBeenMoved() {
		return Vector3.Distance(transform.position, startPos) > minimumMovedDist;
	}
    // Update is called once per frame
    void Update()
    {
        if (HasBeenMoved()) {
			Debug.Log("Moved!");
		}
		else {
			Debug.Log("Not moved");
		}
		
		Debug.Log("Old " + startPos);
		Debug.Log("New " + transform.position);
    }
}
