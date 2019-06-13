using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToFood : RabbitBaseFSM
{
    [SerializeField]
    GameObject Food;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

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

        if (Vector3.Distance(Rabbit.transform.position, Food.transform.position) < 0.5f)
        {
            animator.SetBool("reachedFood", true);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
