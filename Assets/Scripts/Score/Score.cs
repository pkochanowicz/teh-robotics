using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    [SerializeField]
    public IntVariable scoreFile;

    public int currentScore
    {
        get { return scoreFile.value; }
        set { scoreFile.value = value;
            scoreText.text = scoreFile.value.ToString();

        }
    }
    public void Start()
    {
        currentScore = currentScore;
    }
}
