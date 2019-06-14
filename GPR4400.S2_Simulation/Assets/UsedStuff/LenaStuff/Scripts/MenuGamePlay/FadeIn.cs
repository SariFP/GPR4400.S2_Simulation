using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image Black;
    private float fadingTime = 5;

    private void Start()
    {
        Black.canvasRenderer.SetAlpha(1f);
        Fade();
    }

    private void Fade()
    {
        Black.CrossFadeAlpha(0.0f, fadingTime, false);
    }
}
