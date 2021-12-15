using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LoseCollider changeScene;

    public Rigidbody rb;
    public BoxCollider[] colliders;

    public float force = 5f;
    public float torque = 20f;
    public float rotationSpeed = 50f;

    public Transform knifeTransform;
    public float timeWhenWeStartedFlying;
    public Vector3 swipeDirection;
  
    Vector3 m_EulerAngleVelocity;

    public bool rotating=true;

    private void Start()
    {
        rb.isKinematic = true;

        m_EulerAngleVelocity = new Vector3(0, 0, -360);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {          
            Swipe();          
        }

        /*if (!rotating && !rb.isKinematic)
        {
            //StartCoroutine(DelayOnRotation());
        }*/
    }

    void FixedUpdate()
    {
        if (rb.isKinematic)
            return;
        StartRotating();
    }

     void StartRotating()
    {
        if (rotating)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

            StartCoroutine(DelayOnRotation());
         
        }     
    }

    IEnumerator DelayOnRotation()
    {
        yield return new WaitForSeconds(0.6f);
        if (transform.rotation.z <= 0.05f && transform.rotation.z >= 0f)
        {
            rotating = false;
        }
    }

    void Swipe()
    {

        rb.isKinematic = false;

        rotating = true;

        Vector3 swipe = swipeDirection;

        timeWhenWeStartedFlying = Time.time;
        
        rb.AddForce(swipe * force, ForceMode.Impulse);

        //AddTorque(0f, 0f, -torque, ForceMode.Impulse);

        if (rb.transform.position.y < 1.5f)
        {
            StartCoroutine(ColliderController());
        }

    }

    IEnumerator ColliderController()
    {
        colliders = GetComponentsInChildren<BoxCollider>();

        int i = 0;
        foreach (BoxCollider col in colliders)
        {                  
            colliders[i].enabled = false;
            i++;
        }


        yield return new WaitForSeconds(1f);

        int y = 0;
        foreach (Collider col in colliders)
        {
            colliders[y].enabled = true;
            y++;
        }
    }

    public void ResetRigidBodyKinematic()
    {
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Platform")
        {
            float timeInAir = Time.time - timeWhenWeStartedFlying;

            if (!rb.isKinematic && timeInAir >= .05f)
            {
                ResetRigidBodyKinematic();
            }
        }

        if (collider.gameObject.tag == "Lose")
        {
            changeScene.RestartLevel();
        }

    }

}
