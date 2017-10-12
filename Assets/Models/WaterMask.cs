using UnityEngine;
using System.Collections;

public class WaterMask : MonoBehaviour {

    public RenderTexture maskTexture;

	// Use this for initialization
	void Awake ()
    {
        maskTexture = new RenderTexture((int)Screen.width, (int)Screen.height, 16, RenderTextureFormat.R8);
        GetComponent<Camera>().targetTexture = maskTexture;
        GetComponent<Camera>().aspect = (float)maskTexture.width / (float)maskTexture.height;
    }
	
}
