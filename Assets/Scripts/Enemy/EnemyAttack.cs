using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    //private HealthController healthController;
    public UnityEvent isEnemyAttack;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();

            healthController.TakeDamage(_damageAmount);

            //var rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            //if (rigidbody2D != null)
            //{
            //    collision.gameObject.GetComponent<PlayerMovement>().isAttack = true;
            //    rigidbody2D.AddForce(-transform.position*3, ForceMode2D.Impulse);
            //    collision.gameObject.GetComponent<PlayerMovement>().isAttack = false;
            //}

            isEnemyAttack.Invoke();
        }
    }
}
