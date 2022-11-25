using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    [SerializeField] Animator anim;

    const string VOLUMEKEY = "volume";
    const int IDLE = 0;
    const int POP = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(audio==null)
            audio = GetComponent<AudioSource>();

        if(PlayerPrefs.HasKey(VOLUMEKEY))
        {
            audio.volume = PlayerPrefs.GetFloat(VOLUMEKEY);
        }
        else
            audio.volume = 0.5f;

        if(anim==null)
            anim = GetComponent<Animator>();
        if(controller==null)
            controller = GameObject.FindGameObjectWithTag("GameController");
        anim.SetInteger("pop", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.tag=="Pin") 
        {
            anim.SetInteger("pop", POP);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position, audio.volume);
            Destroy(gameObject, 0.25f);
            controller.GetComponent<Scorekeeper>().AddPoints();
        }
    }
}
