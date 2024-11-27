using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject zigzagEnemyPrefab;

    [Header("Spawning Config")]
    [SerializeField] Vector2 leftLimit;
    [SerializeField] Vector2 rightLimit;

    private void Start()
    {
        InvokeRepeating("Spawn", 3, 3);
    }

    private void Spawn()
    {
        GameObject enemyToSpawn = Random.value < 0.5f ? enemyPrefab : zigzagEnemyPrefab;

        // Instantiate(enemyPrefab, new Vector2(Random.Range(leftLimit.x, rightLimit.x), leftLimit.y), Quaternion.identity);
        GameObject enemy = GameManager.Instance.GetEnemy(enemyToSpawn);
        enemy.transform.position = new Vector2(Random.Range(leftLimit.x, rightLimit.x), leftLimit.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(leftLimit, rightLimit);
    }
}
