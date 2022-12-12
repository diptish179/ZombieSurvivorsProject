using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallSpawner : BaseWeapon
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject energyBall;
    [SerializeField] float ballDelay = 2f;

    AudioSource energyballAttack;

    private void Start()
    {
        energyballAttack = GetComponent<AudioSource>();

        // Start the coroutine here
        StartCoroutine(Attack());
    }

    // Define the coroutine
    IEnumerator Attack()
    {
        while (true)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(ballDelay);

            // Attack with the energy ball
            float angle = Random.Range(0, 360);
            Instantiate(energyBall, transform.position, Quaternion.Euler(0, 0, angle));
            energyballAttack.Play();
        }
    }
}
