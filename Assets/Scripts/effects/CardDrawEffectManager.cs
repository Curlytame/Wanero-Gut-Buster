using System.Collections;
using UnityEngine;

public class CardDrawEffectManager : MonoBehaviour
{
    public static CardDrawEffectManager Instance;

    [Header("Effect Settings")]
    public GameObject effectPrefab;
    public int spawnCount = 3;          
    public float spawnRadius = 0.3f;    
    public float slideDistance = 0.5f;  
    public float slideSpeed = 5f;       
    public float moveSpeed = 3f;        
    public float fadeSpeed = 2f;        

    [Header("Timing")]
    public float activationDelay = 0f;   
    public float spawnDelay = 0.1f;      

    [Header("Options")]
    public bool autoPlay = true;         

    [Header("Target Position")]
    public Transform targetPos;          

    private void Awake()
    {
        Instance = this;
    }

    public void PlayEffect()
    {
        if (!autoPlay) return;

        // Play card draw sound
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlaySound(SoundManager.Instance.cardDrawSound);

        StartCoroutine(PlayWithDelay());
    }

    public void PlayDrawAnimation()
    {
        PlayEffect();
    }

    private IEnumerator PlayWithDelay()
    {
        if (effectPrefab == null || targetPos == null)
            yield break;

        if (activationDelay > 0f)
            yield return new WaitForSeconds(activationDelay);

        StartCoroutine(SpawnCardsSequentially());
    }

    private IEnumerator SpawnCardsSequentially()
    {
        int count = Random.Range(spawnCount, spawnCount + 2);

        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
            GameObject fx = Instantiate(effectPrefab, transform.position + randomOffset, Quaternion.identity);

            StartCoroutine(ShuffleThenMove(fx));

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private IEnumerator ShuffleThenMove(GameObject fx)
    {
        SpriteRenderer sr = fx.GetComponent<SpriteRenderer>();
        Color c = sr != null ? sr.color : Color.white;

        Vector3 slideTarget =
            fx.transform.position + (Vector3.right * Random.Range(-slideDistance, slideDistance));

        float randomRot = Random.Range(-15f, 15f);

        while (Vector3.Distance(fx.transform.position, slideTarget) > 0.01f)
        {
            fx.transform.position = Vector3.MoveTowards(
                fx.transform.position,
                slideTarget,
                slideSpeed * Time.deltaTime
            );

            fx.transform.rotation = Quaternion.Lerp(
                fx.transform.rotation,
                Quaternion.Euler(0, 0, randomRot),
                Time.deltaTime * 8f
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.05f);

        while (fx != null && Vector3.Distance(fx.transform.position, targetPos.position) > 0.01f)
        {
            fx.transform.position = Vector3.MoveTowards(
                fx.transform.position,
                targetPos.position,
                moveSpeed * Time.deltaTime
            );

            if (sr != null)
            {
                c.a -= Time.deltaTime * fadeSpeed;
                sr.color = c;
            }

            yield return null;
        }

        Destroy(fx);
    }
}
