using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Mesh Renderer ��ü ����
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x; // Game Manager ������ Speed ���� ���� ������Ʈ�� ���� ���̸� ���� ��
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime; //Texture�� ������ ��ŭ Ground ��ü�� �̾� ���� 
    }
}