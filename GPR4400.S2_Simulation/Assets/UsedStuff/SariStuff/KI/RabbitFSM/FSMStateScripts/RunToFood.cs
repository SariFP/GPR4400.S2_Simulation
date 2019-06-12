using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToFood : RabbitBaseFSM
{
    [SerializeField]
    GameObject Food;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Food") == false)
            return;

        Food = Rabbit.GetComponent<RabbitAI>().GetFood();
        if (animator.GetBool("Food") == true)
        {
            var direction = Food.transform.position - Rabbit.transform.position;

            Rabbit.transform.rotation = Quaternion.Slerp(Rabbit.transform.rotation,
                                        Quaternion.LookRotation(direction),
                                        rotSpeed * Time.deltaTime);

            Rabbit.transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (Vector3.Distance(Rabbit.transform.position, Food.transform.position) < 1.2f)
        {
            animator.SetBool("reachedFood", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
