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
	
	
	private float power = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        leftArmMotor = leftArm.motor;
		rightArmMotor = rightArm.motor;
		leftLegMotor = leftLeg.motor;
		rightLegMotor = rightLeg.motor;
    }
	
	/**
		Modifies num.
		@param num: the number whose absolute value is to be changed (meaning that delta is added to it if num > 0, 
			and otherwise delta is subtracted.)
		@param delta: the magnitude of the change. If negative, the absoluate value is moved to be that much closer to 0.
	*/
	float ChangeAbsValue(float angle, float speed, float delta) {
		if (angle >= 0) {
			speed += delta;
		}
		else {
			speed += -delta;
		}
		return speed;
	}
	
	float MoveFromZero(float angle, float num, float delta) {
		return ChangeAbsValue(angle, num, delta);
	}
	float MoveToZero(float angle, float num, float delta) {
		return ChangeAbsValue(angle, num, -delta);
	}
	
	void DoMovement() {
		Debug.Log("Doing movement");
		if (Input.GetKey(KeyCode.A)) {
			leftArmMotor.motorSpeed = MoveToZero(leftArm.jointAngle, leftArmMotor.motorSpeed, power);
		}
		else if (Input.GetKey(KeyCode.S)) {
			leftArmMotor.motorSpeed = MoveFromZero(leftArm.jointAngle, leftArmMotor.motorSpeed, power);
		}
		else {
			leftArmMotor.motorSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.D)) {
			leftLegMotor.motorSpeed = power;
		}
		else if (Input.GetKey(KeyCode.F)) {
			leftLegMotor.motorSpeed = -power;
		}
		else {
			leftLegMotor.motorSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.J)) {
			rightLegMotor.motorSpeed = power;
		}
		else if (Input.GetKey(KeyCode.K)) {
			rightLegMotor.motorSpeed = -power;
		}
		else {
			rightLegMotor.motorSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.L)) {
			rightArmMotor.motorSpeed = MoveFromZero(rightArm.jointAngle, rightArmMotor.motorSpeed, power);
		}
		else if (Input.GetKey(KeyCode.Semicolon)) {
			rightArmMotor.motorSpeed = MoveToZero(rightArm.jointAngle, rightArmMotor.motorSpeed, power);
		}
		else {
			rightArmMotor.motorSpeed = 0;
		}
		
		
		Debug.Log("Left angle " + leftArm.jointAngle);
		Debug.Log("Right angle " + rightArm.jointAngle);
		
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
