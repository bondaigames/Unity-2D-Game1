using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public ColorData colorData;
    // Start is called before the first frame update
    void Start()
    {
        int randomColorIndex = Random.Range(0, colorData.colors.Length);
        Debug.Log("random color index :" + colorData.colors.Length);
        meshRenderer.material = colorData.colors[randomColorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
