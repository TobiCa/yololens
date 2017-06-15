using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Generator : MonoBehaviour {

    public float brickScale = .25f;

    public float[] templateScales;

    public GameObject[] bricks;
    public GameObject[] templates;

    private System.Random rnd = new System.Random();

    private string parent = "";
    private string level = "rootMenu";
    
    
    private float stdSizeX = .8f;
    private float stdSizeY = .96f;
    private float stdSizeZ = .8f;
    

    private Color color = Color.green;
    private bool isSandbox = false;
    private Vector3 v3 = new Vector3(1,1,1);

    // Use this for initialization
    void Start () { 

	}

	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;


    }

    public void InstantiateBrick(int i) {
        var currentPos = transform.position;

        var where = stdSizeX * brickScale * 3;
        var x = currentPos.x + where;
        var y = currentPos.y;
        var z = currentPos.z - where;

        var pos = new Vector3(x, y, z);
        if (this.isSandbox)
        {
            pos = this.v3 + pos;
        }
        var rot = Quaternion.Euler(-90, 90, 0);
        GameObject go = Instantiate(bricks[i], pos, rot) as GameObject;
        go.tag = "Brick";
        go.transform.localScale = new Vector3(brickScale, brickScale, brickScale);
        var script = go.AddComponent<Brick>();
        script.scaleStuff = this.brickScale;
        go.AddComponent<HandDraggable>();
        Rigidbody rigidBody = go.AddComponent<Rigidbody>();
        BoxCollider boxCollider = go.AddComponent<BoxCollider>();
        var tempColor = this.color;
        if (this.isSandbox)
        {
            string[] colors = new string[3] { "red", "blue", "green" };
            
            int ind = rnd.Next(3);
            ChangeColor(colors[ind]);
        }
 		go.GetComponent<Renderer>().material.color = color;
        this.color = tempColor;
        Vector3 boxS = new Vector3(boxCollider.size.x, boxCollider.size.y, this.stdSizeY);
        boxCollider.size = boxS;
        Vector3 boxC = new Vector3(boxCollider.center.x, boxCollider.center.y, 0.5f);
        boxCollider.center = boxC;
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }

    public void InstantiateTemplate(int i) { 
        var currentPos = transform.position;

        var where = .512f;
        var x = currentPos.x + where;
        var y = currentPos.y;
        var z = currentPos.z - where;

        var pos = new Vector3(x, y, z);
        var rot = Quaternion.Euler(0, 0, 0);
        GameObject go = Instantiate(templates[i], pos, rot) as GameObject;
        go.tag = "Template";
        go.transform.localScale = new Vector3(this.templateScales[i], this.templateScales[i], this.templateScales[i]);
        var script = go.AddComponent<Template>();
        script.scaleStuff = this.templateScales[i];
        script.rotation = rot;
        go.AddComponent<HandDraggable>();
        Rigidbody rigidBody = go.AddComponent<Rigidbody>();
        BoxCollider boxCollider = go.AddComponent<BoxCollider>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }

    public void Sandbox() {
        this.isSandbox = true;
        for (int a =  0; a < 20; a++)
        {
            this.v3 = new Vector3(a * this.stdSizeX * this.brickScale * 2 , 0, this.stdSizeZ * this.brickScale);
            int ind = rnd.Next(3);
            this.InstantiateBrick(ind);
        }
        this.isSandbox = false; 
    }

    public void ChangeColor(string newColor) {
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
        GameObject.Find(root + newLevel).SetActive(false);
        GameObject.Find(root + newLevel).SetActive(true);

        parent = level;
        level = newLevel;

        if(level == "rootMenu") {
            GameObject.Find(root + "back").SetActive(false);
        } else {
            GameObject.Find(root + "back").SetActive(true);
        }
    }

    public void goBack() {
        goToLevel(parent);

        if (parent == "onlineMenu"){
            parent = "rootMenu";
        }
    }
}
