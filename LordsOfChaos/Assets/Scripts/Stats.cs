﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    private Image content;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;

    private float currentValue;

    public float MyMaxValue { get; set; }
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {

            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
