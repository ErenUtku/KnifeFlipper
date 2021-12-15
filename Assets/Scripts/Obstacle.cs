using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacleSlicedPrefab;
    public Knife knife;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);       
        GameObject slicedObstacle = Instantiate(obstacleSlicedPrefab, transform.position, Quaternion.identity);
        Destroy(slicedObstacle, 3f);
    }
}
