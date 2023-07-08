using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class LayoutManager : MonoBehaviour
    {
        public static Vector3 GetScreenLeftCenterPositionForObject(GameObject gameObject, Camera camera, float destinationZ)
        {
            var objectSize = GetObjectDimensions(gameObject);

            // keep in mind that the face closest to the camera is half the depth closer than the center of the object)
            var leftMiddleWithDepth = camera.ViewportToWorldPoint(new Vector3(0, 0.5f, Mathf.Abs(camera.transform.position.z) + destinationZ - (objectSize.z / 2)));
            return new Vector3(leftMiddleWithDepth.x + objectSize.x / 2, leftMiddleWithDepth.y, destinationZ);
        }

        public static Vector3 GetScreenBottomCenterPositionForObject(GameObject gameObject, Camera camera, float destinationZ)
        {
            var objectSize = GetObjectDimensions(gameObject);

            // keep in mind that the face closest to the camera is half the depth closer than the center of the object)
            var leftMiddleWithDepth = camera.ViewportToWorldPoint(new Vector3(0.5f, 0, Mathf.Abs(camera.transform.position.z) + destinationZ - (objectSize.z / 2)));
            return new Vector3(leftMiddleWithDepth.x, leftMiddleWithDepth.y + objectSize.x / 2, destinationZ);
        }

        public static Vector3 GetObjectDimensions(GameObject gameObject)
        {
            var renderer = gameObject.transform.GetComponent<Renderer>();   // all objects must be the same shape/size
            return renderer.bounds.size;
        }
    }
}
