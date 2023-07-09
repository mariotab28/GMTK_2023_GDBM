using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{
    public string VolumeSliderGameObjectName = "VolumeSlider";
    private Slider slider;

    public float differenceBetweenInputAndVolume = 100f;
    private float volume = 0.5f;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        slider = GameObject.Find(VolumeSliderGameObjectName).GetComponent<Slider>();
        slider.value = volume * differenceBetweenInputAndVolume;
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume / differenceBetweenInputAndVolume;
    }

    public float GetVolume()
    {
        return volume;
    }
}
