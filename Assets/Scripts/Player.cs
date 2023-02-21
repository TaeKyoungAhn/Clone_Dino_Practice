using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character; //캐릭터를 컨트롤하기 위한 컴포넌트 변수 선언
    private Vector3 direction; //캐릭터의 위치값을 변경시켜주기 위한 변수 선언 Vector3 = X, Y, Z 

    public float gravity = 9.18f * 2f; //중력을 주기위한 변수 값 선언
    public float jumpForece = 8f; //점프하는 힘을 표현하기 위한 변수 값 선언

    void Awake() //가장 먼저 실행되는 유니티의 함수
    {
        character = GetComponent<CharacterController>(); //삽입되어있는 컴포넌트를 쓰기위한 세팅
    }

    private void OnEnable() //객체가 활성화 되었을 때, 호출되는 함수
    {
        direction = Vector3.zero; //위치 초기화 = 현재 위치를 기본으로 둔다.
    }

    void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime; // 중력 값을 주기 위한 계산식

        if(character.isGrounded) //캐릭터 컨트롤러가 그라운드에 닿아있을 때, 실행할 수 있는 것을 표현.
        {
            direction = Vector3.down; // Vector3.down == new vector3(0,-1,0)의 의미를 가진다.
            if(Input.GetButton("Jump")) //Input System에 설정된 Jump 버튼을 눌렀을 때!
            {
                direction = Vector3.up * jumpForece; // 캐릭터의 위치를 Vector3.up == new vector3(0,1,0) 에 곱하기 jumpForce
            }
        }
        character.Move(direction * Time.deltaTime); //현재 isGround를 실행하지않을때는 Character Move!
    }
}
