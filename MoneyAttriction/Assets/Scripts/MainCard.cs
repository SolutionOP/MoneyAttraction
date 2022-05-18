using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainCard : MonoBehaviour, IPointerDownHandler
{
    [Header("Prefabs")]
    [Tooltip("Front cards array")]
    [SerializeField]
    private GameObject[] frontCards;

    [SerializeField]
    private GameObject mainCard;

    [Header("Values")]
    [Tooltip("Fullscreen front image array")]
    [SerializeField]
    private Image[] fullImages;

    private GameObject currentFrontCard;
    private Image currentTextCard;


    public void OnPointerDown(PointerEventData eventData)
    {
        SetRandomFrontCard();
        SetCurrentTextImage();
        StartFlip();
    }

    /// <summary>
    /// Set random front card index
    /// </summary>
    private void SetRandomFrontCard()
    {
        int tmpIndex = Random.Range(0,frontCards.Length);
        currentFrontCard = frontCards[tmpIndex];
    }

    /// <summary>
    /// Set random fullscreen card index
    /// </summary>
    private void SetCurrentTextImage()
    {
        currentTextCard = currentFrontCard.transform.parent.GetChild(1).gameObject.GetComponent<Image>();
    }


    /// <summary>
    /// Start flip card
    /// </summary>
    private void StartFlip()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        StartCoroutine(FlipCard());
    }


    /// <summary>
    /// Flip card caroutine
    /// </summary>
    /// <returns></returns>
    private IEnumerator FlipCard()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForFixedUpdate();
            if (i < 90)
            {
                transform.Rotate(0f, 1f, 0f);
            }
            else
            {
                currentFrontCard.SetActive(true);
                currentFrontCard.transform.Rotate(0f, 1f, 0f);
            }
        }
        StartCoroutine(ChangeAlphaFrontCard(this.gameObject, currentFrontCard));
    }

    /// <summary>
    /// Set Cards to initial state
    /// </summary>
    /// <param name="backCard">Back card object</param>
    /// <param name="frontCard">Front card object</param>
    private void SetCardsInitialState(GameObject backCard, GameObject frontCard)
    {
        backCard.transform.Rotate(0f, -90f, 0f);
        backCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
        frontCard.transform.Rotate(0f, -90f, 0f);
    }

    /// <summary>
    /// Change front card alpha
    /// </summary>
    /// <param name="backCard">Back card object</param>
    /// <param name="frontCard">Front card object</param>
    /// <returns></returns>
    private IEnumerator ChangeAlphaFrontCard(GameObject backCard, GameObject frontCard)
    {
        var color = currentTextCard.color;
        currentTextCard.gameObject.SetActive(true);
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            color.a += 0.1f;
            currentTextCard.color = color;
        }
        SetCardsInitialState(backCard, frontCard);
    }
}
