using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D leftArm;
	public Rigidbody2D rightArm;
	public Rigidbody2D leftLeg;
	public Rigidbody2D rightLeg;
	
	public float power;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void DoMovement() {
		if (Input.GetKeyDown(KeyCode.A)) {
			leftArm.AddForce(Vector2.left * power, ForceMode2D.Force);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			leftArm.AddForce(Vector2.right * power, ForceMode2D.Force);
		}
		
	}
	
    // Update is called once per frame
    void Update()
    {
        DoMovement();
    }
}
