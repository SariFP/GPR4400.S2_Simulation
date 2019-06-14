using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
    public Slider Slider;
    public int sign = 1;
    private float ShiftUnit;

    private void Start()
    {
        ShiftUnit = Slider.maxValue / 50;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "controller")
        {
            if (coll.gameObject.transform.position.x < transform.position.x)
            {
                Slider.value += ShiftUnit * sign;
            }
            if (coll.gameObject.transform.position.x > transform.position.x)
            {
                Slider.value -= ShiftUnit * sign;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "controller")
        {
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                Slider.value += ShiftUnit * sign;
            }
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                Slider.value -= ShiftUnit * sign;
            }
        }
    }
}
