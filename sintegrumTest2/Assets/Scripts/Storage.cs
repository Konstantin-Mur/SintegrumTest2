using UnityEngine;

public class Storage : MonoBehaviour
{
    public int countCoin;
    public int countKey;

    public int Score;

    private void Awake()
    {
        EventAgregator.playerGetCoin.AddListener(AddCoin);
        EventAgregator.playerGetKey.AddListener(AddKey);
        EventAgregator.playerLostCoin.AddListener(RemoveCoin);
        EventAgregator.playerLostKey.AddListener(RemoveKey);
        EventAgregator.updateScore.AddListener(UpdateScore);
    }
    public void AddCoin()
    {
        countCoin++;
        EventAgregator.UpdateUI.Invoke();
    }

    public void AddKey()
    {
        countKey++;
        EventAgregator.UpdateUI.Invoke();
    }

    public void RemoveKey()
    {
        if (countKey > 0)
        {
            countKey--;
        }
        EventAgregator.UpdateUI.Invoke();
    }

    public void RemoveCoin()
    {
        if (countCoin > 0)
        {
            countCoin--;
        }
        EventAgregator.UpdateUI.Invoke();
    }

    public void UpdateScore(int score)
    {
        Score += score;
    }
}
