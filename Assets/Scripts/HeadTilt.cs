using UnityEngine;

public class HeadTilt : MonoBehaviour
{
    public float tiltAngle = 20f;   // max tilt
    public float tiltSpeed = 5f;

    private float currentTilt = 0f;

    void Update()
    {
        float targetTilt = 0f;

        if (Input.GetKey(KeyCode.Z))
            targetTilt = tiltAngle;

        if (Input.GetKey(KeyCode.X))
            targetTilt = -tiltAngle;

        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);

        // Apply tilt ONLY on Z axis
        Vector3 rot = transform.localEulerAngles;
        transform.localRotation = Quaternion.Euler(0, 0, currentTilt);
    }
}