using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class PhoneCamera : MonoBehaviour
{


    #region old Script
    /*bool camAvailable;
    static WebCamTexture backCam;
    Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    public Text debug;

    void Awake()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        WebCamDevice[] devices = WebCamTexture.devices;
        debug.text = devices.Length.ToString();
        if (backCam == null)
        {
            backCam = new WebCamTexture();
        }
        background.texture = backCam;
        backCam.Play();

        defaultBackground = background.texture;

         WebCamDevice[] devices = WebCamTexture.devices;

         if (devices.Length == 0)
         {
             Debug.Log("No Camera Detected");
             camAvailable = false;
             return;
         }

         for (int i = 0; i < devices.Length; i++)
         {
             if (!devices[i].isFrontFacing)
             {
                 backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
             }
         }

         if(backCam == null)
         {
             Debug.Log("Unable to Find Back Camera");
             return;
         }

         backCam.Play();
         background.texture = backCam;

         camAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!camAvailable)
        {
            return;
        }
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1 : 1;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orientation = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }*/
    #endregion
}
