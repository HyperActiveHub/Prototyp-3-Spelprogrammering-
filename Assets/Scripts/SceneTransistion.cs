using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransistion : MonoBehaviour
{
    public RenderTexture rt;
    public GameObject go;
    public float fadeTime;

    float timer;
    bool fadeOut, fadeIn;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            //ScreenCapture.CaptureScreenshotIntoRenderTexture(rt);
            var tex = ScreenCapture.CaptureScreenshotAsTexture();
            go.GetComponent<UnityEngine.UI.RawImage>().material.mainTexture = tex;
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            fadeOut = true;
            fadeIn = false;

        }
        else if (Input.GetKeyDown(KeyCode.F10))
        {
            fadeIn = true;
            fadeOut = false;
        }
    }

    private void LateUpdate()
    {
        if (fadeOut)
        {
            float a = 1;
            if (timer < fadeTime)
            {
                timer += Time.deltaTime;
                var t = timer / (fadeTime + 0.001f);
                a = Mathf.Lerp(1, 0, t);
            }
            else
            {
                timer = 0;
                a = 0;
                fadeOut = false;
            }

            var c = go.GetComponent<UnityEngine.UI.RawImage>().material.color;
            go.GetComponent<UnityEngine.UI.RawImage>().material.color = new Color(c.r, c.g, c.b, a);
        }
        else if (fadeIn)
        {
            float a = 0;
            if (timer < fadeTime)
            {
                timer += Time.deltaTime;
                var t = timer / (fadeTime + 0.001f);
                a = Mathf.Lerp(0, 1, t);
            }
            else
            {
                timer = 0;
                a = 1;
                fadeIn = false;
            }

            var c = go.GetComponent<UnityEngine.UI.RawImage>().material.color;
            go.GetComponent<UnityEngine.UI.RawImage>().material.color = new Color(c.r, c.g, c.b, a);
        }
    }
}
