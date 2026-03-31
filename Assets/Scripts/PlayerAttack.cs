using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private LayerMask enemyLayer;

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        bool hitSomething = false;

        foreach (Collider hit in hits)
        {
            Health enemyHealth = hit.GetComponent<Health>();

            if (enemyHealth != null && !hit.CompareTag("Player"))
            {
                enemyHealth.TakeDamage(attackDamage);
                hitSomething = true;
                Debug.Log("Hit enemy: " + hit.name);
                break;
            }
        }

        if (!hitSomething)
        {
            Debug.Log("Attack missed");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}