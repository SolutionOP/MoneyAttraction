using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TotemsSlot : MonoBehaviour, IDropHandler
{
    [Header("Prefabs")]
    [Tooltip("Main canvas")]
    [SerializeField]
    private Canvas canvas;
    [Tooltip("Text for totem's counter")]
    [SerializeField]
    private Text totemsCounterText;
    [Tooltip("Empty object with child slots")]
    [SerializeField]
    private GameObject counter;

    private bool isSlotEmpty = true;
    private int totemsCounter = 1;


    public void OnDrop(PointerEventData eventData)
    {
        ChooseWrightSlot(eventData);
    }

    /// <summary>
    /// Choosing whirht slot to set totem
    /// </summary>
    /// <param name="eventData">Totem itself</param>
    private void ChooseWrightSlot(PointerEventData eventData)
    {
        for (int i = 0; i < 6; i++)
        {
            if (eventData.pointerDrag.gameObject.tag == transform.parent.transform.GetChild(i).gameObject.tag)
            {
                if (eventData.pointerDrag != null)
                {
                    transform.parent.transform.GetChild(i).gameObject.GetComponent<TotemsSlot>().SetNewTotemToSpawnSLot(eventData);
                }
            }
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
            if (child.gameObject.tag != "counter")
            {
                totemsCounter += 1;
                counter.SetActive(true);
                totemsCounterText.text = totemsCounter.ToString();
                Destroy(child.gameObject);
            }
        }
    }

    /// <summary>
    /// Set totem's new parent
    /// </summary>
    /// <param name="spawnedTotem">Totem game object for spawn</param>
    private void SetTotemsParent(GameObject spawnedTotem)
    {
        spawnedTotem.transform.SetParent(transform, false);
    }


    /// <summary>
    /// Set spawned totem to totem's slot
    /// </summary>
    /// <param name="eventData">Out of event</param>
    public void SetNewTotemToSpawnSLot(PointerEventData eventData)
    {
        CheckForEmptySlot();
        GameObject spawnedTotem = Instantiate(eventData.pointerDrag.gameObject, Vector3.zero, Quaternion.identity);
        spawnedTotem.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        spawnedTotem.GetComponent<Totems>().ChangeSpawnConditions(false);
        spawnedTotem.GetComponent<Totems>().ChangeCanvasGroupProperties(spawnedTotem.GetComponent<CanvasGroup>(), false, 1f);
        SetTotemsParent(spawnedTotem);
        spawnedTotem.transform.SetSiblingIndex(0);





        isSlotEmpty = false;
    }
}
