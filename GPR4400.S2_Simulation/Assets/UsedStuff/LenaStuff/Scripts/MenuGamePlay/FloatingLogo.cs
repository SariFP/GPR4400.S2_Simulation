using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingLogo : MonoBehaviour
{
    public float Timer=2;
    public float yMin=0.9f;
    public float yMax=1.2f;
    private bool goingDown;

    void Start()
    {
        goingDown = true;
        
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0f)
        {
            if (goingDown && transform.position.y > yMin)
            {
                transform.Translate(Vector3.down * Time.deltaTime / 4, Space.World);
            }
            if (transform.position.y <= yMin)
            {
                goingDown = false;
            }
            if (!goingDown && transform.position.y < yMax)
            {
                transform.Translate(Vector3.up * Time.deltaTime / 4, Space.World);
            }
            if (transform.position.y >= yMax)
            {
                goingDown = true;
            }
        }
    }
}
