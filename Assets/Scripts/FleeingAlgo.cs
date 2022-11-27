using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingAlgo : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] bool flee = false;
    [SerializeField] bool fleeRight = false;
    [SerializeField] bool fleeLeft = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(transform.position.x-player.transform.position.x <= 2.0f && transform.position.x-player.transform.position.x >= 0.0f)
        {
            fleeLeft = false;
            fleeRight = true;
            flee = true;
        }
        else if(transform.position.x-player.transform.position.x >= -2.0f && transform.position.x-player.transform.position.x <= 0.0f)
        {
            fleeRight = false;
            fleeLeft = true;
            flee = true;
        }
        if(fleeRight==true && flee==true)
        {
            transform.position += new Vector3(5*Time.deltaTime, 0, 0);
        }
        else if(fleeLeft==true && flee==true)
        {
            transform.position += new Vector3(-5*Time.deltaTime, 0, 0);
        }

    }

    public bool GetFlee() {
        return flee;
    }

    public void SetFlee(bool f) {
        flee = f;
    }
}
