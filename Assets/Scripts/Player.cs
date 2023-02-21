using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character; //ĳ���͸� ��Ʈ���ϱ� ���� ������Ʈ ���� ����
    private Vector3 direction; //ĳ������ ��ġ���� ��������ֱ� ���� ���� ���� Vector3 = X, Y, Z 

    public float gravity = 9.18f * 2f; //�߷��� �ֱ����� ���� �� ����
    public float jumpForece = 8f; //�����ϴ� ���� ǥ���ϱ� ���� ���� �� ����

    void Awake() //���� ���� ����Ǵ� ����Ƽ�� �Լ�
    {
        character = GetComponent<CharacterController>(); //���ԵǾ��ִ� ������Ʈ�� �������� ����
    }

    private void OnEnable() //��ü�� Ȱ��ȭ �Ǿ��� ��, ȣ��Ǵ� �Լ�
    {
        direction = Vector3.zero; //��ġ �ʱ�ȭ = ���� ��ġ�� �⺻���� �д�.
    }

    void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime; // �߷� ���� �ֱ� ���� ����

        if(character.isGrounded) //ĳ���� ��Ʈ�ѷ��� �׶��忡 ������� ��, ������ �� �ִ� ���� ǥ��.
        {
            direction = Vector3.down; // Vector3.down == new vector3(0,-1,0)�� �ǹ̸� ������.
            if(Input.GetButton("Jump")) //Input System�� ������ Jump ��ư�� ������ ��!
            {
                direction = Vector3.up * jumpForece; // ĳ������ ��ġ�� Vector3.up == new vector3(0,1,0) �� ���ϱ� jumpForce
            }
        }
        character.Move(direction * Time.deltaTime); //���� isGround�� ���������������� Character Move!
    }
}
