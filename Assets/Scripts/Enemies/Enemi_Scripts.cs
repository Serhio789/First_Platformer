using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class Enemi_Scripts : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float attack_Power;
    [SerializeField] private GameObject radius_Attack;
    [SerializeField] private LayerMask player_Mask;
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attack_Trigger_Radius;
    [SerializeField] private Transform point_Attack;
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer Worm;
    private bool attack = false;
    private Animator _anim;
    private float time_Attack = 2.08f;
    private Vector2 new_Point_Attack;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        Worm = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 overlapCirclePosition = attackTransform.position;
        attack = Physics2D.OverlapCircle(overlapCirclePosition, attack_Trigger_Radius, player_Mask);

        // Реализация атаки на персонажа

        if (attack)
            Attack();
        else
            _anim.SetBool("Attack", false);
    }

    private void Attack()
    {
        _anim.SetBool("Attack", true);
        time_Attack -= Time.deltaTime;
        if (time_Attack < 0 && gameObject.GetComponent<Health>().Check_Alive())
        {
            Flip_SpriteRenderer(Worm);
            GameObject currentBullet = Instantiate(bullet, new_Point_Attack, Quaternion.identity);
            Rigidbody2D currentBulletVelosyty = currentBullet.GetComponent<Rigidbody2D>();

            SpriteRenderer spriteCurrentBullet = currentBullet.GetComponent<SpriteRenderer>();

            Flip_SpriteRenderer(spriteCurrentBullet);
            currentBulletVelosyty.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            time_Attack = 2.08f;
        }
    }

    private void Flip_SpriteRenderer(SpriteRenderer sprait)
    {
        if (transform.position.x > player.transform.position.x)
        {
            sprait.flipX = true;
            new_Point_Attack = new Vector2(point_Attack.position.x - 1f, point_Attack.position.y);
        }
        else
        {
            sprait.flipX = false;
            new_Point_Attack = new Vector2(point_Attack.position.x + 1f, point_Attack.position.y);
        }
    }
}
