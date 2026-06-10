using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject Cylinder;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cylinder, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
