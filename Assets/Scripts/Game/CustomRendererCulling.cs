﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRendererCulling : MonoBehaviour
{
    public float angleLimit = 90;
    public float minDistance = 2;
    public StateChangeEvent state;
    private float minDistanceSqr;
    private Camera mainCamera;
    private Renderer[] renderers;
    
    private IEnumerator Start()
    {
        // Wait for dungeon generation before looking for renderers
        yield return null;
        mainCamera = Camera.main;
        renderers = GetComponentsInChildren<Renderer>();
        minDistanceSqr = minDistance * minDistance;
    }
    
    private void LateUpdate()
    {
        if (renderers == null)
            return;

        Vector3 cameraDir = mainCamera.transform.forward;
        cameraDir.y = 0;
        Vector3 cameraPos = mainCamera.transform.position;
        for (int i = 0; i < renderers.Length; i++)
        {
            Vector3 targetPos = renderers[i].transform.position;
            Vector2 viewportPos = mainCamera.WorldToViewportPoint(targetPos);
            Vector3 cameraDelta = targetPos - cameraPos;
            cameraDelta.y = 0;
            float angle = Vector3.Angle(cameraDir, cameraDelta);

            if (state.CurrentState == GameState.Combat)
            {
                renderers[i].enabled = true;
            }
            else
            {
                renderers[i].enabled = angle <= angleLimit || Vector3.SqrMagnitude(cameraPos - targetPos) <= minDistanceSqr;
            }
        }
    }
}
