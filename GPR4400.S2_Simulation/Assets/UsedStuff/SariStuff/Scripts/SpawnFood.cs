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
        //FoodSpawnPlace.transform.position = Food.transform.position;
    }
}
