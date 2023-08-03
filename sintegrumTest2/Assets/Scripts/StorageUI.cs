using TMPro;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI keyCount;
    public TextMeshProUGUI score;

    private Storage _storage;

    void Start()
    {
        _storage = FindObjectOfType<Storage>();
        coinCount.text = _storage.countCoin.ToString();
        keyCount.text = _storage.countKey.ToString();
        score.text = _storage.Score.ToString();

        EventAgregator.updateStorageUI.AddListener(UpdateStorageUI);
    }

    public void UpdateStorageUI()
    {
        coinCount.text = _storage.countCoin.ToString();
        keyCount.text = _storage.countKey.ToString();
        score.text = _storage.Score.ToString();
    }
}
