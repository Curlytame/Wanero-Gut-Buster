using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Energy Settings")]
    public int maxEnergy = 5;
    public int currentEnergy;
    public int enemyMaxEnergy = 5;
    public int enemyCurrentEnergy;

    [Header("Enemy Settings")]
    public float enemyCardPlayDelay = 1.5f;
    public Transform enemyCardSpawnPoint;

    [Header("UI Reference")]
    public TextMeshProUGUI tpm;
    public TextMeshProUGUI enemyTpm;
    public Button endTurnButton;

    [Header("Card Settings")]
    public int startingHandSize = 5; // New: Set the starting number of cards
    public List<GameObject> cardPrefabs;
    public List<GameObject> enemyCardPrefabs;
    public RectTransform cardSpawnRect;
    public RectTransform cardHandRect;
    public float cardSpacing = 160f;
    public int maxHandSize = 7;
    public float moveDuration = 0.25f;

    private bool isPlayerTurn = true;
    private bool isEnemyTurn = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ResetEnergy();
        endTurnButton.onClick.AddListener(EndTurn);
        endTurnButton.gameObject.SetActive(true);

        // Draw starting cards
        DrawPlayerCards(startingHandSize);
    }

    public void ResetEnergy()
    {
        currentEnergy = maxEnergy;
        enemyCurrentEnergy = enemyMaxEnergy;
        UpdateEnergyDisplay();
    }

    public bool UseEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            UpdateEnergyDisplay();
            return true;
        }
        Debug.Log("Not enough energy!");
        return false;
    }

    public void UpdateEnergyDisplay()
    {
        if (tpm != null)
            tpm.text = "Energy: " + currentEnergy.ToString();
        if (enemyTpm != null)
            enemyTpm.text = "Enemy Energy: " + enemyCurrentEnergy.ToString();
    }

    public void EndTurn()
    {
        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            isEnemyTurn = true;
            endTurnButton.gameObject.SetActive(false);
            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator EnemyTurn()
    {
        while (isEnemyTurn && enemyCurrentEnergy > 0)
        {
            yield return new WaitForSeconds(enemyCardPlayDelay);

            GameObject selectedCard = enemyCardPrefabs[Random.Range(0, enemyCardPrefabs.Count)];
            GameObject cardObj = Instantiate(selectedCard, enemyCardSpawnPoint.position, Quaternion.identity, enemyCardSpawnPoint);
            EnemyCard card = cardObj.GetComponent<EnemyCard>();

            if (enemyCurrentEnergy >= card.energyCost)
            {
                enemyCurrentEnergy -= card.energyCost;
                card.UseCard();
                UpdateEnergyDisplay();
            }
            else
            {
                Destroy(cardObj); // Not enough energy, discard unused card
                break;
            }
        }

        yield return new WaitForSeconds(4f);
        ResetEnergy();
        DrawPlayerCards(3);
        isPlayerTurn = true;
        endTurnButton.gameObject.SetActive(true);
    }

    public void DrawPlayerCards(int amount)
    {
        List<GameObject> currentCards = new List<GameObject>(GameObject.FindGameObjectsWithTag("PlayerCard"));
        int spaceLeft = maxHandSize - currentCards.Count;
        int cardsToDraw = Mathf.Min(amount, spaceLeft);

        for (int i = 0; i < cardsToDraw; i++)
        {
            GameObject prefab = cardPrefabs[Random.Range(0, cardPrefabs.Count)];
            GameObject newCard = Instantiate(prefab);
            RectTransform newCardRect = newCard.GetComponent<RectTransform>();

            newCard.tag = "PlayerCard";

            Vector3 originalScale = newCardRect.localScale;
            newCardRect.SetParent(cardSpawnRect, worldPositionStays: true);
            newCardRect.localScale = originalScale;

            StartCoroutine(MoveCardToHandAfterDelay(newCardRect, 0.5f));
        }
    }

    private IEnumerator MoveCardToHandAfterDelay(RectTransform cardRect, float delay)
    {
        yield return new WaitForSeconds(delay);
        cardRect.SetParent(cardHandRect, worldPositionStays: true);
        ReflowCardsSmooth();
    }

    private void ReflowCardsSmooth()
    {
        List<RectTransform> cardList = new List<RectTransform>();
        foreach (Transform child in cardHandRect)
        {
            if (child.CompareTag("PlayerCard"))
                cardList.Add(child.GetComponent<RectTransform>());
        }

        float totalWidth = (cardList.Count - 1) * cardSpacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < cardList.Count; i++)
        {
            Vector2 target = new Vector2(startX + i * cardSpacing, 0);
            StartCoroutine(MoveCardSmoothly(cardList[i], target, moveDuration));
        }
    }

    private IEnumerator MoveCardSmoothly(RectTransform rect, Vector2 targetPos, float duration)
    {
        Vector2 startPos = rect.anchoredPosition;
        float time = 0f;

        while (time < duration)
        {
            rect.anchoredPosition = Vector2.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        rect.anchoredPosition = targetPos;
    }

    public void RemoveCard(GameObject card)
    {
        Destroy(card);
        StartCoroutine(ReflowCardsAfterDelay());
    }

    private IEnumerator ReflowCardsAfterDelay()
    {
        yield return new WaitForEndOfFrame();
        ReflowCardsSmooth();
    }
}
