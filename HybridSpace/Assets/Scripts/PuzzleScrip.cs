using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleScrip : MonoBehaviour
{
    public float sliderAmount;
    public float decreaseTime;
    public float cooldownTime;

    public bool cooldown;

    public KeyCode keyCode;

    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        StartCoroutine(ReduceSlider());
    }

    void Update()
    {
        //if correct key is pressed increase slider amount
        if (Input.GetKey(keyCode) && cooldown == false)
        {
            slider.value += sliderAmount;
            cooldown = true;
            Invoke("ResetCooldown", cooldownTime);
        }
    }

    IEnumerator ReduceSlider()
    {
        //infinite loop that decreases slider over time
        while (true)
        {
            yield return new WaitForSeconds(decreaseTime);

            slider.value -= sliderAmount;
        }
    }

    public void ResetCooldown()
    {
        //resets cool down bool
        cooldown = false;
    }
}
