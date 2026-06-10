using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneToLoad = "SpaceEducationVR";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}