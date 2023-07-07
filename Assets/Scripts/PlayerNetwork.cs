using System;
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

        if(Input.GetKeyDown(KeyCode.T))
        {
            TestServerRpc(new ServerRpcParams());
        }

        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        float moveSpeed = 3;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    [ServerRpc(RequireOwnership = false)]
    private void TestServerRpc(ServerRpcParams serverRpcParams)
    {
        Debug.Log($"TestServerRpc executed. ClientId = {serverRpcParams.Receive.SenderClientId}");

        TestClientRpc();
        TestSpecificClientRpc(new ClientRpcParams() 
        { 
            Send = new ClientRpcSendParams() 
            { 
                TargetClientIds = new List<ulong>() 
                { 
                    1 // 2nd player to join
                }
            } 
        });
    }

    [ClientRpc]
    private void TestClientRpc()
    {
        Debug.Log("TestClientRpc executed");
    }

    [ClientRpc]
    private void TestSpecificClientRpc(ClientRpcParams clientRpcParams)
    {
        if(IsOwner)
        {
            Debug.Log($"TestSpecificClientRpc executed. I am the owner.");
        }
        else
        {
            Debug.Log($"TestSpecificClientRpc executed. I am NOT the owner.");
        }
    }
}
