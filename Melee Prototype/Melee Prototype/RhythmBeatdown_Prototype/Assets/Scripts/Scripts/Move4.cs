using UnityEngine;
using System.Collections;

public class Move4 : MonoBehaviour {

	private bool playerBool = true;
	private Rigidbody rb;
	private bool isGrounded = true;
	private bool jumping = false;
	private bool crouching = false;
	private float jumpForce = 20f;
	private float speed = 30f;
	private int jumpCount = 0;
	private float inputX;
	private float inputY;


	private bool falling;

	void Awake ()
	{
		rb = this.GetComponent<Rigidbody> ();
	}

	void OnEnable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			playerBool = true;
			InputManager.P1_Move += Move;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			playerBool = false;
			InputManager.P2_Move += Move;
		}
	}

	void OnDisable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			InputManager.P1_Move -= Move;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			InputManager.P2_Move -= Move;

		}
	}

	void Move (float axisValH, float axisValV)
	{

		inputX = axisValH;
		inputY = axisValV;

		jumping = inputY > 0.8f;



		if (inputX != 0 && isGrounded)
		{
			
			float velocity = Mathf.Clamp (inputX * speed, -10f, 10f);
			rb.velocity = new Vector3 (velocity, 0, 0);
		
		}
		if (jumping && isGrounded)
		{
			if (jumpCount < 1)
			{
				isGrounded = false; 
				jumpCount++;

				float jumpVelocity = Mathf.Clamp(inputX * speed, -15f, 15f);

				rb.velocity = Vector3.zero;
				rb.AddForce (jumpVelocity, jumpForce, 0, ForceMode.Impulse);
			}
		}

	}
		
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			isGrounded = true;
			jumping = false;
			jumpCount = 0;
			print ("Grounded");
		}
	}
}
