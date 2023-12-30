using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score;

    public bool isRewarded;

    public int gamePlayed = 1;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(DisplayBannerWithDelay());
    }

    private IEnumerator DisplayBannerWithDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    private void Update()
    {
        if(score < 0)
        {
            score = 0;
            AdsManager.Instance.bannerAds.HideBannerAd();
            SceneManager.LoadScene("EndScene");
            if (gamePlayed % 3 == 0)
            {
                AdsManager.Instance.interstitialAds.ShowInterstitialAd();
            }
        }
        else if( score > 10)
        {
            score = 10;
            AdsManager.Instance.bannerAds.HideBannerAd();
            SceneManager.LoadScene("EndScene");

            if(gamePlayed %3== 0)
            {
                AdsManager.Instance.interstitialAds.ShowInterstitialAd();
            }
        }
    }

    public void RestartGame()
    {
        score = 0;
        gamePlayed++;
        AdsManager.Instance.bannerAds.ShowBannerAd();
        SceneManager.LoadScene("GamePlay");
    }

    public void MultiplyScore()
    {

    }

    public void AddScore()
    {
        score++;

    }

    public void MinusScore()
    {
        score--;
    }
}
