using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Singelton
    public static Platform Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    #endregion

    public Vector3[] positions;
    public float[] angles;
    public GameObject platformPrefab;
    public float platformMaxScale;
    public float platformMinScale;
    public float distance;
    public float firstPlatformTimeing;

    float posZ;
    float randomScaleZ;
    int index;
    int leftOrRight;
    GameObject currentPlatform;
    GameObject previousPlatform;
    void Start()
    {
        StartCoroutine("FirstPlatforms");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CreatePlatform();
    }

    public void CreatePlatform()
    {
        // index++ ---->         <---- index--
        leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
            index++;

        if (leftOrRight == 1)
            index--;

        if (index == -1)
            index = 1;

        if (index == 8)
            index = 6;

        currentPlatform = Instantiate(platformPrefab, positions[index], Quaternion.Euler(0, 0, angles[index]));

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!false --> parentin lokaldeki transformunu verir  true--> objenin dünyadaki transformu verir!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        currentPlatform.transform.SetParent(transform, false);
        previousPlatform = transform.GetChild(transform.childCount - 2).gameObject;

        //scale  
        randomScaleZ = Random.Range(platformMinScale, platformMaxScale);
        currentPlatform.transform.localScale = new Vector3(1, 0.5f, randomScaleZ);

        //pos
        posZ += currentPlatform.transform.localScale.z / 2 + previousPlatform.transform.localScale.z / 2 + distance;
        currentPlatform.transform.localPosition = new Vector3(currentPlatform.transform.localPosition.x, currentPlatform.transform.localPosition.y, posZ);
    }


    IEnumerator FirstPlatforms()
    {
        for (int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(firstPlatformTimeing);
            CreatePlatform();
        }
    }
}
