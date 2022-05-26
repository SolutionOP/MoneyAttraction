using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField]
    private Text starScore;
    [SerializeField]
    private GameObject[] playerIcons;
    [SerializeField]
    private GameObject[] ourIconsArray;
    private int scoreValue = 0;

    private void Start()
    {
        TurnOnPlayerIcons();
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
