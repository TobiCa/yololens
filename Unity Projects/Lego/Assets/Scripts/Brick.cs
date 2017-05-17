using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int rotation = 90;
	public int id;
	public int width;
	public int hight;

	private float stdSizeX = .8f;
	private float stdSizeY = 1.0f;
	private float stdSizeZ = .8f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(-90, rotation, 0);

		var currentPos = transform.position;
		transform.position = new Vector3(	
										(float)Math.Round(currentPos.x),
		                             	(float)Math.Round(currentPos.y),
		                             	(float)Math.Round(currentPos.z)
		                             	);

	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "4x2") {
			col.gameObject.transform.position = new Vector3(
										(float)Math.Round(transform.position.x + stdSizeX * 2),
		                             	(float)Math.Round(transform.position.y + stdSizeY * 2),
		                             	(float)Math.Round(transform.position.z + stdSizeZ * 2)
		                             	);
		}
	}
}
