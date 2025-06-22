using UnityEngine;
using DialogueEditor;

[System.Serializable]
public class InteractionSymbolSettings
{
    public string symbol = "?";
    public Color color = Color.white;
    [Range(10, 100)] public int fontSize = 20;
    [Range(0.05f, 0.5f)] public float characterSize = 0.1f;
    [Range(1f, 3f)] public float yOffset = 2f;
}

public class ConversationStarter : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Symbol Settings")]
    [SerializeField] private InteractionSymbolSettings symbolSettings = new InteractionSymbolSettings();

    private bool playerInRange = false;
    private TextMesh textMesh;
    private Camera mainCamera;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform not assigned in inspector!", this);
            return;
        }

        mainCamera = Camera.main;

        CreateInteractionSymbol();
    }

    private void CreateInteractionSymbol()
    {
        GameObject textObject = new GameObject("InteractionSymbol");
        textObject.transform.SetParent(playerTransform);
        textObject.transform.localPosition = Vector3.up * symbolSettings.yOffset;

        textMesh = textObject.AddComponent<TextMesh>();
        UpdateTextMeshProperties();

        textObject.SetActive(false);
    }

    private void UpdateTextMeshProperties()
    {
        if (textMesh == null) return;

        textMesh.text = symbolSettings.symbol;
        textMesh.color = symbolSettings.color;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.fontSize = symbolSettings.fontSize;
        textMesh.characterSize = symbolSettings.characterSize;
    }

    private void Update()
    {
        // Billboarding effect
        if (textMesh != null && mainCamera != null)
        {
            textMesh.transform.rotation = mainCamera.transform.rotation;
        }

        // Interaction check
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (textMesh != null) textMesh.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (textMesh != null) textMesh.gameObject.SetActive(false);
        }
    }

    // Optional: Update properties in editor when changed
    private void OnValidate()
    {
        if (textMesh != null)
        {
            UpdateTextMeshProperties();
            textMesh.transform.localPosition = Vector3.up * symbolSettings.yOffset;
        }
    }
}