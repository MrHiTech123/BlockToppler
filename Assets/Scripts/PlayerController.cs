using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public HingeJoint2D leftArm;
	public HingeJoint2D rightArm;
	public HingeJoint2D leftLeg;
	public HingeJoint2D rightLeg;
	
	private JointMotor2D leftArmMotor;
	private JointMotor2D rightArmMotor;
	private JointMotor2D leftLegMotor;
	private JointMotor2D rightLegMotor;
	
	
	public float power = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        leftArmMotor = leftArm.motor;
		rightArmMotor = rightArm.motor;
		leftLegMotor = leftLeg.motor;
		rightLegMotor = rightLeg.motor;
    }
	void DoMovement() {
		Debug.Log("Doing movement");
		if (Input.GetKey(KeyCode.A)) {
			leftArmMotor.motorSpeed += power;
			Debug.Log("A key pressed, motorSpeed = " + leftArmMotor.motorSpeed);
			
		}
		if (Input.GetKey(KeyCode.S)) {
			leftArmMotor.motorSpeed -= power;
			Debug.Log("S key pressed, motorSpeed = " + leftArmMotor.motorSpeed);
		}
		
		
		
		
		leftArm.motor = leftArmMotor;
		rightArm.motor = rightArmMotor;
		leftLeg.motor = leftLegMotor;
		rightLeg.motor = rightLegMotor;
	}
	
    // Update is called once per frame
    void Update()
    {
		Debug.Log("Updating");
        DoMovement();
		
    }
}
