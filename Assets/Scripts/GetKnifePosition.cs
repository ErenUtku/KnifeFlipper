using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKnifePosition : MonoBehaviour
{
    public Transform target;
    
    void Update()
    {
        Vector3 newCamPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        gameObject.transform.position = newCamPosition;
    }
}
