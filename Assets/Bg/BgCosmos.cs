using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCosmos : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform cosmosTransform;

    private void Start()
    {
        cosmosTransform = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        cosmosTransform.Rotate(speed, 0, 0);
    }
}
