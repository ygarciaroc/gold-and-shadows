using UnityEngine;

public class lightattack : MonoBehaviour 
{
    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackRadius = 0.7f;
    public int damage = 10; 
    public float attackCooldown = 0.5f;
    public LayerMask enemyLayer; 

    private bool canAttack = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            lightAttackAction(); 
        }
    }

    void lightAttackAction()
    {
        canAttack = false; 

        //calculate where is the position of the attack
        Vector3 attackPoint = transform.position + transform.forward * attackRange;

        //detect the enemy 
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint, attackRadius, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if(enemy!= null)
            {
                health.TakeDamage(damage);
            }
        }
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack= true ;
    }
    private void OnDrawnGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 attackPoint = transform.position + transform.forward * attackRange; 
        Gizmos.DrawWireSphere(attackPoint, attackRadius);
    }
}
