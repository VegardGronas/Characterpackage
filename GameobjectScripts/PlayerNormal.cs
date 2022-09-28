using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormal : RegisterInputs
{
    public float speed;
    
    private void Update()
    {
        transform.position += MoveDir * speed * Time.deltaTime;
    }
}