using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustAnimationScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogWarning($"Enter {animator.gameObject.name} {animator.gameObject.transform.position.ToString()}");
        animator.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); 
        Debug.LogWarning($"Enter after {animator.gameObject.name} {animator.gameObject.transform.position.ToString()}");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); 
    }
    
    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogWarning($"Exit {animator.gameObject.name} {animator.gameObject.transform.position.ToString()}");
        animator.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); 
        Debug.LogWarning($"Exit after {animator.gameObject.name} {animator.gameObject.transform.position.ToString()}");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that sets up animation IK (inverse kinematics)
    //}
}
