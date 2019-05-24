using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public IntVariable currentLevelIndex;

    public int thisLevelIndex;
    private Animator animator;

    private void Start()
    {
        if (animator == null)
        {
            animator = gameObject.GetComponent<Animator>();
        }
        currentLevelIndex.value = thisLevelIndex;
        if (thisLevelIndex == 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.Length; i++)
            {
                players[i].GetComponentInParent<PlayerState>().LifesLeft.value = 3;
                players[i].GetComponentInParent<PlayerState>().CurrentHealth.value = 100f;
                players[i].GetComponentInParent<PlayerState>().MaxHealth.value = 100f;
                players[i].GetComponentInParent<Score>().currentScore = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToLevel (int levelIndex)
    {
        currentLevelIndex.value += 1;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(currentLevelIndex.value);
    }
}
