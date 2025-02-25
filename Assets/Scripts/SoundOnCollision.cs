using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip audioClip;
	public float pitchScale = 1;
	public float volume = 1;
	private float minCollisionMagnitude = 2;
	private float maxCollisionMagnitude = 50;
	
	
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		audioSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	float MapRangeOntoOtherRange(float value, float r1Min, float r1Max, float r2Min, float r2Max) {
		value = Math.Clamp(value, r1Min, r1Max);
		float scale = (r2Max - r2Min) / (r1Max - r1Min);
		value = r2Min + ((value - r1Min) * scale);
		return value;
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (
			collision.relativeVelocity.magnitude > minCollisionMagnitude && 
			!collision.gameObject.CompareTag("Player")
		) {
			audioSource.pitch = pitchScale * MapRangeOntoOtherRange(collision.relativeVelocity.magnitude, minCollisionMagnitude, maxCollisionMagnitude, 0.5f, 2.0f);
			audioSource.PlayOneShot(audioClip);
		}
	}
}
