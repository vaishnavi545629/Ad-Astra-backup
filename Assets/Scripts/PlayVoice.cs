using UnityEngine;

public class PlayVoice : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            audioSource.Play();
        }
    }
}