using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public float camSpeed = 5f;
    

    private void Update()
    {
        if (target != null)
        {
            var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, camSpeed * Time.unscaledDeltaTime);

        }
    }


}

