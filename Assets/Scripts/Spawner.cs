using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject //�ϳ��� �������� ���� ��� ���� ����ü
    {
        public GameObject obstaclePrefab; //��ֹ� �������� ���� ����
        [Range(0f,1f)]
        public float spawnChance; //Spawn �ð� 
    }

    public SpawnableObject[] obstacleObjects; // ������Ʈ �迭 ����
}
