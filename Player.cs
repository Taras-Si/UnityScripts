using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float playerSpeed = 10.0f;
    public Animator anim;
    int JumpHash = Animator.StringToHash("Jump");
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {

        // player spawn point

        transform.position = new Vector3(0, 3, -25);
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {


        
       float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);

        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal")*-1, 0,0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;



            if (Input.GetButton("Jump"))
            {
                anim.SetTrigger(JumpHash);
                moveDirection.y = jumpSpeed;
            }
            
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime); 
            
            
        

        
	}
}
