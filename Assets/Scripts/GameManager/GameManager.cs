using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    //[SerializeField]
    public GameObject PlayerObject;
    //public GameObject PlayerObject
    //{
    //    get
    //    {
    //        return playerObject;
    //    }

    //    set
    //    {
    //        if (PlayerObject != null)
    //        {
    //            lifeState.LifeCountChangedEvent -= handlePlayerLifeCountChange;
    //        }

    //        playerObject = value;

    //        if (PlayerObject != null)
    //        {
    //            lifeState.LifeCountChangedEvent += handlePlayerLifeCountChange;
    //        }
    //    }
    //}

    private PlayerState playerState
    {
        get
        {
            if (PlayerObject == null)
            {
                Debug.LogError("playerObject does not exist!");
                return null;
            }

            PlayerState _lifeState = PlayerObject.GetComponent<PlayerState>();

            if (_lifeState == null)
            {
                Debug.LogError("Invalid playerObject provided!! It does not have PlayerLifeState");
            }

            return _lifeState;
        }
    }

    private PhysicalObject playerPhysicalObject
    {
        get
        {
            if (PlayerObject == null)
            {
                Debug.LogError("playerObject does not exist!");
                return null;
            }
            return PlayerObject.GetComponent<PhysicalObject>();
        }
    }



    [SerializeField]
    private Image healthBar;

    private AudioManager audioManager;

    [SerializeField]
    private BoolVariable isGameOver;



    //private bool gameHasEnded = false;

    void Start()
    {
        if (PlayerObject != null)
        {
            playerState.LifeCountChangedEvent += handlePlayerLifeCountChange;
        }

        //FindGameManagerComponents();
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No AudioManager found in scene.");
        }
    }

    public void handlePlayerLifeCountChange(float newPlayerLifeCount)
    {
        if (newPlayerLifeCount <= 0)
        {
            EndGame();
        }
        else
        {
            playerPhysicalObject.health = playerPhysicalObject.maxHealth;
            StartCoroutine(playerState.physicalObject.Respawn());
        }
    }

    public void EndGame()
    {
        isGameOver.value = true;
    }
}
