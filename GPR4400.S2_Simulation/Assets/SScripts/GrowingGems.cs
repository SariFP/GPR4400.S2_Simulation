using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingGems : MonoBehaviour
{
    public GameObject GemPrefab;

    [SerializeField]
    private GameObject newGem;


    void Start()
    {
        newGem = Instantiate(GemPrefab, transform.position, transform.rotation);
        StartCoroutine(GrowGemCour());
    }


    IEnumerator GrowGemCour()
    {
        for (float f = 0f; f <= 3.5; f += 0.01f)
        {

            newGem.transform.localScale = new Vector3(f, f, f);

            yield return new WaitForSeconds(.1f);
        }

        //yield return new WaitForSeconds(5);
        //newGem.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    }
}
