using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
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
