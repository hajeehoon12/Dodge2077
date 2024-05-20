using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private float offset; // pos of material
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        meshRenderer.material.mainTextureOffset = new Vector3(0, offset, -30);
    }
}
