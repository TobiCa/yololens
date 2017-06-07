using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Brick : MonoBehaviour {

	[SerializeField] private int rotation = 90;
    [SerializeField] private int id;
    [SerializeField] private int width;
    [SerializeField] private int hight;

    //private bool placing = false;
    private float distance;

    private Rigidbody rigidBody;
    private BoxCollider boxCollider;

    private float stdSizeX = .8f;
	private float stdSizeY = .96f;
	private float stdSizeZ = .8f;

    private float scaleStuff = .25f;

    private Vector3 initscale = new Vector3(.05f, .05f, .05f);
    private Vector3 boxColliderSize = new Vector3(32f, 16f, 10f);
    private Vector3 boxColliderCenter = new Vector3(-16f, 8f, 5f);

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        transform.localScale = initscale;
        boxCollider.size = boxColliderSize;
        boxCollider.center = boxColliderCenter;
	}
    
    // Update is called once per frame
    void FixedUpdate () {
        transform.rotation = Quaternion.Euler(-90, rotation, 0);

        var currentPos = transform.position;

        float x = nearestMultiple(currentPos.x, stdSizeX * this.scaleStuff);
        float y = nearestMultiple(currentPos.y, stdSizeY * this.scaleStuff);
        float z = nearestMultiple(currentPos.z, stdSizeZ * this.scaleStuff);
        transform.position = new Vector3(	
                                            x,
                                            currentPos.y,
                                            z
                                        );

    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Brick") {
            /* col.gameObject.transform.position = new Vector3(
                                                     (float)Math.Round(transform.position.x),
                                                     (float)Math.Round(transform.position.y),
                                                     (float)Math.Round(transform.position.z)
                                                 );*/
            this.rigidBody.isKinematic = true;

        }
    }

    /*
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }*/
    
    private float nearestMultiple(float value, float factor)
    {
        return (float)Math.Round(
                     (value / (double)factor),
                     MidpointRounding.AwayFromZero
                 ) * factor;

    }

    private static float Limit(float value, float inclusiveMinimum, float inclusiveMaximum)
    {
        if (value < inclusiveMinimum) { return inclusiveMinimum; }
        if (value > inclusiveMaximum) { return inclusiveMaximum; }
        return value;
    }
}
