using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int cardCount = 0;
    float time = 0.0f;
    public Text timeTxt;
    public GameObject endTxt;
    public Card firstCard;
    public Card secondCard;
    AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    private void Awake() //싱글톤
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time >= 30.0f)
        {
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx) // 같은 그림 삭제
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        else // 다른 그림 그대로 뒤집기
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        // 기존 정보 비워주기
        firstCard = null;
        secondCard = null;
    }
}
