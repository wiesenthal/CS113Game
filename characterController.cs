using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    // Start is called before the first frame update

    
    private Vector3 gunOffset = new Vector3(0.5f, 0.2f, 0);
    // should have a healthbar
    public GameObject gun;
    public GameObject background;
    public float speed;
    public float health;
    public float weight;
    void Start()
    {
        speed = 5f;
        health = 100f;
        weight = 1f;
    }    

    // Update is called once per frame
    void Update()
    {
        doMovement();
        affixGun();
        doActions();
    }

    void doActions()
    {
        // shooting
        tryShoot();
    }

    void tryShoot()
    {
        if (Input.GetMouseButton(0) && gun.GetComponent<GunController>().isReady())
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gun.GetComponent<GunController>().Fire(mousePos);
        }
    }

    void affixGun()
    {
        gun.transform.position = transform.position + gunOffset;
    }

    void doMovement()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
        // if the player would be within the bounds of the background
        if (background.GetComponent<backgroundController>().isWithinBounds(transform.position + movement))
        {
            transform.Translate(movement);
        }
    }

    public void takeDamage(float damage, Vector3 knockback)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            // Lose(); Make a lose function attached to a central game script
        }
        transform.Translate(knockback / weight);
    }
}
