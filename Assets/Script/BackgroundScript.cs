using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float speed;
    public MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(0f,speed * Time.deltaTime);
    }
}
