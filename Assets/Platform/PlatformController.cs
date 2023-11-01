using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static PlatformController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    [Range(0, 1)] public float smoothness;
    int childIndex;

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            childIndex++;
        }

        Transform childObj = transform.GetChild(childIndex);
        Quaternion objRotation = Quaternion.Inverse(childObj.transform.localRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, objRotation, smoothness);
    }
}
