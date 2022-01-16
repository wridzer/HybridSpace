using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleScrip : MonoBehaviour
{
    public float sliderDecrease;
    public float sliderIncrease;
    public float decreaseTime;
    public float cooldownTime;
    public float redZone;

    public bool cooldown;

    public KeyCode keyCode;

    public Slider slider;
    public Color sliderColor;

    public float colorTimer;
    public Image fill;

    public bool higher;

    void Start()
    {
        slider = GetComponent<Slider>();
        //fill = GetComponent<Slider>();

        StartCoroutine(ReduceSlider());

        sliderColor = fill.color;
    }

    void Update()
    {
        //if correct key is held down increase slider amount
        if (Input.GetKey(keyCode))
        {
            slider.value += sliderIncrease;
        }

        if(higher == false)
        {
            if (slider.value < redZone)
            {
                fill.color = Color.Lerp(sliderColor, Color.red, Mathf.PingPong(Time.time, colorTimer));
            }
            else { fill.color = sliderColor; }
        }
        else
        {
            if (slider.value > redZone)
            {
                fill.color = Color.Lerp(sliderColor, Color.red, Mathf.PingPong(Time.time, colorTimer));
            }
            else { fill.color = sliderColor; }
        }
        
    }

    IEnumerator ReduceSlider()
    {
        //infinite loop that decreases slider over time
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);

            slider.value -= sliderDecrease;
        }
    }
}
