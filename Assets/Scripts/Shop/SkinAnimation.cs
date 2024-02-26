using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 finalPosition;
    [SerializeField] private Transform finalTransform;
    private Vector2 intialPosition;

    private void Awake()
    {
        intialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalTransform.position, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = intialPosition;
    }
}
