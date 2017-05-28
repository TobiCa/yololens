using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour {


	[SerializeField] private GameObject brick;
<<<<<<< HEAD
    [SerializeField] private GameObject[] buttons;
=======
	[SerializeField] private GameObject[] buttons;
>>>>>>> 2adff272eb02f1e1ca52da9e9e94f425d00e27d8

    private Color color = Color.green;

    private Vector3 lastPosition;
	// Use this for initialization
	void Start () {
        lastPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
        transform.position = lastPosition;
	}

	public void InstantiateBrick(){

        var pos = new Vector3(3.2f, 1.5f, 4f);
        var rot = Quaternion.Euler(-90, 90, 0);
        GameObject go = Instantiate(brick, pos, rot) as GameObject;
        go.name = "4x2";
        go.AddComponent<Brick>();
        go.AddComponent<Rigidbody>();
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

		public void backToStart() {
			buttons.Where(obj => obj.name == "bricks").SingleOrDefault().SetActive(true);
			buttons.Where(obj => obj.name == "templates").SingleOrDefault().SetActive(true);
			buttons.Where(obj => obj.name == "saveLoad").SingleOrDefault().SetActive(true);
			buttons.Where(obj => obj.name == "sandbox").SingleOrDefault().SetActive(true);
		}







}
