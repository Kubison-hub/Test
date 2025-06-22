using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
