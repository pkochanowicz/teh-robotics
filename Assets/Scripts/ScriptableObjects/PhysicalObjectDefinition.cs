using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPhysicalObject", menuName = "Physical Object")]
public class PhysicalObjectDefinition : ScriptableObject
{
    public float damageOnContact;
    public float maxHealth;

    public float pointsReward;

    public Animator animator;
    public Sprite sprite;
}
