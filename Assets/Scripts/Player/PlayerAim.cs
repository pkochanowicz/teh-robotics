using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private float aimingSpeed = 6f;

    //cache
    [SerializeField]
    private Transform playerHand;
    private PlayerMove playerMove;


    //player current state
    private float aimingAngle = 0f;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Aim();
    }
    void Aim()
    {
        float verticalInput = 0f;

        verticalInput = Input.GetAxisRaw("Vertical");
        if ((verticalInput > 0 || verticalInput < 0) && WeaponSwitching.selectedWeapon != 0)
        {
            if (verticalInput > 0)
                aimingAngle += aimingSpeed;
            else if (verticalInput < 0)
                aimingAngle -= aimingSpeed;
            if (aimingAngle >= 90)
                aimingAngle = 90;
            else if (aimingAngle <= -45)
                aimingAngle = -45;
            if (playerMove.IsLookingRight == true)
                playerHand.eulerAngles = new Vector3(playerHand.rotation.x, playerHand.rotation.y, aimingAngle);
            else
                playerHand.eulerAngles = new Vector3(playerHand.rotation.x, playerHand.rotation.y, -aimingAngle);
        }
    }
}
