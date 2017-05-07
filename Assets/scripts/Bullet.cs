using UnityEngine;

public class Bullet : MonoBehaviour {

    private ParticleSystem ps;
    private TrailRenderer tr;
    private Rigidbody rb;
    private float bulletSpeed = 20f;
    private float lifeTime = 5f;
    private bool isFlying = true;

    private void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        tr = GetComponentInChildren<TrailRenderer>();
        rb = GetComponent<Rigidbody>();
    }

	private void Update()
    {
        if (isFlying)
        {
            transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "playerBullet")
        {
            if (other.gameObject.tag == "playerBullet" || other.gameObject.tag == "Player")
            {
                return;
            }
        }
        
        if (other.gameObject.tag == "enemy")
        {
            other.transform.parent.GetComponent<EnemyHit>().Die();
        }

        FakeDestroy();
    }

    private void FakeDestroy()
    {
        ps.Play();
        tr.transform.parent = null;
        ps.transform.parent = null;
        rb.useGravity = true;
        isFlying = false;
        Destroy(gameObject);

    }

}
