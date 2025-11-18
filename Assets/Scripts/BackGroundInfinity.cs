using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundInfinity : MonoBehaviour
{
    public float speed; //Toc do bg troi
    [SerializeField]
    private Renderer bgRenderer;

    private void Start()
    {
        Debug.Log("Check bgRenderer.material: " + bgRenderer.material);
        Debug.Log("Check bgRenderer.materiel.mainTextureOffset: " + bgRenderer.material.mainTextureOffset);
    }

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
