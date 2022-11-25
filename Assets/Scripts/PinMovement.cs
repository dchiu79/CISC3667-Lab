using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        if(rigid==null) 
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
