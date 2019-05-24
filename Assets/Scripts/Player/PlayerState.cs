using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(PhysicalObject))]
public class PlayerState : MonoBehaviour
{
    //cache
    [SerializeField]
    private CameraController cameraController;
    public PhysicalObject physicalObject;
    public BoolVariable switchVariable;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private GameManager gameManager;

    //[SerializeField]
    public FloatVariable LifesLeft;

    public FloatVariable CurrentHealth;

    public FloatVariable MaxHealth;

    public event Action<float> LifeCountChangedEvent;


    private bool grounded = false;
    private bool isLookingUp = false;

    //public event Action<float> ScoreChanged;
    //public event Action<float> HPChanged;

    //public static float LifesLeft
    //{
    //    get
    //    {
    //        return lifesLeft;
    //    }
    //    set
    //    {
    //        lifesLeft = value;
    //        if (lifesLeft >= 0)
    //        {
    //            GameManager.lifesLeftText.text = "x " + lifesLeft.ToString();
    //        }
    //    }
    //}

    //private void Awake()
    //{
    //    LifeCountChangedEvent = new Action<float>();
    //}
    // Start is called before the first frame update
    void Start()
    {
        if (physicalObject == null)
        {
            physicalObject = gameObject.GetComponent<PhysicalObject>();
        }
        onLifeCountChange();
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();

        if (physicalObject.health <= 0 && LifesLeft.value >= 1)
        {
            KillPlayer();
        }

        if (LifesLeft.value <= 0)
        {
            switchVariable.value = true;
        }
    }

    public bool Grounded
    {
        get
        {
            return grounded;
        }
        set
        {
            grounded = value;
            if (grounded == true)
                physicalObject.animator.SetBool("IsJumping", false);
        }
    }

    public bool IsLookingUp
    {
        get
        {
            return isLookingUp;
        }
        set
        {
            isLookingUp = value;
            physicalObject.animator.SetBool("IsLookingUp", isLookingUp);
        }
    }


    //void OnDisable()
    //{
    //    LifeCountChangedEvent -= gameManager.handlePlayerLifeCountChange;
    //}

    public void KillPlayer()
    {
        LifesLeft.value -= 1;
        onLifeCountChange();

        //if (LifesLeft.value > 0)
        //{
        //    StartCoroutine(RespawnPlayer());
        //}
    }

    public void onLifeCountChange()
    {
        if (LifeCountChangedEvent != null)
        {
            LifeCountChangedEvent(LifesLeft.value);
        }
    }

    private void UpdateHealthBar()
    {
        CurrentHealth.value = physicalObject.health;
        MaxHealth.value = physicalObject.maxHealth;
    }
}
