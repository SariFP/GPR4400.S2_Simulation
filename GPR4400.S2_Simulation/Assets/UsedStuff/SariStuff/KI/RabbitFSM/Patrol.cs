using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : RabbitBaseFSM
{
    public GameObject[] wayPoints;

    [SerializeField]
    int currentWaypoint;
    [SerializeField]
    int pointed;

    private void Awake()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wayPoints.Length == 0)
            return;

        if (Vector3.Distance(wayPoints[currentWaypoint].transform.position,
                            Rabbit.transform.position) < accuracy)
        {
            currentWaypoint++;
            pointed = currentWaypoint + 1;
            if (currentWaypoint >= wayPoints.Length)
            {
                currentWaypoint = 0;
            }

            if (currentWaypoint < pointed)
            {
                animator.SetBool("reachedWaypoint", true);
                pointed = currentWaypoint;
            }
            //else if (currentWaypoint == pointed)
            //{
            //    animator.SetBool("reachedWaypoint", false);
            //}
        }

        var direction = wayPoints[currentWaypoint].transform.position - Rabbit.transform.position;

        //facing to Waypoints
        Rabbit.transform.rotation = Quaternion.Slerp(Rabbit.transform.rotation,
                                    Quaternion.LookRotation(direction),
                                    rotSpeed * Time.deltaTime);

        //Moving
        Rabbit.transform.Translate(0, 0, Time.deltaTime * speed);
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
