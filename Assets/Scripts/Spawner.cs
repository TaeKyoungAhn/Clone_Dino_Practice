using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject //하나에 여러가지 값을 담기 위한 구조체
    {
        public GameObject obstaclePrefab; //장애물 프리팹을 넣을 변수
        [Range(0f,1f)]
        public float spawnChance; //Spawn 시간 
    }

    public SpawnableObject[] obstacleObjects; // 오브젝트 배열 선언

    public float minSpawnRate = 1f; // 최소 Spawn 시간
    public float maxSpawnRate = 2f; // 최대 Spawn 시간

    private void OnEnable() // 오브젝트가 활성화 되었을 때
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate)); // 랜덤시간으로 장애물 Spawn
    }

    private void OnDisable() //오브젝트가 비활성화 되었을 때
    {
        CancelInvoke(); //딜레이함수를 종료!
    }

    /// <summary>
    /// 
    /// </summary>
    private void Spawn() //장애물 생성 함수
    {
        float spawnChance = Random.value; // Random의 float 값을 생성
        foreach(var obj in obstacleObjects) //장애물이 있는 구조체를 반복하여 확인!
        {
            if(spawnChance < obj.spawnChance) // Random의 값이 장애물이 있는 구조체에 설정한 값보다 작을 때
            {
                GameObject obstacle = Instantiate(obj.obstaclePrefab); //프리팹을 생성!
                obstacle.transform.position += transform.position;  //포지션 업데이트!
                break; //행동이 끝나면 foreach 문을 빠져나간다!
            }

            spawnChance -= obj.spawnChance; //Random값에서 설정한 값을 빼준다.
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));// 재귀함수 : 해당 함수를 반복하기 위한 것
    }

}
