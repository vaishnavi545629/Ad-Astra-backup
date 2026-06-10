 using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject promptUI;
    public AudioSource audioSource;

    private bool canPressE = false;

    void Start()
    {
        promptUI.SetActive(false);
    }

    // THIS is called by Button
    public void OnButtonClick()
    {
        promptUI.SetActive(true);
        canPressE = true;
        Debug.Log("BUTTON CLICKED");
        promptUI.SetActive(true);
    }

    void Update()
    {
        if (canPressE && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
        }
    }
}