using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProvider : MonoBehaviour
{
    internal bool movable;

    [SerializeField]
    internal int posNum;

    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(touchPosition, new Vector3(0,-50,0), out hit))
                {
                    BoxCollider touchedCollider = hit.transform.GetComponent<BoxCollider>();

                    if (boxCollider == touchedCollider)
                    {
                        movable = true;
                    }
                }
            }

            if(touch.phase == TouchPhase.Moved)
            {
                if (movable)
                {
                    transform.position = new Vector3(touchPosition.x, transform.position.y, touchPosition.z);
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                movable = false;
            }
        }
    }
}
