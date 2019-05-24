using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWhenPlayerInRange : MonoBehaviour
{
    public Transform attackRange;
    public float pauseBetweenAttacks = 3f;

    private PhysicalObject physicalObject;
    private Rigidbody2D rigidbody;

    private GameObject[] players;
    private bool hasJustAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        physicalObject = GetComponent<PhysicalObject>();
        rigidbody = physicalObject.body.GetComponent<Rigidbody2D>();

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void CollisionDetected()
    {
        StartCoroutine(SetAttackingAnimation());
    }

    public IEnumerator SetAttackingAnimation()
    {
        if (physicalObject.GetAnimationClip("Attack") != null)
        {
            if (physicalObject.animator.GetBool("IsAttacking") != true)
            {
                physicalObject.animator.SetBool("IsAttacking", true);
                yield return new WaitForSeconds(pauseBetweenAttacks);
                physicalObject.animator.SetBool("IsAttacking", false);
            }
        }
    }
}
