using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SamDriver.Decal;

public class AutoProject : MonoBehaviour
{
    public GameObject decalPrefab;
    public Transform center;
#if UNITY_EDITOR

    [MenuItem("MyFunc/Auto Proj")]
    public static void Proj()
    {

        Vector3 centerPos = FindObjectOfType<AutoProject>().center.position;
        GameObject prefab = FindObjectOfType<AutoProject>().decalPrefab;

        for (int i = 0; i < 50; i++)
        {
            var randomDir = Random.insideUnitSphere;
            if(randomDir.y > 0)
            {
                randomDir.y *= -1;
            }

            if(Physics.Raycast(centerPos,randomDir,out RaycastHit h, 50))
            {
                Vector3 spawnPos = h.point + h.normal * 0.05f;

                var obj = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity, FindObjectOfType<AutoProject>().center);
                obj.transform.forward = -h.normal;

               obj.GetComponentInChildren<DecalMesh>().GenerateProjectedMeshImmediate();
            }
        }
      
        
    }
#endif
}
