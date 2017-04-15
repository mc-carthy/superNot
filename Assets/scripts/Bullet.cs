using UnityEngine;

public class Bullet : MonoBehaviour {

    // private Rigidbody rb;
    private float bulletSpeed = 20f;
    private float lifeTime = 5f;

    private void Awake()
    {
        // rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

	private void Update()
    {
        // rb.MovePosition(rb.position + rb.transform.forward * bulletSpeed * Time.deltaTime);
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.transform.parent.GetComponent<EnemyHit>().Die();
        }
    }

}
