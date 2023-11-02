using UnityEngine;

public class BallTexture : MonoBehaviour
{
    public Texture[] textures;
    int textureIndex;

    private void Start()
    {
        textureIndex = Random.Range(0, textures.Length);
        transform.GetComponent<Renderer>().material.mainTexture = textures[textureIndex];

    }

}
