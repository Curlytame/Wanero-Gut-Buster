using UnityEngine;

public class EnemyCardPreview : MonoBehaviour
{
    [Header("Preview Settings")]
    public GameObject previewPrefab;          // visual-only stats preview prefab
    public Transform previewSpawnPoint;       // auto-found if not assigned

    [Header("Slide Settings")]
    public Vector3 slideOffset = new Vector3(-2f, 0f, 0f);
    public float slideSpeed = 8f;

    private GameObject previewInstance;
    private bool isHovering = false;

    private void Start()
    {
        // 🔎 Auto-find CardStatsPreviewPos (IMPORTANT FOR PREFABS)
        if (previewSpawnPoint == null)
        {
            GameObject pos = GameObject.Find("CardStatsPreviewPos");
            if (pos != null)
                previewSpawnPoint = pos.transform;
            else
                Debug.LogWarning("EnemyCardPreview: CardStatsPreviewPos not found in scene!");
        }
    }

    private void Update()
    {
        if (previewInstance != null && isHovering && previewSpawnPoint != null)
        {
            previewInstance.transform.position =
                Vector3.Lerp(
                    previewInstance.transform.position,
                    previewSpawnPoint.position,
                    Time.deltaTime * slideSpeed
                );
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;
        SpawnPreview();
    }

    private void OnMouseExit()
    {
        isHovering = false;
        DestroyPreview();
    }

    // -------------------------------------------------
    // PREVIEW SPAWN / DESTROY
    // -------------------------------------------------

    private void SpawnPreview()
    {
        if (previewPrefab == null || previewSpawnPoint == null)
            return;

        if (previewInstance != null)
            Destroy(previewInstance);

        previewInstance = Instantiate(previewPrefab);

        // start LEFT → slide to previewSpawnPoint
        previewInstance.transform.position =
            previewSpawnPoint.position + slideOffset;
    }

    private void DestroyPreview()
    {
        if (previewInstance != null)
        {
            Destroy(previewInstance);
            previewInstance = null;
        }
    }
}
