using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> enemyPool;
    [SerializeField] private List<GameObject> laserPool;
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        print("Puntos: " + score);
    }

    public GameObject GetEnemy(GameObject prefab)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        GameObject newEnemy = Instantiate(prefab);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    public void RemoveEnemy(GameObject enemyToRemove)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if(enemy == enemyToRemove)
            {
                enemy.SetActive(false);
                return;
            }
        }
        enemyPool.Add(enemyToRemove);
        enemyToRemove.SetActive(false);
    }

    public void LaserToPool(GameObject laser)
    {
        laser.SetActive(false);
        laserPool.Add(laser);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
