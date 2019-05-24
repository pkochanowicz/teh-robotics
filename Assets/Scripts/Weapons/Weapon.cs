using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour {

    [HideInInspector]
    public bool doesPlayerOwnIt;
    public string unsheatheSound;
    public string shootSound;
    public AudioManager audioManager;

    private Transform hand;

    public void OnEnable()
    {
        if (audioManager == null)
            audioManager = GameObject.FindGameObjectWithTag("GM").GetComponent<AudioManager>();
    }

    public void PlayUnsheatheSoundSound()
    {
        if (unsheatheSound != null)
        {
            audioManager.PlaySound(unsheatheSound);
        }
    }
}
