using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVSliderNumber : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text fovNum;

    

    // Update is called once per frame
    void Update()
    {
        fovNum.text = slider.value.ToString();
    }
}
