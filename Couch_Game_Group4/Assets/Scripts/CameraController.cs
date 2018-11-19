using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform Target;
    public float SmoothingSpeed = 0.4f;

    [Header("Offsets")]
    public float HorizontalOffset = 2f;
    public float VerticalOffset = -10;

    private Vector3 _cameraMovingVelocity = Vector3.zero;


    void LateUpdate() {
        SmoothFollowTarget();        
    }

    private void SmoothFollowTarget() {
        Vector3 targetPositionWithOffset = Target.position + new Vector3(HorizontalOffset, 0f, VerticalOffset);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPositionWithOffset, ref _cameraMovingVelocity, SmoothingSpeed);
    }
}
