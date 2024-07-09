using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Scripts : MonoBehaviour
{
    [SerializeField] private LayerMask player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.S))
                gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.SetActive(true);
    }

}
