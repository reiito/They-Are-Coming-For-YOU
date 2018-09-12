using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool gameOver;

    public GameObject endScreen;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject player;

    public float minSpawnTime = 10f;
    public float minRate = 1;

    float maxSpawnTime;
    float maxRate;

    Swipe swipe;

    int lastSpawn = 999;

    List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        endScreen.SetActive(false);
        maxSpawnTime = minSpawnTime * 2;
        maxRate = minRate * 2;
        swipe = GetComponent<Swipe>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        if (swipe.Tap)
        {
            foreach(GameObject i in enemies)
            {
                if (i.GetComponent<Visibility>().canKill)
                {
                    enemies.Remove(i);
                    Destroy(i);
                }
            }
        }
    }

    public void ShowEndUI()
    {
        endScreen.SetActive(true);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            while (randomIndex == lastSpawn)
            {
                randomIndex = Random.Range(0, spawnPoints.Length);
            }
            lastSpawn = randomIndex;
            Enemy newEnemy = Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity, spawnPoints[randomIndex]).GetComponent<Enemy>();
            newEnemy.gameController = this;
            newEnemy.player = player;
            newEnemy.speed = Random.Range(0.75f, 1f);

            enemies.Add(newEnemy.childMesh);

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            minSpawnTime -= minRate;
            maxSpawnTime -= maxRate;
        }
    }
}
