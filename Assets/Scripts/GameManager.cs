using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //게임매니저는 게임 전반의 값들을 저장해놓고 다른 곳에서 가져다 쓸수 있어야해요.
    //static 키워드는 컴퓨터의 메모리란 곳에 적재해놓고 모든 곳에서 사용할 수 있도록 만들어요.
    //instance 에 get, set은 property라는 속성을 지칭하는 말입니다.
    //get은 값을 가져올 수 있고, set은 값을 설정할 수 있어요.
    //아래 줄을 간단히 얘기하면 어디든 게임매니저를 호출할 수 있지만 setting은 게임매니저에서만 해!
    //라는 말과 같아요.
   public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f; // 처음 시작시 게임 스피드
    public float gameSpeedIncrease = 0.1f; // 게임 스피드를 점점 높이도록 하기 위한 변수[난이도 조절용]
    public float gameSpeed { get; private set; } // 게임의 스피드를 호출할 수 있게 프로퍼티로 선언!

    private void Awake()// 게임을 처음 셋팅할 때
    {
        if(Instance == null) //게임매니저가 없으면!
        {
            Instance = this; // 이 클래스를 Instance 안에 대입해요.
        }
        else
        {
            DestroyImmediate(gameObject); //있으면 게임 오브젝트를 파괴합니다.
            // 게임매니저가 여러 개 생성되는 것을 방지하기 위함이에요.
        }
    }

    private void OnDestroy() // 게임 오브젝트가 파괴될 때
    {
        if(Instance == this) // 현재 오브젝트가 Instance로 할당되어 있다면 
        {
            Instance = null; // Instance를 비운다.
        }
    }

    public void Start()
    {
        NewGame();   // 처음 시작하면 새로운 게임의 스피드를 호출
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed; // 기본 게임 스피드 
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime; // 점점 속도를 올리자요!
    }
}
