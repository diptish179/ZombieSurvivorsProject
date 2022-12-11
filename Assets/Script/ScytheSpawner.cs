using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : BaseWeapon
{
    [SerializeField] GameObject scythe;
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
            katanaAttack.Play();
        }
    }
}
