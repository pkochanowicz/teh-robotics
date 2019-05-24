using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required PhisicaObject
//[RequireComponent(PhisicalObject)]
public class Patrol : MonoBehaviour {
    public float speed = 3f;
    public Transform[] patrolPoints;
    
    private bool movingRight = true;
    private int currentPatrolPointIndex;

    //cache of parent components
    private PhysicalObject physicalObject;
    private Transform transform;


    // Use this for initialization
    void Start () {
        currentPatrolPointIndex = 0;
        
        physicalObject = GetComponent<PhysicalObject>();
        transform = physicalObject.body.transform;

        if (physicalObject == null)
        {
            Debug.Log("Patrolling object has no physical object!");
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].transform.position) < 1f)
        {
            StartMoving(movingRight);
            currentPatrolPointIndex++;
            if (currentPatrolPointIndex >= patrolPoints.Length)
            {
                currentPatrolPointIndex = 0;
            }
        }
    }

    void StartMoving(bool _movingRight)
    {
        if (_movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }

        if (physicalObject.animator)
            physicalObject.animator.SetFloat("Speed", speed);
    }
}
