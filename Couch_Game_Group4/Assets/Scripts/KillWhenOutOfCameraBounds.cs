using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWhenOutOfCameraBounds : MonoBehaviour {
    public float BoundsOffset = 0.05f;
    private Camera _mainCamera;

    void Awake() {
        _mainCamera = Camera.main;    
    }

    void Update() {
        if (ObjectIsOutOfCameraBounds()) {
            Destroy(this.gameObject);
        }    
    }

    private bool ObjectIsOutOfCameraBounds() {
        Vector2 ObjectScreenPosition = _mainCamera.WorldToViewportPoint(this.transform.position);

        float leftBoundsWithOffset = 0f - BoundsOffset;
        float rightBoundsWithOffset = 1f + BoundsOffset;

        bool objectIsOutsideBounds = ObjectScreenPosition.x < leftBoundsWithOffset || ObjectScreenPosition.x > rightBoundsWithOffset;

        return objectIsOutsideBounds;
    }
}
