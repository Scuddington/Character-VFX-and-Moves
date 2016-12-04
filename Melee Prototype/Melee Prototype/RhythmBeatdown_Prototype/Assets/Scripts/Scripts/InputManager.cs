using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public delegate void InputAction ();
	public delegate void InputAxes (float valueH, float valueV);
	public delegate void TriggerAxis (float value);
	public static event InputAction P1_A;
	public static event InputAction P2_A;
	public static event InputAction P1_B;
	public static event InputAction P2_B;
	public static event InputAction P1_X;
	public static event InputAction P2_X;
	public static event InputAction P1_Y;
	public static event InputAction P2_Y;

	public static event InputAction P1_RangedA;
	public static event InputAction P1_RangedB;
	public static event InputAction P1_RangedX;
	public static event InputAction P1_RangedY;

	public static event InputAction P2_RangedA;
	public static event InputAction P2_RangedB;
	public static event InputAction P2_RangedX;
	public static event InputAction P2_RangedY;

	public static event InputAction P1_Back;
	public static event InputAction P2_Back;
	public static event InputAction P1_Start;
	public static event InputAction P2_Start;
	public static event InputAction P1_LStickClick;
	public static event InputAction P2_LStickClick;

	public static event InputAction P1_LBump;
	public static event InputAction P1_RBump;
	public static event InputAction P2_LBump;
	public static event InputAction P2_RBump;

	public static event InputAxes P1_Move;
	public static event InputAxes P2_Move;

	public static event TriggerAxis P1_Trigger;
	public static event TriggerAxis P2_Trigger;

	// Update is called once per frame
	void Update () 
	{

		//Player1 movement
		if (P1_Move != null)
		{
			P1_Move (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		}
		//Player2 movement
		if (P2_Move != null)
		{
			P2_Move (Input.GetAxis ("Horizontalp2"), Input.GetAxis ("Verticalp2"));
		}

		//Player1 low attacks
		if (!Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_A")||Input.GetKeyDown(KeyCode.E))
		{
			if (P1_A != null)
			{
				
				P1_A ();
			}
		}
		else if (Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_A") || Input.GetKeyDown(KeyCode.Z))
		{
			if (P1_RangedA != null) 
			{
				P1_RangedA ();
			}	
		}
		//Player2 low attacks
		if (!Input.GetButton ("X360_LBumper2") && Input.GetButtonDown("X360_A2")|| Input.GetKeyDown(KeyCode.U))
		{
			if (P2_A != null) 
			{
				P2_A ();
			}
		}
			else if (Input.GetButton ("X360_LBumper2") && Input.GetButtonDown ("X360_A2")|| Input.GetKeyDown(KeyCode.N))
		{
			if (P2_RangedA != null) 
			{
				P2_RangedA ();
			}	
		}

		//Player1 Med attacks
		if (!Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_X")|| Input.GetKeyDown(KeyCode.R))
		{
			if (P1_X != null)
			{
				P1_X ();
			}
		}
		else if (Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_X")|| Input.GetKeyDown(KeyCode.X))
		{
			if (P1_RangedX != null) 
			{
				P1_RangedX ();
			}	
		}
		//Player2 Med attacks
		if (!Input.GetButton ("X360_LBumper2") && Input.GetButtonDown("X360_X2")||Input.GetKeyDown(KeyCode.I))
		{
			if (P2_A != null) 
			{
				P2_X ();
			}
		}
		else if (Input.GetButton ("X360_LBumper2") && Input.GetButtonDown ("X360_X2")||Input.GetKeyDown(KeyCode.M))
		{
			if (P2_RangedX != null) 
			{
				P2_RangedX ();
			}	
		}

		//Player1 High attacks
		if (!Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_Y")||Input.GetKeyDown(KeyCode.T))
		{
			if (P1_Y != null)
			{
				print ("Y");
				P1_Y ();
			}
		}
		else if (Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_Y")||Input.GetKeyDown(KeyCode.C))
		{
			if (P1_RangedY != null) 
			{
				print ("LY");
				P1_RangedY ();
			}	
		}
		//Player2 High attacks
		if (!Input.GetButton ("X360_LBumper2") && Input.GetButtonDown("X360_Y2")||Input.GetKeyDown(KeyCode.O))
		{
			if (P2_Y != null) 
			{
				P2_Y ();
			}
		}
		else if (Input.GetButton ("X360_LBumper2") && Input.GetButtonDown ("X360_Y2")||Input.GetKeyDown(KeyCode.Comma))
		{
			if (P2_RangedY != null) 
			{
				P2_RangedY ();
			}	
		}




		//Player1 Dodge/Check
		if (!Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_B"))
		{
			if (P1_B != null)
			{
				P1_B ();
			}
		}
		else if (Input.GetButton ("X360_LBumper") && Input.GetButtonDown ("X360_B"))
		{
			if (P1_RangedB != null) 
			{
				P1_RangedB ();
			}	
		}
		//Player2 Dodge/Check
		if (!Input.GetButton ("X360_LBumper2") && Input.GetButtonDown("X360_B2"))
		{
			if (P2_B != null) 
			{
				P2_B ();
			}
		}
		else if (Input.GetButton ("X360_LBumper2") && Input.GetButtonDown ("X360_B2"))
		{
			if (P2_RangedB != null) 
			{
				P2_RangedB ();
			}	
		}

		if (Input.GetAxis("X360_Triggers") != 0)
		{
			if (P1_Trigger != null) 
			{
				P1_Trigger (Input.GetAxis("x360_Triggers"));
			}
		}
		if (Input.GetAxis ("X360_Triggers2") != 0)
		{
			if (P2_Trigger != null) 
			{
				P2_Trigger (Input.GetAxis("X360_Triggers2"));
			}
		}

		if (Input.GetButtonDown("X360_Start"))
		{
			Application.Quit ();
			if (P1_Start != null) 
			{
				P1_Start ();
			}
		}
		if (Input.GetButtonDown("X360_Start2"))
		{
			Application.Quit ();
			if (P2_Start != null) 
			{
				P2_Start ();
			}
		}

//Don't need single bumber presses but will save for other situations

//		if (Input.GetButtonDown("X360_LBumper"))
//		{
//			if (P1_LBump != null) 
//			{
//				P1_LBump ();
//			}
//		}
//		if (Input.GetButtonDown("X360_LBumper2"))
//		{
//			if (P2_LBump != null) 
//			{
//				P2_LBump ();
//			}
//		}
//		if (Input.GetButtonDown("X360_RBumper"))
//		{
//			if (P1_RBump != null) 
//			{
//				P1_RBump ();
//			}
//		}
//		if (Input.GetButtonDown("X360_RBumper2"))
//		{
//			if (P2_RBump != null) 
//			{
//				P2_RBump ();
//			}
//		}


//		if (Input.GetButtonDown("X360_B"))
//		{
//			if (P1_B != null) 
//			{
//				P1_B ();
//			}
//		} 
//		if (Input.GetButtonDown("X360_B2"))
//		{
//			if (P2_B != null) 
//			{
//				P2_B ();
//			}
//		}
//		if (Input.GetButtonDown("X360_X"))
//		{
//			if (P1_X != null) 
//			{
//				P1_X ();
//			}
//		}
//		if (Input.GetButtonDown("X360_X2"))
//		{
//			if (P2_X != null) 
//			{
//				P2_X ();
//			}
//		}
//		if (Input.GetButtonDown("X360_Y"))
//		{
//			if (P1_Y != null) 
//			{
//				P1_Y ();
//			}
//		}
//		if (Input.GetButtonDown("X360_Y2"))
//		{
//			if (P2_Y != null) 
//			{
//				P2_Y ();
//			}
//		}
//		if (Input.GetButtonDown("X360_Back"))
//		{
//			if (P1_Back != null) 
//			{
//				P1_Back ();
//			}
//		}
//		if (Input.GetButtonDown("X360_Back2"))
//		{
//			if (P2_Back != null) 
//			{
//				P2_Back ();
//			}
//		}
	
//		if (Input.GetButtonDown("X360_LStick_Click"))
//		{
//			if (P1_LStickClick != null) 
//			{
//				P1_LStickClick ();
//			}
//		} 
//		if (Input.GetButtonDown("X360_LStick_Click2"))
//		{
//			if (P2_LStickClick != null) 
//			{
//				P2_LStickClick ();
//			}
//		}
	}
}
