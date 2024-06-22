using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Platform_Scripts : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderJoint2D;
    private float positionNow;
    private float positionBefor;
    private float first_Position;
    private bool direction = true;

    private void Start()
    {
        positionBefor = transform.position.x;
        sliderJoint2D = GetComponent<SliderJoint2D>();
        first_Position = transform.position.x;
    }
    private void FixedUpdate()
    {
        positionNow = transform.position.x;
        if (positionNow == positionBefor)
        {
            direction = !direction;
            if (direction)
                sliderJoint2D.connectedAnchor = new Vector2(positionNow + 5, transform.position.y);
            else
                sliderJoint2D.connectedAnchor = new Vector2(positionNow - 5, transform.position.y);
            Debug.Log("---------------------------");
        }
        positionBefor = positionNow;
    }
}
