using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Scripts : MonoBehaviour
{
    public Animator anim;
    private bool chek = true;
    public GameObject text_E;
    public bool chek_Trigger = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CompareTag("Player"))
            chek_Trigger = true;
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        chek_Trigger = false;
    }
    private void Update()
    {
        Click_E();
    }
    private void Click_E()
    {
        if (chek_Trigger)
        {
            text_E.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                chek = !chek;
                anim.SetBool("is_Door", chek);
            }
        }
        else
            text_E.SetActive(false);
    }
}
