using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float playerSpeed = 5.0f;

	// Use this for initialization
	void Start () {

        // player spawn point

        transform.position = new Vector3(-100, 3, -25);

        //transform.rotation = new Quaternion(0, 180, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

       

            transform.Translate(Vector3.left * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);


       
          
            
            
        

        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
	}
}
