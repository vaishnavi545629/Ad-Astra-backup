using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("LOADING SCENE");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}