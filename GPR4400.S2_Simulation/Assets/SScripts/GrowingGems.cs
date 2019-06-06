using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingGems : MonoBehaviour
{
    public GameObject GemPrefab;
    public float GrowingRate= 0.005f;
    private GameObject newGem;


    void Start()
    {
        newGem = Instantiate(GemPrefab, transform.position, transform.rotation);
        StartCoroutine(GrowGemCour());
    }


    IEnumerator GrowGemCour()
    {
        for (float f = 0f; f <= 1.5f; f += GrowingRate)
        {
            newGem.transform.localScale = new Vector3(f, f, f);
            yield return new WaitForSeconds(.1f);
        }
    }
}
