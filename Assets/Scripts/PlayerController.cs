using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public HingeJoint2D leftArm;
	public HingeJoint2D rightArm;
	public HingeJoint2D leftLeg;
	public HingeJoint2D rightLeg;
	
	public FixedJoint2D hand;
	
	private JointMotor2D leftArmMotor;
	private JointMotor2D rightArmMotor;
	private JointMotor2D leftLegMotor;
	private JointMotor2D rightLegMotor;
	
	
	
	private float armPower = 1;
	private float legPower = 100;
	
    // Start is called before the first frame update
    void Start()
    {
		GetMotors();
		leftArmMotor.motorSpeed = 500;
		rightArmMotor.motorSpeed = -500;
		SetMotors();
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
	
	void GetMotors() {
		leftArmMotor = leftArm.motor;
		rightArmMotor = rightArm.motor;
		leftLegMotor = leftLeg.motor;
		rightLegMotor = rightLeg.motor;
	}
	
	void SetMotors() {
		leftArm.motor = leftArmMotor;
		rightArm.motor = rightArmMotor;
		leftLeg.motor = leftLegMotor;
		rightLeg.motor = rightLegMotor;
	}
	void DoMovement() {
		GetMotors();
		
		Debug.Log("Doing movement");
		if (Input.GetKey(KeyCode.D)) {
			leftArmMotor.motorSpeed = MoveToZero(leftArm.jointAngle, leftArmMotor.motorSpeed, armPower);
		}
		else if (Input.GetKey(KeyCode.F)) {
			leftArmMotor.motorSpeed = MoveFromZero(leftArm.jointAngle, leftArmMotor.motorSpeed, armPower);
		}
		else {
			leftArmMotor.motorSpeed /= 1.1f;
		}
		
		if (Input.GetKey(KeyCode.C)) {
			leftLegMotor.motorSpeed = legPower;
		}
		else if (Input.GetKey(KeyCode.V)) {
			leftLegMotor.motorSpeed = -legPower;
		}
		else {
			leftLegMotor.motorSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.N)) {
			rightLegMotor.motorSpeed = legPower;
		}
		else if (Input.GetKey(KeyCode.M)) {
			rightLegMotor.motorSpeed = -legPower;
		}
		else {
			rightLegMotor.motorSpeed = 0;
		}
		
		if (Input.GetKey(KeyCode.J)) {
			rightArmMotor.motorSpeed = MoveFromZero(rightArm.jointAngle, rightArmMotor.motorSpeed, armPower);
		}
		else if (Input.GetKey(KeyCode.K)) {
			rightArmMotor.motorSpeed = MoveToZero(rightArm.jointAngle, rightArmMotor.motorSpeed, armPower);
		}
		else {
			rightArmMotor.motorSpeed /= 1.1f;
		}
		
		if (Input.GetKey(KeyCode.Space)) {
			hand.breakForce = 0;
		}
		
		
		Debug.Log("Left angle " + leftArm.jointAngle);
		Debug.Log("Right angle " + rightArm.jointAngle);
		
		SetMotors();
	}
	
    // Update is called once per frame
    void Update()
    {
		Debug.Log("Updating");
        DoMovement();
		
    }
}
