using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public ItemUIManager uiManager;
    private CollectibleManager manager;

    private void Start()
    {
        manager = Object.FindAnyObjectByType<CollectibleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (manager != null) manager.Collect();
            Destroy(gameObject);
            SoundManager.Instance?.PlayPickupSound();
            uiManager.AddItem();
        }
    }
}
