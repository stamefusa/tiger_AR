using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMovingScript : MonoBehaviour {

	// tiger prefab
	public GameObject tiger;

	public float speed = 100;

	public Vector3 zeroPoint = new Vector3(-0.07f, -1.51f, 0.0f);

	// Use this for initialization
	void Start () {
		Vector3 force;
		force = this.gameObject.transform.forward * speed;
		tiger.GetComponent<Rigidbody> ().AddForce (force);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			tiger.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			transform.position = zeroPoint;
		}
		/*
		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			tiger.GetComponent<Rigidbody> ().AddForce (force);
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			tiger.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			transform.position = zeroPoint;
		} else if (Input.GetMouseButton(0)) {
			Vector3 newPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
			transform.position = newPoint;
			Debug.Log ("Position:" + newPoint);
		}
		*/
	}
}