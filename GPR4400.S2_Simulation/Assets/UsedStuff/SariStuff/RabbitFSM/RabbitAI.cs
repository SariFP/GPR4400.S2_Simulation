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

    [SerializeField]
    GameObject food;

    public GameObject GetFood()
    {
        return food;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("PlayerDistance", Vector3.Distance(transform.position, player.transform.position));

        food = GameObject.FindGameObjectWithTag("food");
        if (food)
        {
            anim.SetFloat("FoodDistance", Vector3.Distance(transform.position, food.transform.position));
            anim.SetBool("Food", true);
        }

        if (anim.GetBool("reachedFood") == true)
        {
            StartCoroutine(Eating());
        }

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

    IEnumerator Eating()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(food);
        anim.SetBool("Food", false);
        anim.SetBool("reachedFood", false);
    }
}
