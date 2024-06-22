using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
        // 배열 순서 랜덤으로 정렬(랜덤값과 접근값 비교하여 우선순위 두면서 정렬)
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
        for (int i = 0; i < 16; i++) // 16장 생성 위해 반복
        {
            GameObject go = Instantiate(card, this.transform); // 카드 생성
            float x = (i % 4) * 1.4f - 2.1f; // 나머지
            float y = (i / 4) * 1.4f - 3.0f; // 몫
            go.transform.position = new Vector2(x, y); // 정해진 위치, 간격으로 16장 카드 생성
            go.GetComponent<Card>().Setting(arr[i]); // 배열의 i번째 데이터 카드의 인덱스로 전송
            
        }
        GameManager.Instance.cardCount = arr.Length;
    }
}
