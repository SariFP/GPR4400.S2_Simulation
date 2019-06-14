using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image Black;
    public Material StartHighlightedMat;
    private float delay = 5f;
    private MeshRenderer meshRend;
    
private void Start()
    {
        Black.canvasRenderer.SetAlpha(0.0f);
        meshRend = GetComponent<MeshRenderer>();
    }

    private void OnMouseEnter()
    {
        meshRend.material = StartHighlightedMat;
        StartCoroutine(ChangeScene());
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "controller")
        {
            meshRend.material = StartHighlightedMat;
            StartCoroutine(ChangeScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "controller")
        {
            meshRend.material = StartHighlightedMat;
            StartCoroutine(ChangeScene());
        }
    }


    IEnumerator ChangeScene()
    {
        Black.CrossFadeAlpha(1, delay, false);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
}
