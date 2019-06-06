using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBaseFSM : StateMachineBehaviour
{
    public GameObject Rabbit;
    public GameObject opponent;

    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Rabbit = animator.gameObject;
        opponent = Rabbit.GetComponent<RabbitAI>().GetPlayer();
    }
}
