using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    //cache
    public Transform target;

    private float range;
    private bool _isLookingRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        range = transform.position.x - target.position.x;
        if ((range > 0f && _isLookingRight) || (range < 0f && !_isLookingRight))
        {
            _isLookingRight = !_isLookingRight;
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y);
        }
    }
}
