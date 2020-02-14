using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    // 얻은 스코어와 가지고 있는 목숨을 출력
    static public int Score = 0;
    static public int Life = 3;
    public GUISkin mySkin = null;
    private bool Isend = false;
    private void OnGUI()
    {
        // skin edit
        GUI.skin = mySkin;
        Rect labelRect1 = new Rect(10.0f, 10.0f, 400.0f, 100.0f); // (x,y), 폭, 넓이
        GUI.Label(labelRect1, "SCORE : " + MainControl.Score);
        Rect labelRect2 = new Rect(10.0f, 110.0f, 400.0f, 100.0f);
        GUI.Label(labelRect2, "Life : " + MainControl.Life);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainControl.Score >= 500)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
        }
        if (MainControl.Life == 0 && !Isend)
        {
            Isend = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
