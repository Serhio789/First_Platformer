using Platformer.Inputs;
using UnityEditor.Tilemaps;
using UnityEngine;


namespace Platformer.Inputs
{


    [RequireComponent(typeof(Rigidbody2D))]
    public class Player_Scripts : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] 
        private float Speed = 2.0f;
        private Rigidbody2D player_Rigidbody;
        private Vector2 moveCheck;
        private Animator _anim;
        public SpriteRenderer player;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            player = GetComponent<SpriteRenderer>();
        }
        private void Awake()
        {
            player_Rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            float harizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            if (harizontal != 0)
            {
                _anim.SetBool("Is_Run", true);
                player.flipX = harizontal < 0;
                moveCheck = new Vector2(harizontal, 0);
            }
            else
                _anim.SetBool("Is_Run", false);
        }
        private void FixedUpdate()
        {
            MoveCharacter();
        }
        private void Turn()
        {
            float harizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            player.flipX = harizontal < 0;
        }
        private void MoveCharacter()
        {
            player_Rigidbody.AddForce(moveCheck * Speed);
        }
    }
}
