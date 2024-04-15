using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExt : MonoBehaviour
{ 
    private ParticleSystem waters; 
    private AudioSource sound;
    public Transform checkBox;
    private float lastCheckTime;


    public InputActionReference input_shoot;
    private void Awake()
    {
        sound= GetComponent<AudioSource>(); 
        waters= GetComponentInChildren<ParticleSystem>(true);
    }
    private void Update()
    {
        if(waters.isEmitting)
        {
            if(Time.time -lastCheckTime > 0.5f)
            {
                lastCheckTime= Time.time;
                var colls = Physics.OverlapBox(checkBox.position, checkBox.localScale / 2, checkBox.rotation);

                foreach(var c in colls)
                {
                    if (c.TryGetComponent<Dirt>(out Dirt f))
                    {
                        f.Kill();
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        input_shoot.action.performed += Shoot;
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() > 0.5f)
        {
          if(!waters.isPlaying)  waters.Play();
            if (!sound.isPlaying) sound.Play();
        }
        else
        {
            if (waters.isPlaying) waters.Stop();
            if(sound.isPlaying)  sound.Stop(); 
            
        }
    }
    private void OnDisable()
    {
        input_shoot.action.performed -= Shoot;
    }
    private void Start()
    {
         
       
    }
}
