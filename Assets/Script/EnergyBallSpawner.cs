using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallSpawner : BaseWeapon
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject energyBall;
    [SerializeField] float ballDelay = 3f;

    AudioSource energyballAttack;

    private void Start()
    {
        energyballAttack = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            float angle = Random.Range(0, 360);
            Instantiate(energyBall, transform.position, Quaternion.Euler(0, 0, angle));
            energyballAttack.Play();
        }
    }
}
