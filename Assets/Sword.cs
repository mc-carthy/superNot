using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	[SerializeField]
	private float swingRate;

	private Animator anim;
	private Collider col;
	private float timeToNextSwing = 0f;

	private void Awake() {
		anim = GetComponent<Animator>();
		col = GetComponent<Collider>();
	}
	
	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > timeToNextSwing)
		{
			timeToNextSwing = Time.time + swingRate;
			anim.Play("swing");
		}
	}

	public void EnableCollider()
	{
		col.enabled = true;
		gameObject.tag = "playerBullet";
	}

	public void DisableCollider()
	{
		col.enabled = false;
		gameObject.tag = "Untagged";
	}
}
