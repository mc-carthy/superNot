using UnityEngine;
using System.Collections;

public class EnemyAim : MonoBehaviour {

    [SerializeField]
    private Transform enemyHead;
    [SerializeField]
    private Transform enemyBody;
    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;

    private Transform playerHead;
    private float shotDelay = 1f;
    private bool isFiring;

    private void Awake()
    {
        playerHead = FindObjectOfType<PlayerMovement>().Head;
    }

    private void Update()
    {
        AimAtPlayerHead();
    }

    private void AimAtPlayerHead()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemyHead.transform.position, playerHead.transform.position - enemyHead.transform.position, out hit))
        {
            // Move body to face player
            Vector3 vectorToPlayer = playerHead.transform.position - enemyHead.transform.position;
            float angleToPlayer = Mathf.Atan2(vectorToPlayer.x, vectorToPlayer.z) * Mathf.Rad2Deg;
            enemyBody.transform.rotation = Quaternion.Euler(0, angleToPlayer, 0);

            // Move weapon to aim at head
            weapon.LookAt(hit.point);

            if (!isFiring)
            {
                isFiring = true;
                StartCoroutine("FireRoutine");
            }
        }
        else
        {
            isFiring = false;
            StopCoroutine("FireRoutine");
        }
    }

    private IEnumerator FireRoutine()
    {
        while(true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            yield return new WaitForSeconds(shotDelay);
        }
    }

}
