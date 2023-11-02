using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    #region Singelton
    public static PlatformController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    #endregion

    [Range(0, 1)] public float smoothness;
    int childIndex;
    PlayerComtroller playerComtroller;
    private void Start()
    {
        playerComtroller = PlayerComtroller.Instance;
        childIndex = -1;
    }
    void Update()
    {
        if (playerComtroller.gameOver)
            return;
            
        Move();
    }
    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            childIndex++;
        }

        if (childIndex >= 0)
        {
            Transform childObj = transform.GetChild(childIndex);
            Quaternion objRotation = Quaternion.Inverse(childObj.transform.localRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, objRotation, smoothness);
        }

    }
}
