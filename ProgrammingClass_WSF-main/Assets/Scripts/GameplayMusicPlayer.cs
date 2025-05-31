using UnityEngine;

public class GameplayMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip gameplayMusic;

    private void Start()
    {
        SoundManager.Instance?.PlayBackgroundMusic(gameplayMusic);
    }
}
