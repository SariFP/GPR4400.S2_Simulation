using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitEat : RabbitBaseFSM
{
    [SerializeField]
    GameObject Food;

    int currentFood;

    private void Awake()
    {
        Food = GameObject.FindGameObjectWithTag("food");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentFood = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Food)
            return;

        if (Food)
        {
            animator.SetBool("Food", true);
            var direction = Food.transform.position - Rabbit.transform.position;

            Rabbit.transform.rotation = Quaternion.Slerp(Rabbit.transform.rotation,
                                        Quaternion.LookRotation(direction),
                                        rotSpeed * Time.deltaTime);

            Rabbit.transform.Translate(0, 0, Time.deltaTime * speed);
        }
        //animator.SetBool("Food", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
