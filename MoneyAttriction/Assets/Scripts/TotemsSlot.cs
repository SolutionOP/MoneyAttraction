using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TotemsSlot : MonoBehaviour, IDropHandler
{
    [Header("Prefabs")]
    [Tooltip("Main canvas")]
    [SerializeField]
    private Canvas canvas;

    private bool isSlotEmpty = true;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            SetNewTotemToSpawnSLot(eventData);  
        }
    }


    /// <summary>
    /// Check for empty slot
    /// </summary>
    private void CheckForEmptySlot()
    {
        if (!isSlotEmpty)
        {
            EmptyTotemsSlot();
        }
    }

    /// <summary>
    /// Destroy totem's gameObject
    /// </summary>
    private void EmptyTotemsSlot()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Set totem's new parent
    /// </summary>
    /// <param name="spawnedTotem"></param>
    private void SetTotemsParent(GameObject spawnedTotem)
    {
        spawnedTotem.transform.SetParent(transform, false);
    }


    /// <summary>
    /// Set spawned totem to totem's slot
    /// </summary>
    /// <param name="eventData"></param>
    private void SetNewTotemToSpawnSLot(PointerEventData eventData)
    {
        CheckForEmptySlot();
        GameObject spawnedTotem = Instantiate(eventData.pointerDrag.gameObject, Vector3.zero, Quaternion.identity);
        spawnedTotem.GetComponent<Totems>().ChangeSpawnConditions(false);
        spawnedTotem.GetComponent<Totems>().ChangeCanvasGroupProperties(spawnedTotem.GetComponent<CanvasGroup>(), true, 1f);
        SetTotemsParent(spawnedTotem);
        isSlotEmpty = false;
    }
}
