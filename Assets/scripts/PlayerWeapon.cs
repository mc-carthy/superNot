using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	[SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private Transform weapon;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit))
        {
            weapon.LookAt(hit.point);
        }
    }

    public void Fire ()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

}
