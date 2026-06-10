using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 6f;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + Vector3.forward * movement;
    }
}
