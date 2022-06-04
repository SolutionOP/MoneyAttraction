using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPanel : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Main score of stars")]
    [SerializeField]
    private Text starScore;
    [Tooltip("PLayer icons array")]
    [SerializeField]
    private GameObject[] playerIcons;
    [Tooltip("Icons in players panel array")]
    [SerializeField]
    private GameObject[] ourIconsArray;
    [Tooltip("Game object of slot")]
    [SerializeField]
    private GameObject slotsObj;
    [Tooltip("Array of the winning scene")]
    [SerializeField]
    private GameObject[] winSc;
    private int scoreValue = 0;
    private string iconTag;
    private bool isWinningScene = false;


    private void Start()
    {
        TurnOnPlayerIcons();
    }

    private void Update()
    {
        if (CheckTotemsCount() && !isWinningScene)
        {
            LoadWinningImage();
        }
    }

    /// <summary>
    /// Loading the winning scene
    /// </summary>
    private void LoadWinningImage()
    {
        for (int i = 0; i < 5; i++)
        {
            if (winSc[i].tag == iconTag)
            {
                isWinningScene = true;
                winSc[i].transform.GetChild(0).GetComponent<Image>().raycastTarget = true;
                winSc[i].GetComponent<Animation>().Play(iconTag);
                StartCoroutine(ReloadScene());
            }
        }
    }

    /// <summary>
    /// Reloadin scene caroutine
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(0);
    }


    /// <summary>
    /// Checking for true full counter
    /// </summary>
    private bool CheckTotemsCount()
    {
        foreach (Transform child in slotsObj.transform)
        {
            int slotObjCounter = 0;
            foreach (Transform slot in child.transform)
            {
                slotObjCounter += 1;
            }
            if (slotObjCounter < 2)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Turning on player icons on panel
    /// </summary>
    private void TurnOnPlayerIcons()
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerIcons[i].transform.GetChild(0).gameObject.tag == "active")
            {
                for (int j = 0; j < 5; j++)
                {
                    if (playerIcons[i].tag == ourIconsArray[j].tag)
                    {
                        ourIconsArray[j].SetActive(true);
                        iconTag =  ourIconsArray[j].gameObject.tag;
                        playerIcons[i].transform.GetChild(0).gameObject.tag = "passive";
                        break;
                    }
                }
                break;
            }
        }
    }

    /// <summary>
    /// Plus one star to score value
    /// </summary>
    public void PlusOneStar()
    {
        scoreValue += 1;
        starScore.text = scoreValue.ToString();
    }

    /// <summary>
    /// Minus3 one star to score value
    /// </summary>
    public void MinusOneStar()
    {
        scoreValue -= 1;
        if (scoreValue < 0)
        { 
            scoreValue = 0;
        }
        starScore.text = scoreValue.ToString();
    }
}
