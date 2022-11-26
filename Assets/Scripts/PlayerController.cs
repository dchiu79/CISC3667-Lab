using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(gameObject.transform.position.y < -6.0f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
