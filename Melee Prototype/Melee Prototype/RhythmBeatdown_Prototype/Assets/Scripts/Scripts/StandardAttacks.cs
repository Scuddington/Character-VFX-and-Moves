using UnityEngine;
using System.Collections;

public class StandardAttacks : MonoBehaviour {
	
	public GameObject projectileH;
	public GameObject projectileM;
	public GameObject projectileL;
	public GameObject p1SpawnPointH;
	public GameObject p1SpawnPointM;
	public GameObject p1SpawnPointL;
	public GameObject p2SpawnPointH;
	public GameObject p2SpawnPointM;
	public GameObject p2SpawnPointL;

	public float projectileHighUp = 15f;
	public float projectileMedUp = 6f;
	public float projectileLowUp = 3f;

	public float projectileSpeedHigh = 7f;
	public float projectileSpeedMed = 16f;
	public float projectileSpeedLow = 20f;

	public int attackCount = 0;
	public Animator anim;
	public Fighter fighter;
	private bool lowSwitch = false;
	private bool medSwitch = false;
	private bool highSwitch = false;
	public bool canChain = false;


	private bool canFire = true;
	private int projectileCounter = 0;

	void Start ()
	{
		anim = this.GetComponent<Animator> ();
		fighter = this.GetComponent<Fighter> ();
	}

	void OnEnable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A += LowAttack;
			InputManager.P1_X += MedAttack;
			InputManager.P1_Y += HighAttack;
			InputManager.P1_B += Dodge;
			InputManager.P1_RangedA += RangedLowAttack;
			InputManager.P1_RangedX += RangedMedAttack;
			InputManager.P1_RangedY += RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A += LowAttack;
			InputManager.P2_X += MedAttack;
			InputManager.P2_Y += HighAttack;
			InputManager.P2_B += Dodge;
			InputManager.P2_RangedA += RangedLowAttack;
			InputManager.P2_RangedX += RangedMedAttack;
			InputManager.P2_RangedY += RangedHighAttack;
		}
	}

	void OnDisable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A -= LowAttack;
			InputManager.P1_X -= MedAttack;
			InputManager.P1_Y -= HighAttack;
			InputManager.P1_B -= Dodge;
			InputManager.P1_RangedA -= RangedLowAttack;
			InputManager.P1_RangedX -= RangedMedAttack;
			InputManager.P1_RangedY -= RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A -= LowAttack;
			InputManager.P2_X -= MedAttack;
			InputManager.P2_Y -= HighAttack;
			InputManager.P2_B -= Dodge;
			InputManager.P2_RangedA -= RangedLowAttack;
			InputManager.P2_RangedX -= RangedMedAttack;
			InputManager.P2_RangedY -= RangedHighAttack;
		}
	}

	void LowAttack()
	{


		ChainCheck ();

		if (fighter.grounded && BoteManager.onBote == true)
		{
			//attackCount++;
			if (lowSwitch == false)
			{
				anim.SetTrigger ("LowAttack1");
				lowSwitch = !lowSwitch;
			}
			else
			{
				anim.SetTrigger ("LowAttack2");
				lowSwitch = !lowSwitch;
			}

		}

	}

	void MedAttack()
	{
		ChainCheck ();
		if (fighter.grounded && BoteManager.onBote == true)
		{
			if (medSwitch == false)
			{
				anim.SetTrigger ("MedAttack1");
				medSwitch = !medSwitch;
			}
			else
			{
				anim.SetTrigger ("MedAttack2");
				medSwitch = !medSwitch;
			}

		}

	}

	void HighAttack()
	{
		ChainCheck ();
		//attackCount = 0;
		if (fighter.grounded && BoteManager.onBote == true)
		{
			//attackCount++;
			if (highSwitch == false)
			{
				anim.SetTrigger ("HighAttack1");
				highSwitch = !highSwitch;
			}
			else
			{
				anim.SetTrigger ("HighAttack2");
				highSwitch = !highSwitch;
			}


		}

	}


	void Dodge()
	{
		print ("Dodge");
	}

	//Ranged Attacks
	void RangedLowAttack()
	{
		if (BoteManager.onBote == true)
		{
			if (projectileCounter < 1)
			{
				projectileCounter = 1;
				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 1);
					anim.SetTrigger ("RangedAttack");
				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 1);
					anim.SetTrigger ("RangedAttack");


				}


			}

		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedMedAttack()
	{
		if (BoteManager.onBote == true)
		{
			//this.gameObject
			if (projectileCounter < 1)
			{
				projectileCounter = 1;

				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 2);
					anim.SetTrigger ("RangedAttack");

				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 2);
					anim.SetTrigger ("RangedAttack");

				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedHighAttack()
	{
		if (BoteManager.onBote == true) 
		{
			if (projectileCounter < 1 ) 
			{
				projectileCounter = 1;
				//FireProjectile


				if (this.gameObject.tag == "Player_One") 
				{
					FireProjectile (1, 3);
					anim.SetTrigger ("RangedAttack");

				} 

				else if (this.gameObject.tag == "Player_Two") 
				{
					FireProjectile (2, 3);
					anim.SetTrigger ("RangedAttack");

				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

	void FireProjectile(int playerNum,int projectileType)
	{
		
		GameObject projectileHandler;
		Rigidbody tempRigidBody;

		if (playerNum == 1)
		{
			

			switch (projectileType)
			{
			case 1:
				projectileHandler = Instantiate (projectileL, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;
				projectileHandler.name = "Low";
				Lists.p1aprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedLow, projectileLowUp);

				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p1bprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileMedUp);
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p1cprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedHigh, projectileHighUp);
				break;
			default :

				projectileHandler = null;
				break;
			}




			//projectileHandler.name = "High";
		}
		else if (playerNum == 2)
		{
			


			switch (projectileType)
			{
			case 1:
				projectileHandler = Instantiate (projectileL, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;
				projectileHandler.name = "Low";
				Lists.p2aprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedLow, projectileLowUp);
				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p2bprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedMed, projectileMedUp);
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p2SpawnPointH.transform.position, p2SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p2cprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedHigh, projectileHighUp);
				break;
			default :

				projectileHandler = null;
				break;
			}


			
		}


		
	}
	void ChainWindowStart()
	{
		//print("set chain Window true");
		anim.SetBool ("Chain", false);
		anim.SetBool ("ChainWindow", true);


	}


	void ChainWindowStop()
	{
		print("set chain Window false");
		anim.SetBool ("ChainWindow", false);
		anim.SetBool ("Chain", false);
	}


	void ChainCheck()
	{
		print (anim.GetBool ("ChainWindow"));
		if (anim.GetBool("ChainWindow"))
		{
			if (Input.GetButtonDown ("X360_A") && !anim.GetBool ("Chain") || Input.GetButtonDown ("X360_X") && !anim.GetBool ("Chain") || Input.GetButtonDown ("X360_Y") && !anim.GetBool ("Chain"))
			{
				print ("set chain true");
				anim.SetBool ("Chain", true);
				anim.SetBool ("ChainWindow", false);
			}
			else
			{
				anim.SetBool ("Chain", false);
			}




		}
		else
		{
			print("set chain false");
			anim.SetBool ("Chain", false);
		}


	}


//	void ResetAttack()
//	{
//		attackCount = 0;
//	}




}
