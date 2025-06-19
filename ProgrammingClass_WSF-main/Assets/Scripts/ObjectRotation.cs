using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    public float rotationSpeed = 45f; // stopnie na sekundę

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
