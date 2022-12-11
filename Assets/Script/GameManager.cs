using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerTxt;
    [SerializeField] GameObject merman;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject vampire;
    [SerializeField] GameObject bossKnight;
    [SerializeField] GameObject giant;
    [SerializeField] GameObject player;
    [SerializeField] GameObject healItem0;
    [SerializeField] GameObject healItem1;
    [SerializeField] int waveoffset =15;
    //[SerializeField] int hordeoffset = 10;
    [SerializeField] int healItemoffset = 10;


    float totalTime = 0f;

    
    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timerTxt.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
        StartCoroutine(SpawnHealItemCoroutine());
        
    }

     public void Update()
    {
        totalTime += Time.deltaTime;
        UpdateLevelTimer(totalTime);
        
    }

    private IEnumerator SpawnHealItemCoroutine()
    {
        while (true)
        {
            SpawnHealItem();
            yield return new WaitForSeconds(20f);
        }


    }

    void SpawnHealItem()
    {
        Vector3 healItemSpawnPosition = Random.insideUnitCircle.normalized * healItemoffset;

        healItemSpawnPosition += player.transform.position;

        int randomHealitem = Random.Range(0, 2);
        
        if (randomHealitem == 0)
        {
            Instantiate(healItem0, healItemSpawnPosition, Quaternion.identity);
        }
        else if (randomHealitem == 1)
            Instantiate(healItem1, healItemSpawnPosition, Quaternion.identity);
    }

   

    private IEnumerator SpawnEnemyCoroutine()
    {
        SpawnEnemies(giant, 5, false);
        yield return new WaitForSeconds(200f);
        SpawnEnemies(merman, 5, false);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(vampire, 5, false);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(zombie, 5);
      
        yield return new WaitForSeconds(5f);
        SpawnEnemies(merman, 2);
        SpawnEnemies(vampire, 2);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(merman, 5);
        SpawnEnemies(zombie, 5);
        
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 5);
        SpawnEnemies(merman, 5);
        SpawnEnemies(zombie, 5);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(merman, 5);
        SpawnEnemies(zombie, 5);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(zombie, 15);
        SpawnEnemies(merman, 10);
        SpawnEnemies(vampire, 5);
        yield return new WaitForSeconds(15f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 20);
        SpawnEnemies(vampire, 10);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 10);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 10);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 10);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(zombie, 15);
        SpawnEnemies(merman, 10);
        SpawnEnemies(vampire, 5);
        yield return new WaitForSeconds(15f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 20);
        SpawnEnemies(vampire, 10);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(bossKnight, 1);
        while (true)
        {
            SpawnEnemies(merman,10);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 15, false);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 15);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(merman, 5);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 15);
            SpawnEnemies(merman, 10);
            SpawnEnemies(vampire, 5);
            yield return new WaitForSeconds(15f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(vampire, 20);
            yield return new WaitForSeconds(20f);
            SpawnEnemies(bossKnight, 1);
        }
        

    }

        void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking=true)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * waveoffset;
           
            spawnPosition += player.transform.position;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //if (!isTracking)
            //{
            //    spawnPosition = player.transform.position + Vector3.right * (-hordeoffset);
            //    GameObject enemyobject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            //    Enemy enemy = enemyobject.GetComponent<Enemy>();
            //    enemy.isTrackingPlayer = false;
            //}


        
            //if (!isTracking)
            //{
            //    enemy.isTrackingPlayer = false;
            //}

        }
        //isTracking = true;
    }
}
