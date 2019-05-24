using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTempo : MonoBehaviour
{

    public FloatVariable musicTempo;
    public float quarternote_tempo;
    public float offbeatCorrection;

    // Start is called before the first frame update
    void Start()
    {
        musicTempo.value = (quarternote_tempo - offbeatCorrection) / 128;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
