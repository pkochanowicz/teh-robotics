using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalObject : MonoBehaviour {

    [SerializeField]
    private PhysicalObjectDefinition definition;

    public float HorizontalAcceleration = 8000f;
    public float MaxHorizontalSpeed = 400f;

    public float damageOnContact;
    public float maxHealth;
    public float health;
    public float invincibilityDuration;

    public int pointsReward;

    public Animator animator;
    public Sprite sprite;
    private bool wasLiveLastFrame;
    private bool isDyingFromFalling = false;

    [SerializeField]
    private int spawnDelay = 2;

    private bool _isInvincible = false;
    public bool isInvincible
    {
        get
        {
            return _isInvincible;
        }
        set
        {
            _isInvincible = value;
            if (animator.GetLayerName(1) == "Hurt")
            {
                if (_isInvincible)
                    animator.SetLayerWeight(1, 1);
                else
                    animator.SetLayerWeight(1, 0);
            }
        }
    }

    [SerializeField]
    private GameObject _body;

    public GameObject body
    {
        get
        {
            return _body;
        }
        set
        {
            _body = value;
        }
    }

    [SerializeField]
    public Transform spawnPoint;


    public void Start()
    {
    }

    public void ReceiveDmg(float damageReceived)
    {
        if (!isInvincible)
        {
            health -= damageReceived;
            StartCoroutine(SetGettingHitAnimation());
            if (invincibilityDuration > 0)
            {
                isInvincible = true;
                Invoke("resetInvulnerability", invincibilityDuration);
            }
        }
    }

    public void Kill()
    {
        RewardPlayerWithPoints();
        body.SetActive(false);    //play animation etc. and then disapear??
    }

    public void RewardPlayerWithPoints()
    {
        Score playerScore = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Score>();
        playerScore.currentScore += pointsReward;
    }

    private void Update()
    {
        if (body.transform.position.y < -100f && !isDyingFromFalling)
        {
            health = 0;
            isDyingFromFalling = true;
        }

        if (health <= 0)
        {
            if (wasLiveLastFrame)
            {
                Kill();
            }
        }
        wasLiveLastFrame = (health > 0);
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        body.transform.position = spawnPoint.position;
        isDyingFromFalling = false;
        body.SetActive(true);
    }

    public IEnumerator SetGettingHitAnimation()
    {
        if (GetAnimationClip("GetHit") != null )
        {
            if (animator.GetBool("IsGettingHit") != true)
            {
                animator.SetBool("IsGettingHit", true);
                yield return new WaitForSeconds(0.25f);
                animator.SetBool("IsGettingHit", false);
            }
        }
    }

    void resetInvulnerability()
    {
        isInvincible = false;
    }

    public AnimationClip GetAnimationClip(string name)
    {
        if (!animator) return null; // no animator
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }
        return null; // no clip by that name
    }
}