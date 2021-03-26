using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 60.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, animationSpeed * Time.deltaTime);
    }
}
