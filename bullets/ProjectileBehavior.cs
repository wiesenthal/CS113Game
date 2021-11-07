using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;
    public float damage;
    public float knockbackMultiplier;
    public virtual void Start()
    {
        if (!gameObject.name.Contains("(Clone)"))
        {
            CircleCollider2D cc = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
            cc.isTrigger = true;
        }

        speed = 15f;
        lifeTime = 5f;
        damage = 50f;
        knockbackMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.name.Contains("(Clone)"))
            return;
        // move forward at constant speed
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        lifeTime -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitEnemy(collision.gameObject);
        }
    }
    protected void hitEnemy(GameObject target)
    {
        // calculate knockback
        Vector3 direction = target.transform.position - transform.position;
        target.GetComponent<EnemyController>().takeDamage(damage, direction * knockbackMultiplier);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
