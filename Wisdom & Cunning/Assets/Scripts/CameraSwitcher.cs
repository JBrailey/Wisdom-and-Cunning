using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{ 
    public Camera foxCamera;
    public Camera birdsEyeCamera;
    public bool usingFoxCamera;
    public GameObject foxObject;

    Camera foxCam;
    Camera birdsEyeCam;
    bool usingFoxCam;

    void Start()
    {
        foxCam = foxCamera;
        birdsEyeCam = birdsEyeCamera;
        usingFoxCam = usingFoxCamera;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("Fox"))
        {
            if (usingFoxCam)
            {
                UseMazeCam();
            }
            else if (!usingFoxCam)
            {
                UseFoxCam();
            }
        }
    }

    void UseMazeCam()
    {
        foxCam.enabled = false;
        birdsEyeCam.enabled = true;
        usingFoxCam = false;
        foxObject.GetComponent<Fox>().ToggleMovement(true);
    }

    void UseFoxCam()
    {
        foxCam.enabled = true;
        birdsEyeCam.enabled = false;
        usingFoxCam = true;
        foxObject.GetComponent<Fox>().ToggleMovement(false);
    }
}
