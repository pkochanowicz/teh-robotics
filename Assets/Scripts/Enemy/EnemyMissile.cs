using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour {

    [SerializeField]
    private float _missileDuration = 4f;

    [HideInInspector]
    public float damage;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, _missileDuration);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
            collisionInfo.collider.transform.parent.GetComponent<PhysicalObject>().ReceiveDmg(damage);
        Destroy(gameObject);
    }
}
