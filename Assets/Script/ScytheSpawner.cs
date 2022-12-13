using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : BaseWeapon
{
    [SerializeField] GameObject scythe;
    [SerializeField] SimpleObjectPool pool;
    [SerializeField] float scytheDelay = 3f;
    AudioSource katanaAttack;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());
        katanaAttack = GetComponent<AudioSource>();
    }

    IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(scytheDelay);
            float angle = Random.Range(0, 360);
            Instantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle));
            //var scythe = pool.Get();
            //scythe.transform.position = transform.position;
            //scythe.transform.rotation = Quaternion.Euler(0, 0, angle);
            //scythe.SetActive(true);
            katanaAttack.Play();
        }
    }
}
