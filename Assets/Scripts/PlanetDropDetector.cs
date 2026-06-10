using UnityEngine;

public class PlanetDropDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger: " + other.name);

        if (other.CompareTag("TrackingObject"))
        {
            string planetName = other.gameObject.name;
            planetName = planetName.Replace("(Clone)", "");

            Debug.Log("Planet Dropped: " + planetName);

            QuizManager qm = FindObjectOfType<QuizManager>();

            if (qm != null)
            {
                Debug.Log("QuizManager FOUND");
                qm.GenerateAIQuestion(planetName);
            }
            else
            {
                Debug.LogError("QuizManager NOT FOUND");
            }
        }
    }
}