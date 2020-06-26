using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainTexScaleChange : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleX, scaleY;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY);
        //ff
    }
}
