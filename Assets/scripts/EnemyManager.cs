using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private float timeBetweenEnemySpawns;
    [SerializeField]
    private GameObject enemyPrefab;

	private Vector3[] enemySpawnPoints;

    private void Awake()
    {
        enemySpawnPoints = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            enemySpawnPoints[i] = transform.GetChild(i).transform.position;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(timeBetweenEnemySpawns);
        int spawnPointIndex = Random.Range(0, enemySpawnPoints.Length);

        GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPoints[spawnPointIndex], Quaternion.identity);
        newEnemy.transform.parent = transform;
        
        StartCoroutine(SpawnEnemyRoutine());
    }

}
