using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeWhenPlayerNear : MonoBehaviour
{
    public float aggroRange;
    public float attackingTime;
    public float runningSpeed;
    public float pauseBetweenAttacks;
    public Transform rightPatrolPoint;
    public Transform leftPatrolPoint;

    private Rigidbody2D rigidbody;
    private PhysicalObject physicalObject;
    private Transform transform;
    private GameObject [] players;
    private GameObject targetedPlayer;
    private float [] rangeToPlayers;
    private float rangeToClosestPlayer;
    private bool isAttacking = false;
    private bool hasJustAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        physicalObject = GetComponent<PhysicalObject>();
        transform = physicalObject.body.transform;
        rigidbody = physicalObject.body.GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

        players = GameObject.FindGameObjectsWithTag("Player");
        rangeToPlayers = new float[players.Length];
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestPlayer();
        if (Mathf.Abs(rangeToClosestPlayer) <= aggroRange && !isAttacking && !hasJustAttacked)
        {
            StartCoroutine(StartAttacking());
        }
        if (isAttacking)
        {
            MoveObject();
        }
    }
    private void FindClosestPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        {
            rangeToPlayers[i] = transform.position.x - players[i].transform.position.x;
            if (i == 0)
            {
                rangeToClosestPlayer = rangeToPlayers[i];
                targetedPlayer = players[i];
            }
            else
            {
                if (Mathf.Abs(rangeToPlayers[i]) < Mathf.Abs(rangeToPlayers[i - 1]))
                {
                    rangeToClosestPlayer = rangeToPlayers[i];
                    targetedPlayer = players[i];
                }
            }
        }
    }

    private void MoveObject()
    {
        if (rangeToClosestPlayer <= 0 && !(Vector3.Distance(transform.position, rightPatrolPoint.transform.position) < 1f))
        {
            transform.Translate(Vector2.right * runningSpeed * Time.deltaTime);
        }
        if (rangeToClosestPlayer > 0 && !(Vector3.Distance(transform.position, leftPatrolPoint.transform.position) < 1f))
        {
            transform.Translate(Vector2.left * runningSpeed * Time.deltaTime);
        }
        if (physicalObject.animator)
            physicalObject.animator.SetFloat("Speed", runningSpeed);
    }

    private IEnumerator StartAttacking()
    {
        // play attacking sound and animation
        isAttacking = true;
        yield return new WaitForSeconds(attackingTime);
        isAttacking = false;
        if (physicalObject.animator)
            physicalObject.animator.SetFloat("Speed", 0);
        hasJustAttacked = true;
        StartCoroutine(WaitIfJustAttacked());
    }

    private IEnumerator WaitIfJustAttacked()
    {
        yield return new WaitForSeconds(pauseBetweenAttacks);
        hasJustAttacked = false;
    }

}
