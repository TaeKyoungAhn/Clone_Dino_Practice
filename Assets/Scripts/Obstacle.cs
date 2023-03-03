using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge; //ȭ�� ���� �� ��ġ�� ���� ����

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;  
        //���� ī�޶��� ���� �ϴ��� Rect ������ 0,0 �� �ش��մϴ�! 
        //���� ������ ���� �ϴ� ���� x������ - 2��ŭ �� �־��ذſ���!
    }

    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime; // ��ֹ� ������Ʈ�� �������� GameSpeed�� ���Ѹ�ŭ �̵������.

        if(transform.position.x < leftEdge) // ��ֹ� ������Ʈ�� Left Edge�� �����ϸ�
        {
            Destroy(gameObject); // ��ֹ� ������Ʈ �ı�!
        }
    }

}
