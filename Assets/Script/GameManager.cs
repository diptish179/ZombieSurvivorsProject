using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] int hordeoffset = 10;
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
            // Check which level is currently loaded
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                // Start spawning enemies using the SpawnEnemy1Coroutine if Level 1 is loaded
                StartCoroutine(SpawnEnemy1Coroutine());
            }
            else if (SceneManager.GetActiveScene().name == "Level 2")
            {
                // Start spawning enemies using the SpawnEnemy2Coroutine if Level 2 is loaded
                StartCoroutine(SpawnEnemy2Coroutine());
            }

            // Start spawning healing items
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

   

    private IEnumerator SpawnEnemy1Coroutine()
    {
        SpawnEnemies(zombie, 5, false);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(merman, 5, true);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(zombie, 5, false);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(zombie, 5);
      
        yield return new WaitForSeconds(5f);
        SpawnEnemies(merman, 2);
        SpawnEnemies(zombie, 2);
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
        //SpawnEnemies(vampire, 5);
        SpawnEnemies(giant, 5);
        yield return new WaitForSeconds(15f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 20);
        
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 10);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 10);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 10);
        SpawnEnemies(giant, 3);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(zombie, 15);
        SpawnEnemies(merman, 10);
        
        yield return new WaitForSeconds(15f);
        SpawnEnemies(merman, 15);
        SpawnEnemies(zombie, 20);
        
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
           
            yield return new WaitForSeconds(15f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            
            yield return new WaitForSeconds(20f);
            SpawnEnemies(bossKnight, 1);
        }

    }

    private IEnumerator SpawnEnemy2Coroutine()
    {
        SpawnEnemies(zombie, 4);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(zombie, 4);
        SpawnEnemies(vampire, 4);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(vampire, 2, false);
        yield return new WaitForSeconds(2f);
        SpawnEnemies(zombie, 10, false);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(vampire, 5);
       
        yield return new WaitForSeconds(5f);
        //SpawnEnemies(merman, 5);
        SpawnEnemies(zombie, 5);

        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 5);
        SpawnEnemies(giant, 5);
        SpawnEnemies(zombie, 5);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(merman, 5);
        SpawnEnemies(zombie, 5);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(zombie, 15);
        
        SpawnEnemies(vampire, 5);
        SpawnEnemies(giant, 5);
        yield return new WaitForSeconds(15f);
        
        SpawnEnemies(zombie, 20);
        SpawnEnemies(vampire, 10);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(zombie, 10);
        SpawnEnemies(vampire, 15);
        SpawnEnemies(zombie, 10);
        yield return new WaitForSeconds(10f);
        SpawnEnemies(vampire, 15);
        SpawnEnemies(zombie, 10);
       
        yield return new WaitForSeconds(10f);
        SpawnEnemies(zombie, 15);
        SpawnEnemies(vampire, 10);
      
        SpawnEnemies(giant, 5);
        yield return new WaitForSeconds(15f);
        
        SpawnEnemies(zombie, 20);
        SpawnEnemies(vampire, 10);
        SpawnEnemies(giant, 5);
        yield return new WaitForSeconds(20f);
        SpawnEnemies(bossKnight, 1);
        while (true)
        {
            //SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 15, false);
            yield return new WaitForSeconds(5f);
            //SpawnEnemies(merman, 15);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(10f);
            //SpawnEnemies(merman, 5);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(10f);
            SpawnEnemies(zombie, 15);
            //SpawnEnemies(merman, 10);
            SpawnEnemies(vampire, 5);
            yield return new WaitForSeconds(15f);
           // SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(vampire, 20);
            yield return new WaitForSeconds(20f);
            SpawnEnemies(bossKnight, 1);
        }
    }

    //The enemies will follow the player when isTracking is true, and they will move to the right when isTracking is false.

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition;

            // If isTracking is true, set the spawn position to be near the player
            if (isTracking)
            {
                spawnPosition = Random.insideUnitCircle.normalized * waveoffset;
                spawnPosition += player.transform.position;
            }
            // If isTracking is false, set the spawn position to be to the right of the player
            else
            {
                spawnPosition = player.transform.position + Vector3.right * (-hordeoffset);
            }

            // Instantiate the enemy at the calculated position
            GameObject enemyobject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // If isTracking is false, set the enemy's isTrackingPlayer property to false
            if (!isTracking)
            {
                Enemy enemy = enemyobject.GetComponent<Enemy>();
                enemy.isTrackingPlayer = false;
            }
        }
    }






}
