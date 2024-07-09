using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject partical_Coint;
    private Animator _anim;
    private float time_Destroy = 3;
    private bool _isDestroyed = false;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        partical_Coint.SetActive(true);
        _anim.SetBool("Tach_Player", true);
        _isDestroyed = true;
    }
    private void FixedUpdate()
    {
        if (_isDestroyed)
        {
            time_Destroy -= Time.deltaTime;
            if (time_Destroy < 0)
                Destroy(gameObject);
        }
    }
}