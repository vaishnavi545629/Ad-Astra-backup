using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    public static int totalCoins = 0;

    void Awake()
    {
        totalCoins++; // Awake is safer than Start
    }

    void Update()
    {
        transform.Rotate(60 * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinCount++;
            Debug.Log("Coin Collected! Total Coins = " + coinCount);

            if (coinCount == totalCoins)
            {
                Debug.Log("FINISH");
            }

            Destroy(gameObject);
        }
    }
}
