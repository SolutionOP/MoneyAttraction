using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerIcons : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Canvas canvas;

    private RectTransform rectTransform;

    private void Start()
    {
        GameObject newIcon =  Instantiate(this.gameObject);
        newIcon.GetComponent<PlayerIcons>().enabled = false;
        newIcon.transform.SetParent(this.transform.parent, false);
        newIcon.transform.SetSiblingIndex(0);
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
