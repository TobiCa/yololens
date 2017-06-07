using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour {


	public GameObject brick;

    private string parent = "";
    private string level = "rootMenu";

    private Color color = Color.green;

	// Use this for initialization
	void Start () {
        GameObject.Find("GeneratorBoard/Menu/back").SetActive(false);
	}

	// Update is called once per frame
	void Update () {
       
	}

	public void InstantiateBrick(){

        var pos = new Vector3(3.2f, 1.5f, 4f);
        var rot = Quaternion.Euler(-90, 90, 0);
        GameObject go = Instantiate(brick, pos, rot) as GameObject;
        go.name = "4x2";
        go.tag = "Brick";
        go.AddComponent<Brick>();
        go.AddComponent<BoxCollider>();
 		go.GetComponent<Renderer>().material.color = color;
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
