using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject pinFire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            Vector3 position = gameObject.transform.position;
            position.x += 2.0f;
            Instantiate(pinFire, position, Quaternion.identity);
        }
    }
}
