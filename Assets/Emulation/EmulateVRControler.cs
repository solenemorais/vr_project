using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class EmulateVRControler : MonoBehaviour
{
    Camera cam;
    float depth=1f;
    public float depthChangeSpeed;

    public UnityEvent onTriggerPressed = new UnityEvent();
    public UnityEvent onTriggerReleased = new UnityEvent();

    public static bool XRDeviceIsPresent
    {
        get
        {
            var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
            foreach (var xrDisplay in xrDisplaySubsystems)
            {
                if (xrDisplay.running)
                {
                    return true;
                }
            }
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;


        //Désactive ce script si un casque VR est activé
        if (XRDeviceIsPresent)
            enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Récupère la position de la souris sur x et y
        Vector3 targetPosition = Input.mousePosition;

        //On utilise la molette pour controller la profondeur
        depth += Input.GetAxis("Mouse ScrollWheel") * depthChangeSpeed * Time.deltaTime;

        //On limite la profondeur
        depth = Mathf.Clamp(depth, 0.4f, 1.5f);

        //On applique la profondeur sur Z
        targetPosition.z = depth;

        //On place notre objet a l'endroit visé
        transform.position = cam.ScreenToWorldPoint(targetPosition);

        //Envoie des événements pour simuler l'appuis d'un bouton sur la manette
        if (Input.GetMouseButtonDown(0))
            onTriggerPressed.Invoke();
        if (Input.GetMouseButtonUp(0))
            onTriggerReleased.Invoke();
    }
}
