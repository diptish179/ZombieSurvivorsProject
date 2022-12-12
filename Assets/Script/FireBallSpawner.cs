using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : BaseWeapon
{
    [SerializeField] GameObject fireBall;
    [SerializeField] float ballDelay = 3f;

    AudioSource fireballAttack;

    private void Start()
    {
        fireballAttack = GetComponent<AudioSource>();

        // Start the coroutine to spawn the fireball
        StartCoroutine(SpawnFireball());
    }

    IEnumerator SpawnFireball()
    {
        while (true) // Loop forever
        {
            // Wait for the specified delay before spawning the fireball
            yield return new WaitForSeconds(ballDelay);

            // Generate a random angle
            float angle = Random.Range(0, 360);

            // Spawn the fireball at the spawner's position, with the random rotation
            Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, angle));

            // Set the fireball's rotation to match the random angle
            fireBall.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Play the fireball attack sound
            fireballAttack.Play();
        }
    }
}
