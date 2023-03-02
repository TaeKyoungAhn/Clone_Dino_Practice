using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 1f); // Animate �Լ��� ����
    }

    private void Animate()
    {
        frame++; // �ִϸ��̼� �ð��� ���� �÷����.
        if(frame >= sprites.Length ) // frame �ð��� Sprite�� ���̺��� ũ�ų� ���ٸ�
        {
            frame = 0; //flame�� 0���� �ʱ�ȭ �������.
        }

        if (frame >= 0 && frame < sprites.Length) // ���� frame �� 0���� ũ�ų� ���� sprite�� ũ�⺸�� �۴ٸ�
        {
            spriteRenderer.sprite = sprites[frame]; // Sprite�� ���������.
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed); // �ݺ������� �����Ҽ� �ְ� Invoke �Լ��� ���� �����մϴ�.
        //Invoke : Invoke("�ż��� ��", ���� ��Ű�� ���� �ð� + f) 
        //�̷��� Ư�� �Լ��� �����Ű�� �Լ�����. 
        // �Լ��� ������ ���� �Լ��� �ٽ� �ѹ� ��������ִ� �Լ��� ��� �Լ���� �մϴ�.
        // �ݺ����� �ൿ�� ������ �� ���� ����ؿ�.
    }
}
