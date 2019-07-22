using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
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
        movement();
    }

    void movement() {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        horizon += horizontalThrow * xThrow * Time.deltaTime;

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        vertics += verticalThrow * Time.deltaTime * yThrow;

        transform.position += transform.forward;

        float pull = -horizontalThrow * pullRot;

        transform.localRotation = Quaternion.Euler(vertics, horizon, pull);
    }
}
