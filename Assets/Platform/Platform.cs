using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    public Vector3[] positions;
    public float[] angles;
    public GameObject platforms;
    public GameObject platformPrefab;
    public float maxScaleZ;
    public float minScaleZ;
    public float distance;
    public float t;
    float posZ;
    float randomScaleZ;
    public int index;
    int value;
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

    void CreatePlatform()
    {
        value = Random.Range(0, 2);
        if (value == 0)
        {
            index++;
        }
        if (value == 1)
        {
            index--;
        }
        if (index == -1)
            index = 1;
        if (index == 8)
            index = 6;

        currentPlatform = Instantiate(platformPrefab, positions[index], Quaternion.Euler(0, 0, angles[index]));
        currentPlatform.transform.SetParent(platforms.transform);
        previousPlatform = platforms.transform.GetChild(platforms.transform.childCount - 2).gameObject;

        //scale  
        randomScaleZ = Random.Range(minScaleZ, maxScaleZ);
        currentPlatform.transform.localScale = new Vector3(1, 0.5f, randomScaleZ);

        //pos
        posZ += previousPlatform.transform.localScale.z + distance;
        currentPlatform.transform.position = new Vector3(currentPlatform.transform.position.x, currentPlatform.transform.position.y, posZ);
    }

    IEnumerator FirstPlatforms()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(t);
            CreatePlatform();
        }
    }
}
