using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using HoloToolkit.Unity.InputModule;

public class Generator : MonoBehaviour {

    public float brickScale = .25f;
    public GameObject[] bricks;

    private Vector3 boxColliderSize = new Vector3(32f, 16f, 10f);
    private Vector3 boxColliderCenter = new Vector3(-16f, 8f, 5f);

    private string parent = "";
    private string level = "rootMenu";
    
    /*
    private float stdSizeX = .8f;
    private float stdSizeY = .96f;
    private float stdSizeZ = .8f;
    */

    private Color color = Color.green;

	// Use this for initialization
	void Start () {
        GameObject.Find("GeneratorBoard/Menu/back").SetActive(false);
	}

	// Update is called once per frame
	void Update () {
       
	}

    public void InstantiateBrick(int i) {

        var currentPos = transform.position;

        var where = .256f;
        var x = currentPos.x + where;
        var y = currentPos.y;
        var z = currentPos.z - where;

        var pos = new Vector3(x, y, z);
        var rot = Quaternion.Euler(-90, 90, 0);
        GameObject go = Instantiate(bricks[i], pos, rot) as GameObject;
        go.tag = "Brick";
        go.transform.localScale = new Vector3(brickScale, brickScale, brickScale);
        go.AddComponent<Brick>();
        go.AddComponent<HandDraggable>();
        Rigidbody rigidBody = go.AddComponent<Rigidbody>();
        BoxCollider boxCollider = go.AddComponent<BoxCollider>();
 		go.GetComponent<Renderer>().material.color = color;
        boxCollider.size = boxColliderSize * brickScale;
        boxCollider.center = boxColliderCenter * brickScale;
        rigidBody.useGravity = true;
    }

    public void ChangeColor(string newColor){
        switch(newColor){
            case "red":
                color = Color.red;
                break;
            case "green":
                color = Color.green;
                break;
            case "blue":
                color = Color.blue;
                break;
            default:    
                color = Color.black;
                break;
        }
    }

    public void goToLevel(string newLevel) {
        var root = "GeneratorBoard/Menu/";
        GameObject.Find(root + level).SetActive(false);
        GameObject.Find(root + newLevel).SetActive(true);

        parent = level;
        level = newLevel;

        if(level == "rootMenu") {
            GameObject.Find(root + "back").SetActive(false);
        } else {
            GameObject.Find(root + "back").SetActive(true);
        }
    }

    public void goBack(){

        goToLevel(parent);

        if (parent == "onlineMenu"){
            parent = "rootMenu";
        }

    }
}
