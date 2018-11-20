using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	[SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private Transform weapon;

    private int layerMask = 1 << 10;

    private void Start() {
        layerMask = ~layerMask;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            weapon.LookAt(hit.point);
        }
    }

    public void Fire ()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.tag = "playerBullet";
    }

}
