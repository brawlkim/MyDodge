using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태
    private bool isClear;   // 게임 클리어 유무 상태

    void Start()
    {
        surviveTime = 16f;
        isGameover = false;
    }

    void Update()
    {
        if(!isGameover)
        {
            // 생존 시간 갱신
            surviveTime -= Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
            if(surviveTime <= 0)
            {
                isGameover=true;
                PlayerController playerController = FindObjectOfType<PlayerController>();
                playerController.Die(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");      //R키 누르면 원래 씬으로 돌아가게, 이름에 8-puzzle 씬 넣으면 됩니다.
            }
        }
    }

    public bool EndGame(bool isClear)
    {
        // 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트를 활성화
        gameoverText.SetActive(true);
        //Debug.Log(isClear);
        return isClear;                 //isClear가 리턴값으로 넘어오면서, 미니게임 클리어 여부 판단 다른씬에서 사용해서 쓰면 됨.
    }
}
