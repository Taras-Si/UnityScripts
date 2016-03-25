using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    //variables 
    private Transform fighter1; 
    private Transform fighter2;
    private float screenWidth;
    private float sceneWidth;
    private float cameraDistance;
    private Transform camera;
    private float xLeft; //left screen x coordination 
    private float xRight; // right screen x coordination 
    private float margin = 75.0f; //space between fighters and screen 
    private float z0 = 25f; // space between player and camera spawns? yes it is !

    //my methods
    private void calculateScreen(Transform fighter1pos,Transform fighter2pos)
    {
        if (fighter1pos.position.x < fighter2pos.position.x)
        {
            xLeft = fighter1pos.position.x - margin;
            xRight = fighter2pos.position.x + margin;
        }
        else
        {
            xRight = fighter1.position.x + margin;
            xLeft = fighter2pos.position.x - margin;
        }
    }

    private void setTransformX(float x)
    {
        transform.position = new Vector3(x,transform.position.y,transform.position.z);
    }

    private void setTransformZ(float z)
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,z);
    }

    //--------------------------------------------------

    
	// Use this for initialization
	void Start () {
        //find fighters positions
        fighter1 = GameObject.Find("Fighter1").transform;
        fighter2 = GameObject.Find("Fighter2").transform;

        calculateScreen(fighter1,fighter2);
        screenWidth = xRight - xLeft;
        cameraDistance = transform.position.z - z0;
	}
	
	// Update is called once per frame
	void Update () {
        calculateScreen(fighter1, fighter2);
        float width = xRight - xLeft;
        if (width > sceneWidth)
        {
            setTransformZ((cameraDistance * width) / screenWidth);
            Debug.Log("Screen width = "+screenWidth + "width = " +width);
        }

        setTransformX((xRight + xLeft) / 2);
	}
}
