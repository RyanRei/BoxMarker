using UnityEngine;

public class MeshHeighCalculator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Mesh mesh;
    public float objectHeight;
    public Material mat;
    public int matIndex;
    void Start()
    {
        mesh=gameObject.GetComponent<MeshFilter>().mesh;
        mat = gameObject.GetComponent<MeshRenderer>().materials[matIndex];
    }

    // Update is called once per frame
    void Update()
    {
        objectHeight = mesh.bounds.size.y;
        mat.SetFloat("_height", objectHeight);
    }
}
