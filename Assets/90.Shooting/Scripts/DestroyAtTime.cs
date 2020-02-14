using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public float Time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Time 시간 경과 후 자동 파괴
        Destroy(gameObject, Time);   
    } 
}
