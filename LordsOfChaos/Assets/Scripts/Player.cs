using UnityEngine;

public class Player : Character
{
    // TEST CODE ONLY   //

    public GameManager gmInstance;
    public GameObject[] prefabs;

    // END OF TEST CODE //

    [SerializeField]
    private Stats health;

    [SerializeField]
    private Stats mana;

    private float initHealth = 100;

    private float initMana = 50;

    // Start is called before the first frame update
    protected override void Start()
    {
        health.Initialize(initHealth, initHealth);            // HARDCODED VALUES FOR NOW!
        mana.Initialize(initMana, initMana);
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();

        base.Update();
    }

    // Listen to player's input
    private void GetInput()
    {
        direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction += (Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction += (Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction += (Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction += (Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        // TEST CODE ONLY //

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            gmInstance.objectToInstantiate = prefabs[0];
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            gmInstance.objectToInstantiate = prefabs[1];
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Instantiate(gmInstance.objectToInstantiate, new Vector3((Random.Range(-4, 8)), 0, (Random.Range(-4, 8))), Quaternion.identity);
        }

        // END OF TEST CODE //
    }
}
