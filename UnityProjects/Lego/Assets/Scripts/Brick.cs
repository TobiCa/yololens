using System;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Quaternion rotation = Quaternion.Euler(-90f,90f,0f);

    private Rigidbody rigidBody;

    private float stdSizeX = .8f;
    //private float stdSizeX = .96f;
    private float stdSizeZ = .8f;

    public float scaleStuff = .01f;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
    
    // Update is called once per frame
    void Update () {
        transform.rotation = this.rotation;
        this.rotation = transform.rotation;
        var currentPos = transform.position;
        float x = nearestMultiple(currentPos.x, stdSizeX * this.scaleStuff);
        float z = nearestMultiple(currentPos.z, stdSizeZ * this.scaleStuff);
        transform.position = new Vector3(x, currentPos.y, z);
    }

    void OnCollisionEnter(Collision col) {
        this.rigidBody.isKinematic = true;
    }

    private void OnCollisionExit(Collision collision) {
        this.rigidBody.isKinematic = false;
    }

    private float nearestMultiple(float value, float factor)
    {
        return (float)Math.Round((value / (double)factor), MidpointRounding.AwayFromZero) * factor;
    }

    private static float Limit(float value, float inclusiveMinimum, float inclusiveMaximum)
    {
        if (value < inclusiveMinimum) { return inclusiveMinimum; }
        if (value > inclusiveMaximum) { return inclusiveMaximum; }
        return value;
    }
}
