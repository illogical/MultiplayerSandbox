using Assets.Scripts;
using Assets.Scripts.Models;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class SpawnTest : TestButtonNetworkBehavior
{

    [SerializeField] private GameObject redBox;
    [SerializeField] private GameObject blueBox;
    [SerializeField] private GameObject sharedObjectPrefab;

    private List<GameObject> sharedObjects;

    private const int Z_POSITION = 25;

    private void Awake()
    {
        sharedObjects = new List<GameObject>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        Debug.Log("OnNetworkSpawn executed");
    }

    public override void OnTestClick()
    {
        CreateMyBoxServerRpc();
    }

    public override void OnTest2Click()
    {
        CreateSharedBoxServerRpc();
    }

    private void CreateBoxes()
    {
        var redBoxPosition = LayoutManager.GetScreenLeftCenterPositionForObject(redBox, Camera.main, Z_POSITION);
        var blueBoxPosition = LayoutManager.GetScreenBottomCenterPositionForObject(blueBox, Camera.main, Z_POSITION);

        Instantiate(redBox, redBoxPosition, Quaternion.identity);
        Instantiate(blueBox, blueBoxPosition, Quaternion.identity);
    }

    [ServerRpc(RequireOwnership = false)]
    private void CreateMyBoxServerRpc(ServerRpcParams serverRpcParams = default)
    {
        // tell just the caller to create their box
        Debug.Log($"serverRpcParams.Receive.SenderClientId={serverRpcParams.Receive.SenderClientId}");

        ClientRpcParams clientRpcParams = new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new ulong[] { serverRpcParams.Receive.SenderClientId } } };

        if (serverRpcParams.Receive.SenderClientId == 0)
        {
            CreateMyBlueBoxClientRpc(clientRpcParams);
        }
        else
        {
            CreateMyRedBoxClientRpc(clientRpcParams);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void CreateSharedBoxServerRpc(ServerRpcParams serverRpcParams = default)
    {
        CreateSharedGreenBoxClientRpc(serverRpcParams.Receive.SenderClientId);
    }

    [ClientRpc]
    private void CreateMyRedBoxClientRpc(ClientRpcParams clientRpcParams = default)
    {
        var redBoxPosition = LayoutManager.GetScreenBottomCenterPositionForObject(redBox, Camera.main, Z_POSITION);
        Instantiate(redBox, redBoxPosition, Quaternion.identity);
    }

    [ClientRpc]
    private void CreateMyBlueBoxClientRpc(ClientRpcParams clientRpcParams = default)
    {
        var blueBoxPosition = LayoutManager.GetScreenBottomCenterPositionForObject(blueBox, Camera.main, Z_POSITION);
        Instantiate(blueBox, blueBoxPosition, Quaternion.identity);
    }

    [ClientRpc]
    private void CreateSharedGreenBoxClientRpc(ulong clientId)
    {
        var newSharedObject = Instantiate(sharedObjectPrefab, Vector3.zero, Quaternion.identity);
        sharedObjects.Add(newSharedObject);

        // TODO: can each client move this object?
        var greenBoxPosition = LayoutManager.GetScreenLeftCenterNextPositionForObject(newSharedObject, Camera.main, sharedObjects.Count, Z_POSITION);
        newSharedObject.transform.position = greenBoxPosition;
        var boxUI = newSharedObject.GetComponent<BoxUI>(); 
        boxUI.SetText("ClientId=" + clientId.ToString());
    }
}
