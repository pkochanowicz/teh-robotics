using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;

    public bool isDialogueActive;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        { 
            dialogueBox.SetActive(false);
            isDialogueActive = false;
        }
    }
    public void ShowBox(string dialogue)
    {
        dialogueBox.SetActive(true);
        isDialogueActive = true;
        dialogueText.text = dialogue;
    }
}
