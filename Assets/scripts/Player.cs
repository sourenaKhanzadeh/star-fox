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
    


    // Start is called before the first frame update
    float horizon = 0f;
    float vertics = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    void Movement() {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        horizon += horizontalThrow * xThrow * Time.deltaTime;

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        vertics += verticalThrow * Time.deltaTime * yThrow;

        transform.position += transform.forward;

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


    

}
