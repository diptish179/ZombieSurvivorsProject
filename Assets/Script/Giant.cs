using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Giant : Enemy 
{ 
    enum GiantState 
    { Idling, Chasing, Attacking, Beserk } 
    GiantState currentState = GiantState.Idling;
    Animator animator;
    float waitTime = 2f;
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float knifeSpeed = 10f;


    protected override void Start() 
    {
        base.Start(); 
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    { 
        

        switch (currentState)
        {
            case GiantState.Idling:
                waitTime -= Time.deltaTime; 
                if (waitTime <= 0) 
                { 
                    currentState = GiantState.Chasing; 
                }
                break; 

            case GiantState.Chasing: 
                if (Vector3.Distance(transform.position, player.transform.position) > 5f) 
                { 
                    animator.SetBool("IsWalking", true);
                    base.Update();
                } 
                else 
                { 
                    animator.SetBool("IsWalking", false);
                    currentState = GiantState.Attacking;
                }
                break; 

            case GiantState.Attacking: 
                animator.SetTrigger("Attack"); 
                waitTime = 5f;
                //SpawnKnife();
                
                currentState = GiantState.Idling;
                break;

            //case GiantState.Beserk:
            //    animator.SetTrigger("Attack");
            //    waitTime = 5f;
            //    waitTime -= Time.deltaTime;
            //    if(waitTime <=0)
            //    {
            //        animator.SetTrigger("Attack");
            //    }
            //    break;
        } 
    }

    //public void SpawnKnife()
    //{
    //    float angle = 0;
    //    float x = player.transform.position.x - transform.position.x;
    //    float y = player.transform.position.y - transform.position.y;
    //    angle = y / x;
    //    angle *= Mathf.Rad2Deg;


    //    Vector3 destination = player.transform.position;
    //    Vector3 source = transform.position;
    //    Vector3 knifDir = (destination - source).normalized;

    //    GameObject knife = Instantiate(knifePrefab, source, Quaternion.Euler(0, 0, angle));

    //    //Transform knifeTransform = (Transform) knife.gameObject.GetComponent("Transform");

    //    //knifeTransform.forward = knifDir;

    //}
        
    public void SpawnKnife()
    {
        float angle = 0;
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        angle = y / x;
        angle *= Mathf.Rad2Deg;

        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;
        Vector3 knifDir = (destination - source).normalized;

        GameObject knife = Instantiate(knifePrefab, source, Quaternion.Euler(0, 0, angle));

        // Add a Rigidbody component to the knife prefab.
        Rigidbody rb = knife.gameObject.AddComponent<Rigidbody>();

        // Apply a force to the Rigidbody to make the knife move towards the player.
        rb.AddForce(knifDir * knifeSpeed, ForceMode.Impulse);

    }

}