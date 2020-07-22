using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange_Floor : MonoBehaviour {

    public Texture[] textureList;
    public int currentTexture;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = textureList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentTexture++;
            currentTexture %= textureList.Length;
            GetComponent<Renderer>().material.mainTexture = textureList[currentTexture];
        }

    }
}
