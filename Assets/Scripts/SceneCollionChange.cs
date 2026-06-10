using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollisonChange : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollsionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene("next scene");
        }
    }
}
