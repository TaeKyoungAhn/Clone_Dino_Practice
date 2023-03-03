using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge; //화면 왼쪽 끝 위치를 넣을 변수

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;  
        //메인 카메라의 왼쪽 하단이 Rect 상으로 0,0 에 해당합니다! 
        //위의 내용은 왼쪽 하단 보다 x축으로 - 2만큼 더 넣어준거에요!
    }

    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime; // 장애물 오브젝트를 왼쪽으로 GameSpeed를 더한만큼 이동해줘요.

        if(transform.position.x < leftEdge) // 장애물 오브젝트가 Left Edge에 도착하면
        {
            Destroy(gameObject); // 장애물 오브젝트 파괴!
        }
    }

}
