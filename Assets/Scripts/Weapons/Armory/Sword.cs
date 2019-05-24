using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{

    private void Start()
    {
        damage = 40f;
        fireRate = 0.8f;
        doesPlayerOwnIt = true;
    }
}
