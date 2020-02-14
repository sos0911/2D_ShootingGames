using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public float ScrollSpeed = 0.1f;
    public Renderer MyRenderer = null;

    // Start is called before the first frame update
    void Start()
    {
        MyRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // meshrender의 material offset값을 새로 세팅
        // 매 프레임마다
        MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(0.0f, -Time.time * ScrollSpeed));
    }
}
