using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // default speed 
    public float speed = 15.0f;
    // bullet instance
    public GameObject Bulletprefab = null;
    public GameObject explosion = null;
    private Transform myTransform = null;


    // Start is called before the first frame update
    void Start()
    {
        // 트랜스폼 컴포넌트를 얻어온다
        myTransform = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        // 키보드 인풋값을 숫자 형태로 얻어온다
        // 왼쪽 : -1, 오른쪽 : 1
        // 길게 누르면 절댓값 1에 가까워진다. 떼면 점점 감소함
        float axis = Input.GetAxis("Horizontal");
        //Debug.Log("axis : " + axis);
        Vector3 moveAmount = axis * speed * -Vector3.right * Time.deltaTime;
        // 화면 밖으로 player가 나가는 것을 방지
        myTransform.Translate(moveAmount);
        Vector3 viewpos = Camera.main.WorldToViewportPoint(myTransform.position);
        viewpos.x = Mathf.Clamp01(viewpos.x);
        viewpos.y = Mathf.Clamp01(viewpos.y);
        Vector3 worldpos = Camera.main.ViewportToWorldPoint(viewpos);
        transform.position = worldpos;
        // shoot bullets
        if (Input.GetKeyDown(KeyCode.Space) == true)
            Instantiate(Bulletprefab, myTransform.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        // 적이 쏜 총알에 내가 맞을경우
        if (other.tag == "EnemyBullet")
        {
            MainControl.Life--;
            Instantiate(explosion, myTransform.position, Quaternion.identity);
            Destroy(other.gameObject);
            myTransform.position = new Vector3(0, -45, 0);
            // 초기 상태로 돌아가고 라이프 깎임
        }
    }
}
