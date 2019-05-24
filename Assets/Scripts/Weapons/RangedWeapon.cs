using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{

    public GameObject parent;
    public Transform firePoint;
    public Transform muzzleFlashPrefab;
    public Transform aimingCursor;
    public PhysicalObject physicalObject;
    public float damage = 20f;
    public float fireRate = 2.4f;
    public float _timeToFire = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _timeToFire)
        {
            _timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        if (gameObject.name == "Pistol")
        {
            Vector2 cursorPosition = new Vector2(aimingCursor.position.x, aimingCursor.position.y);
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

            if (parent.transform.localScale.x > 0)
            {
                GameObject missile = Instantiate(PrefabManager.Instance.pistolBullet, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                missile.GetComponent<Rigidbody2D>().velocity = (cursorPosition - firePointPosition).normalized * PistolBullet.bulletSpeed;
            }
            else
            {
                GameObject missile = Instantiate(PrefabManager.Instance.pistolBullet, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                missile.GetComponent<Rigidbody2D>().velocity = (cursorPosition - firePointPosition).normalized * PistolBullet.bulletSpeed;
            }
            physicalObject.animator.SetBool("IsShooting", true);
            StartCoroutine(SetIsShootingAnimatorBoolToFalse());
            audioManager.PlaySound(shootSound);
            Transform muzzleFlashEffect = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
            muzzleFlashEffect.parent = firePoint;
            Destroy(muzzleFlashEffect.gameObject, 0.1f);
        }
    }
    private IEnumerator SetIsShootingAnimatorBoolToFalse()
    {
        yield return new WaitForSeconds(0.4f);
        physicalObject.animator.SetBool("IsShooting", false);
    }
}

//Shoot straight:
//GameObject missile = Instantiate(PrefabManager.Instance.pistolBullet, firePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
//missile.GetComponent<Rigidbody2D>().velocity = new Vector2(PistolBullet.bulletSpeed, 0);

//seekingmistle:
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Weapon : MonoBehaviour {

//    public float fireRate = 0;
//    public float damage = 20;
//    public LayerMask whatToHit;

//    float timeToFire = 0;
//    Transform firePoint;

//    // Use this for initialization
//    void Awake() {
//        firePoint = transform.Find("FirePoint");
//        if (firePoint == null)
//        {
//            Debug.Log("No firePoint defined");
//        }
//    }

//    // Update is called once per frame
//    void Update() {
//        if (fireRate == 0)
//        {
//            if (Input.GetButtonDown("Fire1"))
//            {
//                Shoot();
//            }
//        }
//        else
//        {
//            if (Input.GetButton("Fire1") && Time.time > timeToFire)
//            {
//                timeToFire = Time.time + 1 / fireRate;
//                Shoot();
//            }
//        }
//    }

//    void Shoot()
//    {
//        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
//        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
//        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
//        Debug.DrawLine (firePointPosition, mousePosition-firePointPosition*100, Color.cyan);
//        if (hit.collider != null)
//        {
//            Debug.DrawLine(firePointPosition, hit.point, Color.red);
//            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage.");
//        }                
//    }
//}
