using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Brick : MonoBehaviour {

	[SerializeField] private int rotation = 90;
    [SerializeField] private int id;
    [SerializeField] private int width;
    [SerializeField] private int hight;

    private bool dragging = false;
    private float distance;

    private bool snapped = false;
    private Rigidbody rigidBody;

    private float stdSizeX = .8f;
	private float stdSizeY = 1.0f;
	private float stdSizeZ = .8f;

    [SerializeField] private GameObject board;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
    
    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.Euler(-90, rotation, 0);

        var currentPos = transform.position;

        float x = nearestMultiple(currentPos.x, stdSizeX);
        float y = nearestMultiple(currentPos.y, stdSizeY);
        float z = nearestMultiple(currentPos.z, stdSizeZ);
        transform.position = new Vector3(	
                                            x,
                                            currentPos.y,
                                            z
                                        );
        if (dragging) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            /*
            rayPoint.x = Limit(rayPoint.x, board.GetComponent<Collider>().bounds.size.x / 2 - board.transform.position.x, board.GetComponent<Collider>().bounds.size.x / 2 + board.transform.position.x);
            rayPoint.y = Limit(rayPoint.y, board.GetComponent<Collider>().bounds.size.y, 100);
            rayPoint.z = Limit(rayPoint.z, board.GetComponent<Collider>().bounds.size.z / 2 - board.transform.position.z, board.GetComponent<Collider>().bounds.size.z / 2 + board.transform.position.z);
            */
            transform.position = rayPoint;
            rigidBody.useGravity = true;
            snapped = false;
        }

        if (!snapped)
        {
            rigidBody.isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "4x2") {
            /* col.gameObject.transform.position = new Vector3(
                                                     (float)Math.Round(transform.position.x),
                                                     (float)Math.Round(transform.position.y),
                                                     (float)Math.Round(transform.position.z)
                                                 );*/
            rigidBody.isKinematic = true;
            snapped = true;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    private float nearestMultiple(float value, float factor)
    {
        return (float)Math.Round(
                     (value / (double)factor),
                     MidpointRounding.AwayFromZero
                 ) * factor;

    }

    private static float Limit(
        float value, float inclusiveMinimum, float inclusiveMaximum)
    {
        if (value < inclusiveMinimum) { return inclusiveMinimum; }
        if (value > inclusiveMaximum) { return inclusiveMaximum; }
        return value;
    }
}
