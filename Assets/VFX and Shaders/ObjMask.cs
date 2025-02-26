using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int matIndex = 4;
    void Start()
    {
        SkinnedMeshRenderer meshrenderer = GetComponent<SkinnedMeshRenderer>();
        if (meshrenderer != null)
        {
            meshrenderer.materials[matIndex].renderQueue = 3002;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}