using Platformer.Inputs;
using UnityEditor.Tilemaps;
using UnityEngine;
using System;


namespace Platformer.Inputs
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player_Scripts : MonoBehaviour
    {
        [SerializeField] private float Speed = 2.0f;
        private Rigidbody2D player_Rigidbody;
        private Vector2 moveCheck;
        private Animator _anim;
        [SerializeField] private SpriteRenderer player;
        [SerializeField] private float jamp_Fors;
        [SerializeField] private float jamp_Trigger_Radius;
        [SerializeField] private Transform graundTransform;
        private bool jump;
        [SerializeField] private LayerMask graundMask;
        private float positionNow;
        private float positionBefor;
        private bool is_Allive = true;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            player = GetComponent<SpriteRenderer>();
            player_Rigidbody = GetComponent<Rigidbody2D>();

            positionNow = player_Rigidbody.transform.position.y;
            positionBefor = positionNow;
        }
        private void FixedUpdate()
        {
            if (is_Allive)
            {
                _anim.SetBool("Attack_1", false);
                _anim.SetBool("Attack_2", false);

                // ���������� ������ 
                positionNow = player_Rigidbody.transform.position.y;
                Vector2 overlapCirclePosition = graundTransform.position;
                MoveCharacter();
                jump = Physics2D.OverlapCircle(overlapCirclePosition, jamp_Trigger_Radius, graundMask);
                JumpCharacter(jump);

                // �������� ��� ������ � �������

                float difference = positionNow - positionBefor;
                if (difference > 0.01)
                {
                    _anim.SetBool("Is_Jamp", true);
                    _anim.SetBool("is_Fall", false);
                }
                if (difference < -0.01)
                {
                    _anim.SetBool("is_Fall", true);
                    _anim.SetBool("Is_Jamp", false);
                }
                if (difference < 0.01 && difference > -0.01)
                {
                    _anim.SetBool("Is_Jamp", false);
                    _anim.SetBool("is_Fall", false);
                    _anim.SetFloat("is_Run", 0);
                }

                positionBefor = positionNow;

                // ���������� �������� 

                float harizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
                float mod_harizontal = MathF.Sqrt(harizontal * harizontal);
                if (harizontal != 0)
                {
                    player.flipX = harizontal < 0;
                    moveCheck = new Vector2(harizontal, 0);
                }
                if (jump)
                    _anim.SetFloat("is_Run", mod_harizontal);
                Attack_1();
                Attack_2();
            }
        }

        public void Dead_Player(bool alive)
        {
            is_Allive = alive;
        }

        private void MoveCharacter()
        {
            player_Rigidbody.AddForce(moveCheck * Speed);
        }
        private void JumpCharacter(bool jump)
        {
            if (Input.GetAxis(GlobalStringVars.JAMP_BUTTON) >= 0.1)
                if (jump)
                    player_Rigidbody.AddForce(transform.up * jamp_Fors, ForceMode2D.Impulse);
        }

        private void Attack_1()
        {
            if (Input.GetAxis(GlobalStringVars.Attack_1) > 0.1)
                _anim.SetBool("Attack_1", true);
        }

        private void Attack_2()
        {
            if (Input.GetAxis(GlobalStringVars.Attack_2) > 0.1)
                _anim.SetBool("Attack_2", true);
        }
    }
}
