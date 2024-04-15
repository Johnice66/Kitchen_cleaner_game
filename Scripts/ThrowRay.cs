using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowRay : MonoBehaviour
{
    private bool lastActive;
    private XRRayInteractor ray;


    public bool isThrow;
    private void Awake()
    {
        ray = GetComponent<XRRayInteractor>();
    }
    private void Update()
    {
        bool act = ray.xrController.activateInteractionState.activatedThisFrame;
        if (act && !lastActive)
        {
            if(ray.interactablesHovered.Count > 0)
            {
                print(ray.interactablesHovered[0]);
                if (isThrow)
                {
                    if (ray.interactablesHovered[0].transform.TryGetComponent<Throwable>(out Throwable t))
                    {
                        t.Throw();
                    }
                }
                else
                {
                    (ray.interactablesHovered[0] as XRBaseInteractable).activated?.Invoke(new ActivateEventArgs());
                }


            } 
        }
        lastActive = act;
    }
    private void Start()
    {
       
    }
}
