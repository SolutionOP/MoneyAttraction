using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject[] frontCards;

    private GameObject currentFrontCard;

    public void OnPointerDown(PointerEventData eventData)
    {
        SetRandomFrontCard();
        StartFlip();
    }

    private void SetRandomFrontCard()
    {
        int tmpIndex = Random.Range(0,frontCards.Length);
        currentFrontCard = frontCards[tmpIndex];
    }

    private void StartFlip()
    {
        StartCoroutine(FlipCard());
    }

    private IEnumerator FlipCard()
    {
        currentFrontCard.transform.Rotate(0f, -90f, 0f);
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSecondsRealtime(0.001f);
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
        yield return new WaitForSecondsRealtime(0.5f);
        StartCoroutine(CardScale());
    }

    private IEnumerator CardScale()
    {
        for (int i = 0; i < 40; i++)
        {
            yield return new WaitForSecondsRealtime(0.01f);
            currentFrontCard.GetComponent<RectTransform>().localScale += new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}
