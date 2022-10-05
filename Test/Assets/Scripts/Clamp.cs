using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    public GameObject actualObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pion"))
        {
            MoveProvider moveProvider = other.GetComponent<MoveProvider>();
            moveProvider.movable = false;

            other.transform.position = transform.position;

            actualObject = other.gameObject;
        }
    }
}
