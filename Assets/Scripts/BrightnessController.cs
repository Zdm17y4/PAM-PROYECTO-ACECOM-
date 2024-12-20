using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrightnessController : MonoBehaviour
{
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Image dimmerImage;

    private static BrightnessController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        brightnessSlider.value = 1f;
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    private void SetBrightness(float value)
    {
        Color dimmerColor = dimmerImage.color;
        dimmerColor.a = 1f - value;
        dimmerImage.color = dimmerColor;
    }
}
