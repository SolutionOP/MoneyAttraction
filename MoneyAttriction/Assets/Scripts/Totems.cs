using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Totems : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [Header("Prefabs")]
    [Tooltip("Main canvas")]
    [SerializeField]
    private Canvas canvas;
    private RectTransform m_RectTransform;
    private CanvasGroup m_CanvasGroup;
    public bool shouldSpawn = true;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        m_CanvasGroup.blocksRaycasts = false;
        m_CanvasGroup.alpha = 0.7f;
        m_RectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ChangeCanvasGroupProperties(m_CanvasGroup, true, 1f);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Changing group properties
    /// </summary>
    /// <param name="cGroup">Canvas group for change</param>
    /// <param name="rayValue">True/False ray value</param>
    /// <param name="alphaValue">Alpha chanel value</param>
    public void ChangeCanvasGroupProperties(CanvasGroup cGroup, bool rayValue, float alphaValue)
    {
        cGroup.blocksRaycasts = rayValue;
        cGroup.alpha = alphaValue;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        CheckForSpawnConditions();
    }


    /// <summary>
    /// Check for Spawn conditions of prefab
    /// </summary>
    private void CheckForSpawnConditions()
    {
        if (shouldSpawn)
        {
            GameObject spawnedTotem = Instantiate(this.gameObject);
            SetTotemToHierarchy(spawnedTotem);
            ChangeSpawnConditions(false);   
        }
    }


    /// <summary>
    /// Set totem's prefab to Heirarchy
    /// </summary>
    /// <param name="spawnedTotem"></param>
    private void SetTotemToHierarchy(GameObject spawnedTotem)
    {
        Transform Totems = canvas.transform.Find("Totems");
        spawnedTotem.transform.SetParent(Totems, false);
        spawnedTotem.transform.SetSiblingIndex(2);
    }

    public void ChangeSpawnConditions(bool value)
    {
        shouldSpawn = value;
    }
}