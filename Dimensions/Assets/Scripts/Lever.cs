using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    private GameObject leverClosed;
    [SerializeField]
    private GameObject leverPulled;
    [SerializeField]
    private GameObject closedState;
    [SerializeField]
    private GameObject openState;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        leverClosed.SetActive(false);
        closedState.SetActive(false);
        leverPulled.SetActive(true);        
        openState.SetActive(true);
    }

}
