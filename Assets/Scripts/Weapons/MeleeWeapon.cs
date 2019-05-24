using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeleeWeapon : Weapon {

    [HideInInspector]
    public float damage;
    [HideInInspector]
    public float fireRate;


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && WeaponSwitching.isAttacking == false)
            StartAttack();
    }

    void StartAttack()
    {
            WeaponSwitching.isAttacking = true;
            GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(FinishAttack());
    }

    private IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(fireRate / 2);
        yield return new WaitForSeconds(fireRate / 2);
        GetComponent<BoxCollider2D>().enabled = false;
        WeaponSwitching.isAttacking = false;
    }

    private void OnDisable()
    {
        WeaponSwitching.isAttacking = false;
    }
}
