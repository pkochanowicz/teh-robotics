using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay;
    public float shootingSpeed;
    public GameObject item;
    public float itemSpeed;
    public int burstShots;
    public Transform firePoint;
    public Transform cursor;

    //cache
    private PhysicalObject phisicalObject;

    // Start is called before the first frame update
    void Start()
    {
        phisicalObject = GetComponent<PhysicalObject>();

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (phisicalObject.body.active == false)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator Shoot()
    {

        {
            for (int i = 0; i < burstShots; i++)
            {

                phisicalObject.animator.SetBool("IsAttacking", true);
                yield return new WaitForSeconds(shootingSpeed);
                phisicalObject.animator.SetBool("IsAttacking", false);
                GameObject missile = Instantiate(item, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                missile.GetComponent<Rigidbody2D>().velocity = (cursor.position - firePoint.position).normalized * itemSpeed;
                missile.GetComponent<EnemyMissile>().damage = phisicalObject.damageOnContact;
                


            }
            yield return new WaitForSeconds(delay);
            StartCoroutine(Shoot());
        }
    }
}
