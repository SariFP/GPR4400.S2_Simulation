using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject Food;
    public GameObject FoodSpawnPlace;

    private void Start()
    {
        FoodSpawnPlace = this.gameObject;
    }

    public void FoodSpawn()
    {
        Instantiate(Food, FoodSpawnPlace.transform);
        Food.transform.position = FoodSpawnPlace.transform.position;
    }

    //private void Update()
    //{
    //    if(Input.GetButtonDown("Jump"))
    //    {
    //        Instantiate(Food, FoodSpawnPlace.transform);
    //        Food.transform.position = FoodSpawnPlace.transform.position;
    //    }
    //}
}
