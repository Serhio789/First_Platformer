using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject restart;

    private void FixedUpdate()
    {
        if (!gameObject.GetComponent<Health>().Check_Alive())
        {
            restart.SetActive(true);
            
        }
    }

}
