using UnityEngine;

public class EnemyHit : MonoBehaviour {

	[SerializeField]
    private GameObject enemyHead;
    [SerializeField]
    private GameObject enemyBody;
    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private GameObject enemyCorpse;

    private Transform playerHead;

    private void Awake()
    {
        playerHead = FindObjectOfType<PlayerMovement>().Head;
    }

    private void Update()
    {
        AimAtPlayerHead();
    }

    public void Die()
    {
        GameObject newCorpse = Instantiate(enemyCorpse, transform.position, transform.rotation);
        Destroy(newCorpse, 10f);
        Destroy(gameObject);
    }

    private void AimAtPlayerHead()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemyHead.transform.position, playerHead.transform.position - enemyHead.transform.position, out hit))
        {
            weapon.LookAt(hit.point);
        }
    }

}
