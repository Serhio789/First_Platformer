using UnityEngine;

public class Damage_Dealler : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<Health>().Tack_Damage(damage);
        }
        Destroy(gameObject);
    }
}
