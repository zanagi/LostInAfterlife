﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameCamera : MonoBehaviour
{
    public float turnSpeed = 1.0f, rotationTime = 0.5f;

    private void Start()
    {
        SetCursorLock(true);
    }

    public void SetCursorLock(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }

    public void HandleUpdate()
    {
        var x = CrossPlatformInputManager.GetAxis(Static.mouseXAxis);
        transform.Rotate(Vector3.up * x * turnSpeed);
    }

    public void RotateTowards(Transform target)
    {
        StopAllCoroutines();
        StartCoroutine(RotateTowardsTarget(target.position));
    }

    private IEnumerator RotateTowardsTarget(Vector3 pos)
    {
        Quaternion startRot = transform.rotation;
        Vector3 targetPos = pos;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        Quaternion endRot = transform.rotation;
        float time = 0.0f;

        while(time < rotationTime)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRot, endRot, time / rotationTime);
            yield return null;
        }
    }
}
