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
}
