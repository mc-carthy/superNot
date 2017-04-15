using UnityEngine;

public class EnemyHit : MonoBehaviour {

	[SerializeField]
    private GameObject enemyHead;
    [SerializeField]
    private GameObject enemyBody;
    [SerializeField]
    private GameObject enemyCorpse;

    public void Die()
    {
        GameObject newCorpse = Instantiate(enemyCorpse, transform.position, transform.rotation);
        Destroy(newCorpse, 10f);
        Destroy(gameObject);
    }

}
