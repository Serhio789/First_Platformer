using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private SpriteRenderer boss;
    [SerializeField] private Rigidbody2D rb_boss;

    private const float idle_state = 0;
    private const float run_state = 1;
    private const float attack_state = 2;
    private float current_state;
    private float idle_time=3;
    private float run_time=1.5f;
    private float attack_time=3.3f;
    [SerializeField] private float triger_attack;
    [SerializeField] private LayerMask player_Mask;
    [SerializeField] private Transform attackTransform;
    private bool attack;
    private Animator _anim;
    [SerializeField] private float speed;
    private Vector2 moveCheck;
    [SerializeField] private GameObject door;
    private void Awake()
    {
        rb_boss = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        moveCheck = new Vector2(player.transform.position.x - rb_boss.transform.position.x, 0);
        switch (current_state)
        {
            case idle_state:
                idle_time -= Time.deltaTime;
                if (idle_time <= 0)
                {
                    current_state = run_state;
                    idle_time = 3;
                }
                break;
            case run_state:
                run_time -= Time.deltaTime;
                rb_boss.AddForce(moveCheck * speed, ForceMode2D.Impulse);
                Vector2 overlapCirclePosition = attackTransform.position;
                attack = Physics2D.OverlapCircle(overlapCirclePosition, triger_attack, player_Mask);
                if (attack)
                    current_state = attack_state;

                if (run_time <= 0)
                {
                    current_state = idle_state;
                    run_time = 1.5f;
                }
                    break;
            case attack_state:
                attack_time -= Time.deltaTime;
                if (attack_time <= 0)
                {
                    current_state = idle_state;
                    attack_time = 3.3f;
                }
                break;
        }
        Flip_SpriteRenderer(boss);
        _anim.SetFloat("state", current_state);
        if (!gameObject.GetComponent<Health>().Check_Alive())
            door.SetActive(false);
    }
    private void Flip_SpriteRenderer(SpriteRenderer sprait)
    {
        if (rb_boss.transform.position.x > player.transform.position.x)
            sprait.flipX = true;
        else
            sprait.flipX = false;
    }
}
