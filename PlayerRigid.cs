using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigid : RegisterInputs
{
    public float speed;
    public float rotSpeed;
    public float jumpHight;
    private Rigidbody rigid;

    private float currentRotation;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dirFront = transform.forward * MoveDir.z;
        Vector3 dirSide = -transform.right * MoveDir.x;
        Vector3 dir = dirFront - dirSide;

        if (Jump)
        {
            rigid.AddForce(transform.up * jumpHight, ForceMode.Impulse);
        }

        if (Grounded)
        {
            rigid.velocity = speed * Time.fixedDeltaTime * dir;
        }
    }
}
