using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioFadeOut : MonoBehaviour
{
    public static VideoPlayer VideoPlayer;
    public AudioSource OpenSource;

    private void Awake()
    {
        VideoPlayer = GetComponent<VideoPlayer>();
        OpenSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (LevelManager.Instance.isChangingScene)
        {
            StartCoroutine(FadeOut());
            LevelManager.Instance.isChangingScene = false;
        }
    }

    public IEnumerator FadeOut()
    {
        OpenSource.volume = VideoPlayer.GetDirectAudioVolume(0);
        while (OpenSource.volume > 0)
        {
            OpenSource.volume -= Mathf.Lerp(1, 0, 0.85f);
            yield return new WaitForSeconds(1);
        }
    }
}
