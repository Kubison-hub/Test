using TMPro;
using UnityEngine;

public class ItemUIManager : MonoBehaviour
{
    public TextMeshProUGUI itemCounterText;
    public int totalItemsRequired = 3;
    private int currentCollected = 0;

    void Start()
    {
        UpdateUI();
    }

    public void AddItem()
    {
        currentCollected++;
        UpdateUI();
    }

    void UpdateUI()
    {
        itemCounterText.text = $"Items Collected: {currentCollected} / {totalItemsRequired}";
    }

    public bool HasAllItems()
    {
        return currentCollected >= totalItemsRequired;
    }
}