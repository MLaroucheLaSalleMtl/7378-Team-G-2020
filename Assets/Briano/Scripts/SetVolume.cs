using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioM;
    public string nameParam;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetVol(float val)
    {
        slider.value = val;
        audioM.SetFloat(nameParam, Mathf.Log10(val)*20);
    }
}
