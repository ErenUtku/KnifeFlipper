using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPole : MonoBehaviour
{
    public int scoreMultipler;
    public Rigidbody knifeRigidBody;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game is Finished");
        Debug.Log(scoreMultipler);
        knifeRigidBody.isKinematic = true;
    }
}
