using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawa : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool tich_lawa = false;
    [SerializeField] private Collider2D player;
    private float timer_damage = 1;

    private void Awake()
    {
        player = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lawa"))
            tich_lawa = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tich_lawa = false;
    }

    private void FixedUpdate()
    {
        if (tich_lawa)
        {
            timer_damage -= Time.deltaTime;
            if (timer_damage <= 0)
            {
                player.gameObject.GetComponent<Health>().Tack_Damage(damage);
                timer_damage = 1;
            }
        }
    }
}
