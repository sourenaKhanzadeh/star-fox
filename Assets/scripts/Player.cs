using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("SpaceShip Control")]
    [SerializeField] float xThrow = 10f;
    [SerializeField] float yThrow = 10f;
    [SerializeField] float pullRot = 10f;
    [SerializeField] float speedMultiplier = 4f;
    [SerializeField] float speed = 10f;


    // Start is called before the first frame update
    float horizon = 0f;
    float vertics = 0f;
   

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
        Boost();
    }

    void Movement() {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        
        horizon += horizontalThrow * xThrow * Time.deltaTime;

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        vertics += verticalThrow * Time.deltaTime * yThrow;

        float pull = -horizontalThrow * pullRot;

        transform.localRotation = Quaternion.Euler(vertics, horizon, 0f);

        GetComponentInChildren<Transform>().transform.localRotation = Quaternion.Euler(vertics, horizon, pull);
    }

    void Fire()
    {
        ParticleSystem pS = GetComponentInChildren<ParticleSystem>();
        if (CrossPlatformInputManager.GetButton("Fire1"))
            pS.Play();
    }

    void Boost() {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.forward * speedMultiplier * speed;

        }
        else {
            transform.position += transform.forward * speed;
        }
    }
    

}
