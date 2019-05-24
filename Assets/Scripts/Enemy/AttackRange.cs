using UnityEngine;

public class AttackRange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transform.parent.parent.GetComponent<AttackWhenPlayerInRange>().CollisionDetected();
        }
    }
}