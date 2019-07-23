using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] GameObject explode;
    [SerializeField] float delay = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explode, transform);
        Destroy(gameObject, delay);
        
    }
}
