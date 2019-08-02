using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }
    public bool isChangingScene;
    public Image Black;
    public Material StartHighlightedMat;
    public float delay = 5f;
    private MeshRenderer meshRend;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

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
        isChangingScene = true;
        Black.CrossFadeAlpha(1, delay, false);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SimulScene");
        PlayerManager.Instance.CheckY();
    }
}
