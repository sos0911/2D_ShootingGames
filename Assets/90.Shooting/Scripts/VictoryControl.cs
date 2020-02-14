using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryControl : MonoBehaviour
{
    private void OnGUI()
    {
        float CenterX = Screen.width * 0.5f;
        float CenterY = Screen.height * 0.5f;
        Rect ButtonRect = new Rect(CenterX - 100.0f, CenterY - 100.0f, 200.0f, 200.0f);
        // 이 버튼을 클릭하면 if문에 걸리게 됨
        if(GUI.Button(ButtonRect, "You WIN!") == true)
        {
            MainControl.Score = 0;
            MainControl.Life = 3;
            SceneManager.LoadScene("Level1");
        }
    }
}
