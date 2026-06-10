using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-1f,1f);
        float z = Random.Range(-1f,1f);
        transform.Translate(new Vector3(x,0,z)*speed*Time.deltaTime);
    }
}
