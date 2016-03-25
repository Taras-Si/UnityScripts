using UnityEngine;
using System.Collections;


public class MainCamera : MonoBehaviour {

    //variables 
    private Transform fighter1;
    private float f1_X_coor; // fighter 1 x coordinates
    private Transform fighter2;
    private float f2_X_coor;  //  fighter 2 x coordinates
    private float distance_f1_f2; // distance between two fighters 
    private float screenWidth;
    private float sceneWidth;
    private float cameraDistance;
    private Transform camera;
    private float xLeft; //left screen x coordination 
    private float xRight; // right screen x coordination 
    private float margin = 1000.0f; //space between fighters and screen 
    private float z0 = 30f;

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

        f1_X_coor = fighter1.transform.position.x;
        f2_X_coor = fighter2.transform.position.x;
        distance_f1_f2 = Mathf.Abs(f1_X_coor - f2_X_coor) * 0.02f; // % of distance to affect transform


        calculateScreen(fighter1, fighter2);
        float width = xRight - xLeft;
        if (width > sceneWidth)
        {
            setTransformZ((cameraDistance  * width * distance_f1_f2 / screenWidth));
            Debug.Log("Screen width = "+screenWidth + "width = " +width +"CamDist = " + cameraDistance + "distance f1 f2 = " + distance_f1_f2);
        }

        setTransformX((xRight + xLeft) / 2);
	}
}
