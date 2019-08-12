using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour                 // Class is abstract as it cannot exist alone, 
                                                                // it must have classes that derive from it.
{
    // THESE ARE ALL PART OF THE CHILD CLASS TOO //
    // protected int health;
    protected int movement;
    protected int constitution;
    protected int attack;
    protected int defense;

    protected Vector3 direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    // THIS IS PASSED ON TO CHILD OF CLASS //
    void Move()
    {
        {
            transform.Translate(direction);
        }
    }


}
