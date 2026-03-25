using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootStepBar : MonoBehaviour
{
    private Slider bar;

    private void Awake()
    {
        
        bar = GameObject.Find("Slider").GetComponent<Slider>();
        
    }
    private void Start()
    {
        bar.maxValue = GameManager.Instance.footSound/100;
        bar.minValue = 0;
        bar.value = 0;
        bar.wholeNumbers = true;
        bar.fillRect.GetComponent<Image>().color = Color.white;
    }
    private void Update()
    {
        
        bar.value = GameManager.Instance.footSound/100;
    }
}
