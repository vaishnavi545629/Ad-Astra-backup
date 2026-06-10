using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_palyer : MonoBehaviour
{
    public string sceneToLoad = "SpaceEducationVR";

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Portal"))
        {
            Debug.Log("Portal Hit!");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}