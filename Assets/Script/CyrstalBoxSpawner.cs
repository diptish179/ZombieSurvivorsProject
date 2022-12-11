using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyrstalBoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject crystalboxPrefab;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CyrstalBoxSpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CyrstalBoxSpawnCoroutine()
    {
        while (player != null)
        {
            yield return new WaitForSeconds(10f);

            Instantiate(crystalboxPrefab, player.transform.position + new Vector3(2, 2), Quaternion.identity);
        }

    }
}
