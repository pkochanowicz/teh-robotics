using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatherable : MonoBehaviour {

    public int pointsReward = 100;
    private bool isColliding;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isColliding) return;
            isColliding = true;
            Destroy(gameObject);
            Score playerScore = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Score>();
            playerScore.currentScore += pointsReward;
            return;
        }
    }
    void Update()
    {
        isColliding = false;
    }
}
