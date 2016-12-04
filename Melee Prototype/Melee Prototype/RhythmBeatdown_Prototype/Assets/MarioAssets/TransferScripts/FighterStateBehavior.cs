using UnityEngine;
using System.Collections;

public class FighterStateBehavior : StateMachineBehaviour {

	protected Fighter fighter;

	public FighterStates behaviorState;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (fighter == null)
		{
			fighter = animator.gameObject.GetComponent<Fighter> ();
		}

		fighter.currentState = behaviorState;

//		if (fighter.currentState == FighterStates.Attack)
//		{
//			animator.SetBool ("Transition", false);
//		}
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
//		if (fighter.currentState == FighterStates.Attack && animator.GetBool ("Transition") == false)
//		{
//			//Check for new attack input while in attack state
//			//Need to add ranged...
//			if (Input.GetButtonDown ("X360_A") || Input.GetButtonDown ("X360_X") || Input.GetButtonDown ("X360_Y"))
//			{
//				animator.SetBool ("Transition", true);
//			}
////			else
////			{
////				animator.SetBool ("Transition", false);
////			}
//		}
//		else
//		{
//			Debug.Log ("there is a transition");
//		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		if (fighter.currentState == FighterStates.Attack)
//		{
//
//		}
//	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
