using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour {


    private Rigidbody rigid;
    public float playerSpeed = 0.05f;
	private bool canJump = true;
	private RaycastHit ray;

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked; //lock cursor to screen
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		// jumping physics
		Physics.Raycast (transform.position, Vector3.down, out ray); //create ray downwards

		if (Vector3.Distance (transform.position, ray.point) < 1.02f) //test distance to ground
		{
			canJump = true;
		}

		Debug.Log (Vector3.Distance (transform.position, ray.point)); //debug log distance to ground

        // movement up
		if(Input.GetKey(KeyCode.W)) //if key W down
        {
            transform.Translate(Vector3.forward * playerSpeed); //move forward
        }
        
		if (Input.GetKey(KeyCode.S)) //if key S down
        {
            transform.Translate(Vector3.back * playerSpeed); //move back
        }
        
		if (Input.GetKey(KeyCode.A)) //as above
        {
            transform.Translate(Vector3.left * playerSpeed); //as above
        }
        
		if (Input.GetKey(KeyCode.D)) //as above
        {
			transform.Translate(Vector3.right * playerSpeed); //as above
        }

		if (Input.GetKey(KeyCode.Space)) //if key space
		{
			if (canJump == true) //if you can jump
			{
				rigid.velocity = Vector3.up * 4.0f; //jump
				canJump = false; //disable jump
			}
		}
    }

}
