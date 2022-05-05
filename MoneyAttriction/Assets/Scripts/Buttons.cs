using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void CloseMainCard()
    {
        GameObject mainCard = GameObject.FindGameObjectWithTag("MainCard");
        mainCard.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        mainCard.gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        transform.parent.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
