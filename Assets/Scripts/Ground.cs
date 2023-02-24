using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Mesh Renderer 객체 선언
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x; // Game Manager 설정한 Speed 값과 현재 오브젝트의 가로 길이를 나눈 값
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime; //Texture의 오프셋 만큼 Ground 객체를 이어 붙임 
    }
}
