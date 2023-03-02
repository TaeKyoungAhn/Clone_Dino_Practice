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
        Invoke(nameof(Animate), 1f); // Animate 함수를 실행
    }

    private void Animate()
    {
        frame++; // 애니메이션 시간을 점점 늘려줘요.
        if(frame >= sprites.Length ) // frame 시간이 Sprite의 길이보다 크거나 같다면
        {
            frame = 0; //flame을 0으로 초기화 시켜줘요.
        }

        if (frame >= 0 && frame < sprites.Length) // 현재 frame 이 0보다 크거나 같고 sprite의 크기보다 작다면
        {
            spriteRenderer.sprite = sprites[frame]; // Sprite를 변경해줘요.
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed); // 반복적으로 수행할수 있게 Invoke 함수를 통해 수행합니다.
        //Invoke : Invoke("매서드 명", 지연 시키고 싶은 시간 + f) 
        //이렇게 특정 함수를 실행시키는 함수에요. 
        // 함수가 끝날때 지금 함수를 다시 한번 실행시켜주는 함수를 재귀 함수라고 합니다.
        // 반복적인 행동을 수행할 때 자주 사용해요.
    }
}
