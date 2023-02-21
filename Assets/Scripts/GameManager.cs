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
        NewGame();   // ó�� �����ϸ� ���ο� ������ ���ǵ带 ȣ��
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed; // �⺻ ���� ���ǵ� 
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime; // ���� �ӵ��� �ø��ڿ�!
    }
}
