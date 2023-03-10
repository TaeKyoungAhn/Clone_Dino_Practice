using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public TextMeshProUGUI gameOverText; // GameOver Text 삽입
    public TextMeshProUGUI scoreText;  // Score Text 삽입
    public TextMeshProUGUI hiscoreText; //hiscore Text 삽입
    public Button retryButton;  // 재시작 버튼

    private Player player; // Player 스크립트
    private Spawner spawner; // Spawner 스크립트

    private float score; // Score 값

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
        player = FindObjectOfType<Player>(); //Player 데이터 타입을 찾아서 넣어줘요.
        spawner = FindObjectOfType<Spawner>(); // Spawner 데이터 타입을 찾아서 넣어줘요.

        NewGame();   // 처음 시작하면 새로운 게임의 스피드를 호출
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>(); //원래 있던 장애물들을 찾아서 다시 넣어줘요.

        foreach(var obstacle in obstacles) 
        {
            Destroy(obstacle.gameObject); //모든 장애물을 비워줘야해요.
        }

        gameSpeed = initialGameSpeed; // 기본 게임 스피드 
        score = 0f; //Score 초기화
        enabled = true; // 게임매니저를 활성화 시켜요.

        player.gameObject.SetActive(true); //Player 를 활성화 시켜요.
        spawner.gameObject.SetActive(true); // Spawner 를 활성화 시켜요.
        gameOverText.gameObject.SetActive(false); //Game Over Text 를 비활성화 시켜요.
        retryButton.gameObject.SetActive(false);  // Retry button 을 비활성화 시켜요.
    }
    
    public void GameOver() // 게임이 끝났다!
    {
        gameSpeed = 0f; //게임의 스피드를 초기화 시켜요.
        enabled = false; // 게임매니저를 비활성화 시켜요.

        player.gameObject.SetActive(false); // Player를 비활성화 시켜요.
        spawner.gameObject.SetActive(false); // Spawner를 비활성화 시켜요.
        gameOverText.gameObject.SetActive(true);  //Game Over Text 를 활성화 시켜요.
        retryButton.gameObject.SetActive(true);   //Retry button 을 활성화 시켜요.

        UpdateHiScore(); // 최고 스코어 반영!
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime; // 점점 속도를 올리자요!
        score += gameSpeed * Time.deltaTime; // 스코어도 같이 올라가요.
        scoreText.text = Mathf.FloorToInt(score).ToString("D5"); // score 텍스트에 Score의 값을 자릿수에 맞게 넣어줘요.
    }

    private void UpdateHiScore() // 최고 점수 확인 함수
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0); // PlayerPrefs는 데이터를 저장하는 함수에요. 
                                                            // 간단히 사용하기 편해요.
        if(score> hiscore) // 스코어가 HiScore 보다 높다면
        {
            hiscore = score; //HiScore에 Score 값 대입
            PlayerPrefs.SetFloat("hiscore", hiscore); // 데이터 저장
        }
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");// 자릿수를 맞추고 Hiscore 표현
    }
}
