using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    public AudioSource OpenSource;

    private void Awake()
    {
        OpenSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        OpenSource.volume = 0;
        OpenSource.Play();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (OpenSource.volume < 0.5f)
        {
            OpenSource.volume += Mathf.Lerp(0f, 0.5f, 0.1f);
            yield return new WaitForSeconds(2);
        }
    }
}
