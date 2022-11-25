using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerName : MonoBehaviour
{
    [SerializeField] InputField changeName;
    // Start is called before the first frame update
    void Start()
    {
        changeName.text = PersistantData.Instance.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change() 
    {
        PersistantData.Instance.SetName(changeName.text);
    }
}
