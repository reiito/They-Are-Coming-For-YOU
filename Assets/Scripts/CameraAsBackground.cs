﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAsBackground : MonoBehaviour
{
    public GameController gameController;

    private RawImage image;
    private WebCamTexture cam;

    private AspectRatioFitter arf;

    private void Start()
    {
        arf = GetComponent<AspectRatioFitter>();

        image = GetComponent<RawImage>();
        cam = new WebCamTexture(Screen.width, Screen.height);
        image.texture = cam;
        cam.Play();
    }

    private void Update()
    {
        if (gameController.gameOver)
            return;

        if (cam.width < 100)
        {
            return;
        }

        float cwNeeded = -cam.videoRotationAngle;
        if (cam.videoVerticallyMirrored)
        {
            cwNeeded += 180f;
        }

        image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);

        float videoRatio = (float)cam.width / (float)cam.height;
        arf.aspectRatio = videoRatio;

        if (cam.videoVerticallyMirrored)
        {
            image.uvRect = new Rect(1f, 0f, -1f, 1f);
        }
        else
        {
            image.uvRect = new Rect(0f, 0f, 1f, 1f);
        }
    }
}
