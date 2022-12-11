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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = Random.Range(0, 360);
            Instantiate(fireBall, transform.position, Quaternion.Euler(0,0,angle));
            fireBall.transform.rotation = Quaternion.Euler(0, 0, angle);
            fireballAttack.Play();
        }
    }
}
