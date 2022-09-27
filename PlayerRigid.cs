using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigid : RegisterInputs
{
    public float speed;
    public float rotSpeed;
    public ForceMode forceMode;
    private Rigidbody rigid;

    private float currentRotation;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.forward * MoveDir.z;

        rigid.AddForce(dir * speed, forceMode);

        if (MoveDir.x != 0)
        {
            currentRotation = transform.rotation.y;
            currentRotation += Mathf.RoundToInt(MoveDir.x * rotSpeed);
            rigid.rotation *= Quaternion.Euler(transform.rotation.x, currentRotation, transform.rotation.z);
        }
    }
}
