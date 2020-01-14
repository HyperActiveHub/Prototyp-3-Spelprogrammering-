using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransistion : MonoBehaviour
{
    public RenderTexture rt;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            ScreenCapture.CaptureScreenshotIntoRenderTexture(rt);
        }
    }
}
