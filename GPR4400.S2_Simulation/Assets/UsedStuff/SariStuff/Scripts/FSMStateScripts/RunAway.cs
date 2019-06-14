using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : RabbitBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var xDirection = opponent.transform.position.x + Rabbit.transform.position.x;
        var zDirection = opponent.transform.position.z + Rabbit.transform.position.z;
        var direction = new Vector3(xDirection, 0, zDirection);

        Rabbit.transform.rotation = Quaternion.Slerp(Rabbit.transform.rotation, Quaternion.LookRotation(direction),
                                    rotSpeed * Time.deltaTime);

        Rabbit.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
