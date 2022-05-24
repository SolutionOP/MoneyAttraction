using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    /// <summary>
    /// Close main card fo default state
    /// </summary>
    public void CloseMainCard()
    {
        GameObject mainCard = GameObject.FindGameObjectWithTag("MainCard");
        mainCard.GetComponent<CanvasGroup>().blocksRaycasts = true;
        mainCard.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        mainCard.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        transform.parent.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-60f, 10f, 0f);
        transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    /// <summary>
    /// Close side text card
    /// </summary>
    public void CloseSideCard()
    {
        var color = Color.white;
        color.a = 0f;
        transform.parent.gameObject.GetComponent<Image>().color = color;
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
