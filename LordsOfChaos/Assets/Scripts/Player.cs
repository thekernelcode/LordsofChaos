using UnityEngine;

public class Player : Character
{

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
