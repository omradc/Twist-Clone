using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Singelton
    public static CameraController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }
    #endregion

    [Header("FOLLOW")]
    [SerializeField] Transform target;
    [SerializeField] float delay;
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField][Range(0, 1)] float smoothness = 0.12f;

    [Header("ROTATION")]
    public Transform platformsParent;
    [Range(0, 1)] public float rotationSmoothness;
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        float posZ = target.position.z + delay;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(posX, posY, posZ), smoothness);
        transform.position = smoothedPosition;
    }

}
