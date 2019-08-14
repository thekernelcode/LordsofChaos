using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string name;
    public float movement;
    public float strength;
    public float health;
    public float defence;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
