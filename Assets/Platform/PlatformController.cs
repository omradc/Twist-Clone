using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Range(0, 1)] public float smoothness;
    public int index;
    Platform platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = Platform.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
            index++;

        Transform childObj = transform.GetChild(index);
        Quaternion objRotation = Quaternion.Inverse(childObj.transform.localRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, objRotation, smoothness);
    }

}
