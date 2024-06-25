using Platformer.Inputs;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float max_Health;
    [SerializeField] private float curent_Halth;
    [SerializeField] private bool is_Player;
    [SerializeField] private Image strip_HP_Player;
    public GameObject particle;
    private bool is_Allive;
    private float time_Destroy = 5;
    private Animator _anim;
    private SpriteRenderer sprite_A;


    private void Awake()
    {
        curent_Halth = max_Health;
        is_Allive = true;
        _anim = GetComponent<Animator>();
        sprite_A = GetComponent<SpriteRenderer>();
    }

    public void Tack_Damage(float damage)
    {
        curent_Halth -= damage;
        Check_Allive();
    }

    private void Check_Allive()
    {
        if (curent_Halth <= 0)
            is_Allive = false;
        else
            is_Allive = true;
    }
    private void FixedUpdate()
    {
        if (!is_Allive)
        {
            _anim.SetBool("is_Death", true);
            particle.SetActive(true);
            if (!is_Player)
            {
                time_Destroy -= Time.deltaTime;
                sprite_A.color = new Color(1, 1, 1, time_Destroy);
                if (time_Destroy <= 0)
                    Destroy(gameObject);
            }
            else
            {
                //Time.timeScale = 0.1f;
                GetComponent<Player_Scripts>().Dead_Player(is_Allive);
            }
        }
        if(is_Player)
            Indicator_Health(curent_Halth);
    }

    private void Indicator_Health(float helth)
    {
        strip_HP_Player.fillAmount = helth / 100;
    }
}
