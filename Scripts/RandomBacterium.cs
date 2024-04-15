using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class RandomBacterium : MonoBehaviour
{
    public GameObject[] prefabs;

    public float length = 5;
    private Vector3 initPos;
    private void Start()
    {
        length *= Random.Range(0.8f, 1.5f);
        initPos = transform.position;
        Instantiate(prefabs[Random.Range(0, prefabs.Length)],transform);

        GetComponent<XRSimpleInteractable>().activated.AddListener((v) =>
        { 
            FindObjectOfType<Manager>().ShowMessage();
        });
    }
    private void Update()
    {
        transform.position = initPos + Vector3.up * Mathf.PingPong(Time.time/length, 0.1f);
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        

    }
}
