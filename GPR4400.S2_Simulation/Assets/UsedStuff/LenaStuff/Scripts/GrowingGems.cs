using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingGems : MonoBehaviour
{
    public GameObject XtalPrefab;
    public float GrowingRate = 0.005f;
    public float TargetHeigth = 1.5f;
    private GameObject newXtal;


    void Start()
    {
        newXtal = Instantiate(XtalPrefab, transform.position, transform.rotation);
        StartCoroutine(GrowGemCour());
    }


    IEnumerator GrowGemCour()
    {
        for (float f = 0f; f <= TargetHeigth; f += GrowingRate)
        {
            newXtal.transform.localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(.1f);
        }
    }
}
