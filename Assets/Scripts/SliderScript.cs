using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider audioSlider;
    [SerializeField] float volumeValue;
    [SerializeField] string volumeKey = "volume";
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(volumeKey))
        {
            audioSlider.value = PlayerPrefs.GetFloat(volumeKey);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Audio() 
    {
        volumeValue = audioSlider.value;
        PlayerPrefs.SetFloat(volumeKey, volumeValue);
    }
}
