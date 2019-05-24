using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReference : MonoBehaviour
{
    public GameObject weaponColliderObject;

    public Collider weaponCollider
    {
        get
        {
            if (weaponColliderObject == null)
                //error
                return null;

            Collider collider = weaponColliderObject.GetComponent<Collider>();

            //if (collider == null)  
                //inny error
            

            return collider;
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
