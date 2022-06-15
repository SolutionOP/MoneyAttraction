using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerIcons : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [Header("Prefabs")]
    [Tooltip("Main canvas object")]
    [SerializeField]
    private Canvas canvas;

    private RectTransform rectTransform;
    private bool isSpawned = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
      
    }


    /// <summary>
    /// Creating new player icon
    /// </summary>
    private void InstantiateIcon()
    {
        GameObject newIcon =  Instantiate(this.gameObject);
        newIcon.GetComponent<PlayerIcons>().enabled = false;
        newIcon.transform.SetParent(this.transform.parent, false);
        newIcon.transform.SetSiblingIndex(0);
    }

    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isSpawned)
        {
            isSpawned = true;
            InstantiateIcon();
        }
    }
}
