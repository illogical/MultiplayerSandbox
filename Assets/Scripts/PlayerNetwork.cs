using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private void Update()
    {
        if(!IsOwner)
        {
            return;
        }

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        float moveSpeed = 3;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
