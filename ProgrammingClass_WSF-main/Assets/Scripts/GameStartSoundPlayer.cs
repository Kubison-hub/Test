using UnityEngine;

public class GameStartSoundPlayer : MonoBehaviour
{
   private void Start()
    {
        SoundManager.Instance?.PlayGameStartSound();
    }
}
