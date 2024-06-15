using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scripts : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        Vector3 vector3 = new Vector3(0f, 0f, -10f);
        transform.position = Player.transform.position + vector3;
    }
}
