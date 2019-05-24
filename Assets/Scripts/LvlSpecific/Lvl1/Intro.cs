using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Intro : MonoBehaviour
{
    public Transform player;
    public GameObject laboratoryFront;
    public GameObject laboratoryBack;
    public GameObject destroyedLaboratory;
    public Transform playerGoTo;
    public float playerSpeed = 0.15f;
    public float timeToWaitForExplosion = 2.5f;
    public float timeOfExplosion = 1.8f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LaboratoryExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        player.position = Vector2.MoveTowards(player.transform.position, playerGoTo.transform.position, playerSpeed);
    }

    public IEnumerator LaboratoryExplosion()
    {
        player.transform.parent.GetComponent<PlayerMove>().enabled = false;
        player.transform.parent.GetComponent<PlayerJump>().enabled = false;
        yield return new WaitForSeconds(timeToWaitForExplosion);
        laboratoryFront.GetComponent<Animator>().SetBool("isExploding", true);
        yield return new WaitForSeconds(timeOfExplosion);
        Destroy(laboratoryFront);
        Destroy(laboratoryBack);
        destroyedLaboratory.SetActive(true);
        OpenIntroDialogBox();
        player.transform.parent.GetComponent<PlayerMove>().enabled = true;
        player.transform.parent.GetComponent<PlayerJump>().enabled = true;
        enabled = false;
    }

    public void OpenIntroDialogBox()
    {
        //TODO
    }
}