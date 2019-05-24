using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public static int selectedWeapon = 0;
    public static bool isAttacking;

	// Use this for initialization
	void Start () {
        isAttacking = false;
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        int previousSelectedWeapon = selectedWeapon;
        if (isAttacking == false) { 
		    //if (Input.GetAxis("Mouse ScrollWheel") > 0f)
      //      {
      //          if (selectedWeapon >= transform.childCount - 1)
      //              selectedWeapon = 0;
      //          selectedWeapon++;
      //      }
      //      if (Input.GetAxis("Mouse ScrollWheel") < 0f)
      //      {
      //          if (selectedWeapon <= 0)
      //              selectedWeapon = transform.childCount - 1;
      //          selectedWeapon--;
      //      }
            if (Input.GetKeyDown(KeyCode.Alpha1))
                selectedWeapon = 0;
            if (previousSelectedWeapon != selectedWeapon)
                SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                weapon.GetComponent<Weapon>().PlayUnsheatheSoundSound();
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
