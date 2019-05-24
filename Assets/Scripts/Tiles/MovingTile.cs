using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//required PhisicaObject
//[RequireComponent(PhisicalObject)]
public class MovingTile : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] patrolPoints;

    private bool movingRight = true;
    private int currentPatrolPointIndex;

    //cache of parent components
    private Transform transform;


    // Use this for initialization
    void Start()
    {
        currentPatrolPointIndex = 0;

        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(transform);

        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].transform.position) < 1f)
        {
            movingRight = !movingRight;
            currentPatrolPointIndex++;
            if (currentPatrolPointIndex >= patrolPoints.Length)
            {
                currentPatrolPointIndex = 0;
            }
        }
    }

    void MoveObject(Transform ObjectToMove)
    {
        if (movingRight == true)
        {
            ObjectToMove.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            ObjectToMove.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.transform != null)
        {
            MoveObject(collisionInfo.collider.transform);
        }
    }
}