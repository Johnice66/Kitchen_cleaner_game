using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.TryGetComponent<Dirt>(out Dirt dirt))
        {
            dirt.Kill();
        }
    }
}
