using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField]
    private Text starScore;
    private int scoreValue = 0;

    public void PlusOneStar()
    {
        scoreValue += 1;
        starScore.text = scoreValue.ToString();
    }

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
