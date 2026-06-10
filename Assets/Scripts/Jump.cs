using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
// Start is called before the first frame update
public float speed = 5f;
void Start()
{
}
// Update is called once per frame
void Update()
{
   float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    float s = Input.GetAxis("Jump");
    transform.Translate((new Vector3(h,s,v))*speed*Time.deltaTime);
}
}