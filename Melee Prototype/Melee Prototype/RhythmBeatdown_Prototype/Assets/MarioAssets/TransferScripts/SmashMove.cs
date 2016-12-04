using UnityEngine;
using System.Collections;

public class SmashMove : MonoBehaviour
{

	private Fighter fighter;
	private Animator anim;
	private Rigidbody rb;
	private float speed = 13f;
	private float jumpForce = 20f;
	int jumpCount = 0;
	private bool grounded = true;
	private bool jumping = false;
	bool crouching = false;
	private float jumpDir;
	//private Vector3 targetPosition;
	//float dirNum;
	//float turnCheck = -1;
	//Vector3 movement;
	//Vector3 prevPos;
	//Vector3 newPos;
	//Vector3 fwd;
	bool moving = false;
	//int backNum = 0;
	//Vector3 posX = new Vector3(1, 0, 0);
	//Vector3 currentDir;


	void Start ()
	{
		fighter = this.GetComponent<Fighter> ();
		anim = this.GetComponent<Animator> ();
		rb = fighter.body;
	}

	void OnEnable ()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_Move += Move;
		}
		else if (this.gameObject.tag == "Player_Two") 
		{
			print ("p2 enabled");
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

	void Move (float inputX, float inputY)
	{
		//print (fighter.grounded);
		AttackCheck ();
		Vector3 localVel = transform.InverseTransformDirection (rb.velocity);
		anim.SetFloat ("InputX", localVel.z);
//	    currentDir = transform.forward;
		//anim.SetFloat ("MoveX", inputX);
		//anim.SetFloat ("MoveZ", inputX);
		//float negX = -inputX;

		//print (dirNum);
//		if (!moving)
//		{
//			anim.SetBool ("MovingBack", false);
//		}



		jumpDir = inputX;
		jumping = inputY > 0.4f;
		crouching = inputY < -0.8f;
		//dirNum = 0;

		//CheckCur ();
		//CheckBack ();
		Gravity ();
		CheckCrouch ();
		TargetPlayer ();

//		if (inputX != 0)
//		{
//			
//			moving = true;
//
//			anim.SetBool ("Moving", true);
//		}
//		else
//		{
//			moving = false;
//			anim.SetBool ("Moving", false);
//		}

//		if (this.gameObject.tag == "Player_One")
//		{
//			//Transform target = GameObject.Find ("Player_Two").transform;
//			//Vector3 heading = target.position - transform.position;
//			//dirNum = AngleDir (transform.forward, heading, transform.up);
//			//DetectTurn ();
//		}

		if (grounded)
		{
			
			anim.SetBool ("Grounded", true);
			//anim.SetFloat ("InputX", inputX);
			anim.SetFloat ("InputY", inputY);
			float velocity = Mathf.Clamp (inputX * speed, -100f, 100f);

			if (!crouching)
			{
				
//				if (dirNum == -1)
//				{
//					print ("Facing right");
//					anim.SetFloat ("InputX", inputX);
////					if (inputX < -0.1f)
////					{
////						anim.SetBool ("MovingBack", true);
////					}
////					else
////					{
////						anim.SetBool ("MovingBack", false);
////					}
//				}
//				else if (dirNum == 1)
//				{
//					print ("Facing left");
//					anim.SetFloat ("InputX", -inputX);
////					if (inputX > 0.1f)
////					{
////						anim.SetBool ("MovingBack", true);
////					}
////					else
////					{
////						anim.SetBool ("MovingBack", false);
////					}
//				}
				//Vector3 localVel = transform.InverseTransformDirection (rb.velocity);
				//localVel.z = inputX * speed;
				//rb.velocity = transform.TransformDirection (localVel);
				rb.velocity = new Vector3 (velocity, rb.velocity.y, 0);
			}
		}

//		if (currentDir == posX)
//		{
//			//anim.SetBool ("Flipped", false);
//			anim.SetFloat ("InputX", inputX);
//		}
//		else if(currentDir == -posX)
//		{
//			//anim.SetBool ("Flipped", true);
//			//anim.SetFloat ("NegX", negX);
//		}
		//CheckPrev ();
		//DetectTurn ();
	}

	void Jump ()
	{
		anim.SetBool ("Grounded", false);
		grounded = false;
		

		float jumpVelocity = Mathf.Clamp (jumpDir * speed, -100f, 100f);

		rb.velocity = Vector3.zero;
		rb.AddForce (jumpVelocity, jumpForce, 0, ForceMode.Impulse);
	}

	void CheckCrouch ()
	{
		if (crouching)
		{
			anim.SetBool ("Crouch", true);
		}
		else
		{
			anim.SetBool ("Crouch", false);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			anim.SetBool ("Jump", false);
			anim.SetBool ("Grounded", true);
			jumpCount = 0;
			grounded = true;
		}
	}

	void Gravity ()
	{
		rb.AddForce (Vector3.down * 15f);
	}

//	float AngleDir (Vector3 fwd, Vector3 targetDir, Vector3 up)
//	{
//		Vector3 perp = Vector3.Cross (fwd, targetDir);
//		float dir = Vector3.Dot (perp, up);
//
//		if (dir > 0f)
//		{
//			return 1f;
//		}
//		else if (dir < 0f)
//		{
//			return -1f;
//		}
//		else
//		{
//			return 0f;
//		}
//	}

	void TargetPlayer ()
	{
		if (this.gameObject.tag == "Player_One")
		{
//			Transform target = GameObject.Find ("Player_Two").transform;
//			targetPosition = new Vector3 (target.position.x, this.transform.position.y, 0);
//			this.transform.LookAt (targetPosition);
			float speed = 7f;
			Vector3 targetPos = GameObject.Find("Player_Two").transform.position;
			targetPos.y = transform.position.y;
			Quaternion targetDir = Quaternion.LookRotation (targetPos - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetDir, speed * Time.deltaTime);
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			float speed = 7f;
			Vector3 targetPos = GameObject.Find("Player_One").transform.position;
			targetPos.y = transform.position.y;
			Quaternion targetDir = Quaternion.LookRotation (targetPos - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetDir, speed * Time.deltaTime);
			//Transform target = GameObject.Find ("Player_One").transform;
			//targetPosition = new Vector3 (target.position.x, this.transform.position.y, 0);
			//this.transform.LookAt (targetPosition);
		}
	}
//	
	void AttackCheck()
	{
		if (fighter.attacking)
		{
			anim.SetBool ("Attacking", true);
		}
		else
		{
			anim.SetBool ("Attacking", false);
		}
	}

//	void DetectTurn ()
//	{
////		if (turnCheck != dirNum)
////		{
////			print ("Turn");
////			anim.SetTrigger ("Turn");
////			turnCheck = dirNum;
////		}
//	}
//	
//	void CheckBack()
//	{
//		Vector3 localVel = transform.InverseTransformDirection (rb.velocity);
//		if (localVel.z < 0)
//		{
//			anim.SetBool ("MovingBack", true);
//		}
//		else
//		{
//			anim.SetBool ("MovingBack", false);
//		}
//	}
//	void CheckCur ()
//	{
//		newPos = transform.position;
//		movement = (newPos - prevPos);
//
//		if (Vector3.Dot (fwd, movement) < 0 )
//		{
//			backNum = 1;
//			//anim.SetBool ("MovingBack", true);
//		}
//		else
//		{
//			backNum = 0;
//			//anim.SetBool ("MovingBack", false);
//		}
//	}
//
//	void CheckPrev ()
//	{
//		if (moving)
//		{
//			prevPos = transform.position;
//			fwd = transform.forward;
//		}
//	}

//	void CheckBack()
//	{
//		if (backNum == 1)
//		{
//			anim.SetBool ("MovingBack", true);
//		}
//		else
//		{
//			anim.SetBool ("MovingBack", false);
//		}
//	}
//
//	void Test()
//	{
//		if (currentDir == posX)
//		{
//			anim.SetFloat ("InputX", inputX);
//		}
//		//else if(currentDir == -posX)
//		else
//		{
//			anim.SetFloat ("InputX", -inputX);
//		}
//	}
}
