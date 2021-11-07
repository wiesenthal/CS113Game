using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] players;
    public GameObject background;
    public float speed;
    public float health;
    public float damage;
    public float attackRange;
    public float attackSpeed;
    public float knockbackMultiplier;
    public float attackRate = 2f; // per second
    public float weight;
    private bool readyToAttack;
    private float timeSinceLastAttack = 0f;
    
    private Vector3 curDirection = Vector3.right;

    public virtual void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        CircleCollider2D cc = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
        cc.isTrigger = false;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        rb.angularDrag = 0;

        speed = 1f;
        health = 100f;
        damage = 34f;
        attackRange = 1f;
        knockbackMultiplier = 1f;
        weight = 1f;
        readyToAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.name.Contains("(Clone)"))
            return;
        doMovement();
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= 1/attackRate)
        {
            readyToAttack = true;
        }
    }
    
    void doMovement()
    {
        Vector3 movement;
        // find closest player (should only be one player)
        GameObject player = findClosestPlayer();
        // if player is nearby, move towards player
        if (Vector3.Distance(transform.position, player.transform.position) < 10f)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            movement = direction * speed * Time.deltaTime;
        }
        else
        {
            // random walk
            curDirection += Quaternion.Euler(0, 0, Random.Range(-15f, 15f)) * curDirection;
            curDirection.Normalize();
            movement = curDirection * speed * Time.deltaTime;
        }
        if (background.GetComponent<backgroundController>().isWithinBounds(transform.position + movement))
        {
            transform.Translate(movement);
        }
    }

    GameObject findClosestPlayer()
    {
        GameObject closestPlayer = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestPlayer = player;
                closestDistance = distance;
            }
        }
        return closestPlayer;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isReady())
        {
            Attack(collision.gameObject);
        }
    }

    public bool isReady()
    {
        return readyToAttack;
    }

    protected void Attack(GameObject target)
    {
        // calculate knockback
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        target.GetComponent<characterController>().takeDamage(damage, direction * knockbackMultiplier);
        readyToAttack = false;
        timeSinceLastAttack = 0f;
    }

    public void takeDamage(float damage, Vector3 knockback)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.Translate(knockback / weight);
    }
}
