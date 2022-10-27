using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(x: 2048, y: 2038);

    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D(width: (int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }
}
