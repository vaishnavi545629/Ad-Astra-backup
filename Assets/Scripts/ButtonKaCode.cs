using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonKaCode : MonoBehaviour
{
    public string sceneToLoad = "SpaceEducationVR";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed - Loading Scene");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void LoadScene()
    {
        Debug.Log("Button Clicked - Loading Scene");
        SceneManager.LoadScene(sceneToLoad);
    }
}