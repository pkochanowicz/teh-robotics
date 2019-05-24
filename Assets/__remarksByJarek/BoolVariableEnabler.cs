using UnityEngine;

public class BoolVariableEnabler : MonoBehaviour
{
    public GameObject GameObject;
    public BoolVariable switchVariable;

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
