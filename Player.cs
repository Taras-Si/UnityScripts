using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float playerSpeed = 5.0f;
    public Vector2 jump;

	// Use this for initialization
	void Start () {

        // player spawn point

        transform.position = new Vector3(0, 3, 0);

        //transform.rotation = new Quaternion(0, 180, 0, 0);
    }
	
	// Update is called once per frame
	void Update (){

        transform.Translate(Vector3.left * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
        }
	}
}
