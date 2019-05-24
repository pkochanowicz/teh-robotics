using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlChangerTrigger : MonoBehaviour
{
    private LevelChanger levelChanger;
    private bool hasFadeBegan = false;

    // Start is called before the first frame update
    void Start()
    {
        levelChanger = GetComponentInParent<LevelChanger>();
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player" && !hasFadeBegan)
        {
            hasFadeBegan = true;
            levelChanger.FadeToLevel(levelChanger.currentLevelIndex.value);
        }
    }
}
