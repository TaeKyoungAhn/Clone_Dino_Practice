using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //���ӸŴ����� ���� ������ ������ �����س��� �ٸ� ������ ������ ���� �־���ؿ�.
    //static Ű����� ��ǻ���� �޸𸮶� ���� �����س��� ��� ������ ����� �� �ֵ��� ������.
    //instance �� get, set�� property��� �Ӽ��� ��Ī�ϴ� ���Դϴ�.
    //get�� ���� ������ �� �ְ�, set�� ���� ������ �� �־��.
    //�Ʒ� ���� ������ ����ϸ� ���� ���ӸŴ����� ȣ���� �� ������ setting�� ���ӸŴ��������� ��!
    //��� ���� ���ƿ�.
   public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f; // ó�� ���۽� ���� ���ǵ�
    public float gameSpeedIncrease = 0.1f; // ���� ���ǵ带 ���� ���̵��� �ϱ� ���� ����[���̵� ������]
    public float gameSpeed { get; private set; } // ������ ���ǵ带 ȣ���� �� �ְ� ������Ƽ�� ����!

    private Player player; // Player ��ũ��Ʈ
    private Spawner spawner; // Spawner ��ũ��Ʈ

    private void Awake()// ������ ó�� ������ ��
    {
        if(Instance == null) //���ӸŴ����� ������!
        {
            Instance = this; // �� Ŭ������ Instance �ȿ� �����ؿ�.
        }
        else
        {
            DestroyImmediate(gameObject); //������ ���� ������Ʈ�� �ı��մϴ�.
            // ���ӸŴ����� ���� �� �����Ǵ� ���� �����ϱ� �����̿���.
        }
    }

    private void OnDestroy() // ���� ������Ʈ�� �ı��� ��
    {
        if(Instance == this) // ���� ������Ʈ�� Instance�� �Ҵ�Ǿ� �ִٸ� 
        {
            Instance = null; // Instance�� ����.
        }
    }

    public void Start()
    {
        player = FindObjectOfType<Player>(); //Player ������ Ÿ���� ã�Ƽ� �־����.
        spawner = FindObjectOfType<Spawner>(); // Spawner ������ Ÿ���� ã�Ƽ� �־����.

        NewGame();   // ó�� �����ϸ� ���ο� ������ ���ǵ带 ȣ��
    }

    private void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>(); //���� �ִ� ��ֹ����� ã�Ƽ� �ٽ� �־����.

        foreach(var obstacle in obstacles) 
        {
            Destroy(obstacle.gameObject); //��� ��ֹ��� �������ؿ�.
        }

        gameSpeed = initialGameSpeed; // �⺻ ���� ���ǵ� 
        enabled = true; // ���ӸŴ����� Ȱ��ȭ ���ѿ�.

        player.gameObject.SetActive(true); //Player �� Ȱ��ȭ ���ѿ�.
        spawner.gameObject.SetActive(true); // Spawner �� Ȱ��ȭ ���ѿ�.
    }
    
    public void GameOver() // ������ ������!
    {
        gameSpeed = 0f; //������ ���ǵ带 �ʱ�ȭ ���ѿ�.
        enabled = false; // ���ӸŴ����� ��Ȱ��ȭ ���ѿ�.

        player.gameObject.SetActive(false); // Player�� ��Ȱ��ȭ ���ѿ�.
        spawner.gameObject.SetActive(false); // Spawner�� ��Ȱ��ȭ ���ѿ�.
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime; // ���� �ӵ��� �ø��ڿ�!
    }
}
