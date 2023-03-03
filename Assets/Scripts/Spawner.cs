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

    public float minSpawnRate = 1f; // �ּ� Spawn �ð�
    public float maxSpawnRate = 2f; // �ִ� Spawn �ð�

    private void OnEnable() // ������Ʈ�� Ȱ��ȭ �Ǿ��� ��
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate)); // �����ð����� ��ֹ� Spawn
    }

    private void OnDisable() //������Ʈ�� ��Ȱ��ȭ �Ǿ��� ��
    {
        CancelInvoke(); //�������Լ��� ����!
    }

    /// <summary>
    /// 
    /// </summary>
    private void Spawn() //��ֹ� ���� �Լ�
    {
        float spawnChance = Random.value; // Random�� float ���� ����
        foreach(var obj in obstacleObjects) //��ֹ��� �ִ� ����ü�� �ݺ��Ͽ� Ȯ��!
        {
            if(spawnChance < obj.spawnChance) // Random�� ���� ��ֹ��� �ִ� ����ü�� ������ ������ ���� ��
            {
                GameObject obstacle = Instantiate(obj.obstaclePrefab); //�������� ����!
                obstacle.transform.position += transform.position;  //������ ������Ʈ!
                break; //�ൿ�� ������ foreach ���� ����������!
            }

            spawnChance -= obj.spawnChance; //Random������ ������ ���� ���ش�.
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));// ����Լ� : �ش� �Լ��� �ݺ��ϱ� ���� ��
    }

}
