using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAI : MonoBehaviour
{
    Animator anim;

    public GameObject player;
    public GameObject GetPlayer()
    {
        return player;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("PlayerDistance", Vector3.Distance(transform.position, player.transform.position));


        if (anim.GetBool("reachedWaypoint") == true)
        {
            StartCoroutine(WaitAMoment());
        }
    }

    IEnumerator WaitAMoment()
    {
        yield return new WaitForSecondsRealtime(5);
        anim.SetBool("reachedWaypoint", false);
    }
}
