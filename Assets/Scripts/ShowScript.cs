using UnityEngine;

public class ShowScript : MonoBehaviour
{
    public GameObject promptUI;
    public AudioSource audioSource;

    void Start()
    {
        promptUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            promptUI.SetActive(true);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}