using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GridMovement grid;
    [SerializeField]
    private float speed;

    private Vector3 move_dest;
    private Vector3 bump_dest;

    // Start is called before the first frame update
    void Start()
    {
        move_dest = this.transform.position;
        bump_dest = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.Equals(move_dest))
        {
            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            if(hor != 0)
            {
                ver = 0;
            }

            Vector3 actual_dest = grid.GetNewPosition(this.transform.position, (int) hor, (int) ver);

            if(actual_dest.Equals(new Vector3()))
            {
                hor = hor / 2;
                ver = ver / 2;
                bump_dest = new Vector3(move_dest.x + hor, move_dest.y + ver);
            }
            else
            {
                move_dest = actual_dest;
            }
        }

        if(bump_dest.Equals(new Vector3()))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, move_dest, speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, bump_dest, speed * Time.deltaTime);
        }

        if (this.transform.position.Equals(bump_dest))
        {
            bump_dest = new Vector3();
        }
    }
}
