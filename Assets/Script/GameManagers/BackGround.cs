using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        Vector2 offset = material.mainTextureOffset;
        offset.x = camera.transform.position.x / 2;
        material.mainTextureOffset = offset * Time.fixedDeltaTime;
    }
}
