using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{

    public static float bulletSpeed = 60f;
    public static float _bulletDuration = 0.3f;

    private RangedWeapon _shootingWeapon;
    private float damage;

    // Use this for initialization
    void Start()
    {
        _shootingWeapon = GameObject.FindGameObjectWithTag("RangedWeapon").GetComponent<RangedWeapon>();
        damage = _shootingWeapon.damage;
        Destroy(gameObject, _bulletDuration);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);

        Collider2D collider = collisionInfo.collider;
        Transform targetBody = collider.transform;

        if (targetBody.parent)
        {
            PhysicalObject targetPhisicalObject = targetBody.parent.GetComponent<PhysicalObject>();
            if (targetPhisicalObject != null)
            {
                targetPhisicalObject.ReceiveDmg(damage);
            }
        }
        else
        {
            return;
        }
    }
}
