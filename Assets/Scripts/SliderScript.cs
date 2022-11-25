using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] Slider audioSlider;
    [SerializeField] float volume;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Audio() 
    {
        AudioListener.volume = audioSlider.value;
        volume = AudioListener.volume;
    }
}
