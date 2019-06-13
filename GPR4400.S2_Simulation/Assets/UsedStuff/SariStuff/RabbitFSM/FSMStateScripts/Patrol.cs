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

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

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
        }

        var direction = wayPoints[currentWaypoint].transform.position - Rabbit.transform.position;

        Rabbit.transform.rotation = Quaternion.Slerp(Rabbit.transform.rotation,
                                    Quaternion.LookRotation(direction),
                                    rotSpeed * Time.deltaTime);

        Rabbit.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
