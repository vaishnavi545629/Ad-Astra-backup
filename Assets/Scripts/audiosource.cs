using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosource : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            audioSource.Play();

        }
    }
}
