using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level 2"; // Ustaw nazw� sceny w Inspectorze lub tutaj

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed� w portal � �adowanie sceny: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
