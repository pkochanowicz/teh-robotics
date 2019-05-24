using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVariableEnabler : MonoBehaviour
{
    public GameObject GameObject;
    public BoolVariable switchVariable;

    // Start is called before the first frame update
    private void Start()
    {
        if (GameObject == null)
        {
            GameObject = gameObject;
        }
        switchVariable.value = false;

    }
    // Update is called once per frame
    void Update()
    {
        GameObject.SetActive(switchVariable.value);
    }
}
