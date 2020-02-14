using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontrol : MonoBehaviour
{
    public float EnemySpeed = 50.0f;
    private Transform myTransform = null;
    public GameObject explosion = null;
    public GameObject Bigexplosion = null;
    public GameObject Bulletprefab = null;
    private bool Isshooting = false;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        // 프레임당 몇개씩 총알을 쏴봄(제한됨)
        if (!Isshooting)
        {
            StartCoroutine("ShootandSleep");
        }
        Vector3 moveAmount = EnemySpeed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);
        // 화면 밖으로 가면 위로 다시 보내기(랜덤)
        if (myTransform.position.y < -50.0f)
        {
            InitPosition();
            // x축값을 random, y,z는 fixed
        }
    }
    /// <summary>
    /// 내 위치를 초기화하는 함수 
    /// </summary>
    IEnumerator ShootandSleep()
    {
        Isshooting = true;
        Instantiate(Bulletprefab, myTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Isshooting = false;
    }
    void InitPosition()
    {
        
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 50.0f, 0.0f);
       
    }
    // 나의 충돌체 영역에 트리거 설정이 된 other가 부딪혔을 때 발생되는 이벤트 함수
    private void OnTriggerEnter(Collider other)
    {
        // 총알이 맞은 경우
        if (other.tag == "Bullet")
        {
            // 총알 맞으면 점수 +100;
            MainControl.Score += 100;
            // 위치 재지정 전에 폭발함
            // 인스턴스화
            Instantiate(explosion, myTransform.position, Quaternion.identity);
            InitPosition();
            Destroy(other.gameObject);
            // 총알을 사라지게 함
        }
        // 플레이어와 충돌할 경우
        if (other.tag == "Player")
        {
            Debug.Log("confilcted");
            MainControl.Life--;
            Instantiate(Bigexplosion, myTransform.position, Quaternion.identity);
            InitPosition();
            // player는 초기 위치로 돌아감. life 깎이고
            other.transform.position=new Vector3(0, -45, 0);
        }

    }
}
