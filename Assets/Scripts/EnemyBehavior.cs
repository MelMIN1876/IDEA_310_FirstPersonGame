using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float PlayerDistance;
    private Vector3 IdlePosition = Vector3.zero;
    private GameObject Player;
    private PlayerHealth playerHealth;

    public float ChaseRange = 5f;
    public float AttackRange = 1f;
    public float EnemySpeed = 2f;
    public int damage = 10;
    public float attackCoolDown = 1.5f;
    private float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IdlePosition = transform.position;
        Player = GameObject.FindWithTag("Player");

        playerHealth = Player.GetComponentInChildren<PlayerHealth>();
        EnemyManager.Instance.RegisterEnemy(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerLocation = Player.transform.position;
        PlayerDistance = Vector3.Distance(playerLocation, transform.position);

        
        if(PlayerDistance < AttackRange)
        {
            Debug.Log("Player is in attack range!");
            transform.LookAt(playerLocation);
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0f)
            {
                playerHealth.TakeDamage(damage);
                attackTimer = attackCoolDown;
            }
            
            
        }
        else if(PlayerDistance < ChaseRange)
        {
            Debug.Log("Player is in chase range");
            transform.LookAt(playerLocation);
            var moveVector = transform.forward * Time.deltaTime * EnemySpeed;
            transform.position += moveVector;
        }
        else if(Vector3.Distance(transform.position, IdlePosition) > .25f)
        {
            Debug.Log("Player is in IDLE range");
            transform.LookAt(IdlePosition);
            var moveVector = transform.forward * Time.deltaTime * EnemySpeed;
            transform.position += moveVector;
        }
    }

    public void Die()
    {
        Debug.Log("Enemy has died");
        EnemyManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }
}
