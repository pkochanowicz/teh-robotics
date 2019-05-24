using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Handler : MonoBehaviour
{
    public FloatVariable musicTempo;
    public float tempoMultiplier = 1; //should be devisible by 4 or 4 multiplied
    //cache
    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = gameObject.GetComponent<Animator>();
        }

        animator.speed = musicTempo.value * tempoMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
