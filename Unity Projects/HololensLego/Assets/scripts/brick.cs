using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public int rotationSpeed = 30;

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
    }

    Vector3 screenSpace;
    Vector3 offset;

    void OnMouseDown()
    {
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        var vec = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(vec);

    }

    void OnMouseDrag()
    {

        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        transform.position = curPosition;
    }
}
