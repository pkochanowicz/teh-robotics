using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    public float playerInvincibilityDuration = 2f;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Collider2D collidingObject = collisionInfo.collider;
        Collider2D player = collisionInfo.otherCollider;
        Transform targetBody = collidingObject.transform;
        Transform playerBody = player.transform;

        if (collidingObject.tag == "Ground")
            return;
        if (targetBody.parent)
        {
            PhysicalObject collidingPhisicalObject = targetBody.parent.GetComponent<PhysicalObject>();
            if (player.tag == "MeleeWeapon")
            {
                collidingPhisicalObject.ReceiveDmg(player.GetComponent<MeleeWeapon>().damage);
                return;
            }
            PhysicalObject playerPhysicalObject = playerBody.parent.GetComponent<PhysicalObject>();
            bool isinvincible = playerBody.parent.GetComponent<PhysicalObject>().isInvincible;

            if (collidingPhisicalObject != null)
            {
                if (player.tag != "MeleeWeapon" && !isinvincible)
                {
                    playerPhysicalObject.ReceiveDmg(collidingPhisicalObject.damageOnContact);
                    collidingObject.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                }
            }
        }
        else
        {
            return;
        }
    }
}
