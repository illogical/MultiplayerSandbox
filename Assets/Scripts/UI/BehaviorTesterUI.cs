using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviorTesterUI : MonoBehaviour
{

    [SerializeField] private Button testButton;
    [SerializeField] private Button test2Button;

    [SerializeField] private TestButtonNetworkBehavior testButtonsBehavior; // swappable!

    private void Start()
    {
        testButton?.onClick.AddListener(OnTestButtonClicked);
        test2Button?.onClick.AddListener(OnTest2ButtonClicked);
    }

    private void OnTestButtonClicked()
    {
        testButtonsBehavior.OnTestClick();
    }

    private void OnTest2ButtonClicked()
    {
        testButtonsBehavior.OnTest2Click();
    }
}
