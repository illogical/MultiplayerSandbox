using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutPositions : MonoBehaviour
{

    [SerializeField] private GameObject leftCenterObject;
    [SerializeField] private GameObject bottomCenterObject;
    [SerializeField] private float distanceFromCamera;

    private float currentDistanceFromCamera;
    private Vector2 screenSize;

    private void Start()
    {
        screenSize = Vector2.zero;
        currentDistanceFromCamera = distanceFromCamera;
    }

    private void Update()
    {
        if(Screen.width != screenSize.x || Screen.height != screenSize.y || currentDistanceFromCamera != distanceFromCamera)
        {
            screenSize = new Vector2(Screen.width, Screen.height);
            currentDistanceFromCamera = distanceFromCamera;

            // TODO: find out how to get this position on both clients
            leftCenterObject.transform.position = LayoutManager.GetScreenLeftCenterPositionForObject(leftCenterObject, Camera.main, distanceFromCamera);
            bottomCenterObject.transform.position = LayoutManager.GetScreenBottomCenterPositionForObject(bottomCenterObject, Camera.main, distanceFromCamera);
        }

        
    }

    
}
