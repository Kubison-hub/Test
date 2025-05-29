using UnityEngine;

public class IsometricCameraSwitcher : MonoBehaviour
{
    [Header("Postacie do obserwacji")]
    public Transform[] targets;  // Lista postaci do œledzenia

    [Header("Ustawienia kamery")]
    public Vector3 offset = new Vector3(0, 10, -10);  // Przesuniêcie izometryczne
    public float smoothSpeed = 5f;

    [Header("Sterowanie")]
    public KeyCode switchKey = KeyCode.Tab;  // Domyœlny klawisz

    private int currentTargetIndex = 0;

    void Update()
    {
        // Prze³¹czanie postaci
        if (Input.GetKeyDown(switchKey))
        {
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        if (targets.Length > 0)
        {
            Vector3 desiredPosition = targets[currentTargetIndex].position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        }
    }

    void LateUpdate()
    {
        // Mo¿na opcjonalnie dodaæ obrót, jeœli kamera ma patrzeæ zawsze w dó³
        transform.rotation = Quaternion.Euler(30, 45, 0);
    }
}
