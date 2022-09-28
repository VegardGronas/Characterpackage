using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigid : RegisterInputs
{
    public float speed;
    public float jumpHight;
    public Transform lookAt;
    private Rigidbody rigid;

    public float slepTime;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveRigid();
        RotateRigid();
    }

    private void RotateRigid()
    {
        Vector3 tR = lookAt.transform.eulerAngles;
        tR.x = 0;
        tR.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(tR), slepTime * Time.fixedDeltaTime);
    }

    private void MoveRigid()
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
