using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{

    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(OnServerButtonClicked);
        hostButton.onClick.AddListener(OnHostButtonClicked);
        clientButton.onClick.AddListener(OnClientButtonClicked);
    }

    private void OnServerButtonClicked()
    {
        NetworkManager.Singleton.StartServer();
    }

    private void OnHostButtonClicked()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void OnClientButtonClicked()
    {
        NetworkManager.Singleton.StartClient();
    }
}
