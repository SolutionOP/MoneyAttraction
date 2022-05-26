using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPanels;
    [SerializeField] private GameObject blurBackground;
    private int playersCount = 0;

    /// <summary>
    /// Changing Chek MArk Status
    /// </summary>
    /// <param name="checkMark"></param>
    public void ChangeMarkStatus(GameObject checkMark)
    {
        if (checkMark.activeInHierarchy)
        {
            checkMark.SetActive(false);
            checkMark.transform.tag = "passive";
            playersCount -= 1;
        }
        else
        {
            checkMark.SetActive(true);
            checkMark.transform.tag = "active";
            playersCount += 1;
        }
    }

    /// <summary>
    /// Start load the game
    /// </summary>
    public void StartTheGame()
    {
        if (playersCount > 0)
        {
            for (int i = 0; i < playersCount; i++)
            {
                playerPanels[i].gameObject.SetActive(true);
            }
            blurBackground.SetActive(false);
        }
    }
}
