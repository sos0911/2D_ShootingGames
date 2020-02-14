using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public float BulletSpeed = 75.0f;
    private Transform myTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = BulletSpeed * Vector3.down * Time.deltaTime;
        myTransform.Translate(moveAmount);

        // 화면 밖으로 나가게 되면 destroy 
        if (myTransform.position.y < -60.0f)
            Destroy(gameObject); // lowercase gameobject : 지금 이 스크립트가 붙어 있는 개체
    }
}
