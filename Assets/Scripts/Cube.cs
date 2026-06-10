
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 4f;
    private bool isMoving = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello Machaaa"+transform.position);
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Hehehe");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            Debug.Log("Movement Stopped!");
        }

        // Move forward continuously if not stopped
        if (isMoving)
        {
            transform.Translate(0, 0,speed * Time.deltaTime);
        }

    }
}
