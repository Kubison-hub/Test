using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static bool clickBlocked = false;

    void LateUpdate()
    {
        // Resetujemy blokad� na ko�cu ka�dej klatki
        clickBlocked = false;
    }
}
