using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    Transform target;

    private void Awake()
    {
        target = FindObjectOfType<Player>().transform;    
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
