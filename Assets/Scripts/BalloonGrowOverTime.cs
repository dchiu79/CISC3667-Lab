using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonGrowOverTime : MonoBehaviour
{
    const float maxSizeX = 4.0f;
    const float maxSizeY = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GrowObject", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //increase size of balloons over time
    //does something when balloons go over max size
    void GrowObject() 
    {
        Vector3 scale = new Vector3(1.0f, 1.0f, 0);
        gameObject.transform.localScale += scale;
        if(gameObject.transform.localScale.x>=maxSizeX && gameObject.transform.localScale.y>=maxSizeY) 
        {
            DestroyObject();
            ReloadLevel();
        }
    }

    //destroys this gameobject
    void DestroyObject() 
    {
        Destroy(gameObject);
    }

    //reload current level
    void ReloadLevel() 
    {
        PersistantData.Instance.SetScore(0);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
