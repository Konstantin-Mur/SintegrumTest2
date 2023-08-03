using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI coin;
    public TextMeshProUGUI key;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI score;

    private Storage _storage;
    private PlayerModel playerModel;

    public StorageUI storageUI;
    private void Awake()
    {
        _storage = FindObjectOfType<Storage>();
        playerModel = FindObjectOfType<PlayerModel>();
        playerHP.text = playerModel.HP.ToString();
        key.text = _storage.countKey.ToString();
        coin.text = _storage.countCoin.ToString();
        score.text = _storage.Score.ToString();

        storageUI.gameObject.SetActive(false);

        EventAgregator.UpdateUI.AddListener(UpdateUI);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            storageUI.gameObject.SetActive(true);
            EventAgregator.isPause.Invoke();
            EventAgregator.updateStorageUI.Invoke();
        }
    }
    private void UpdateUI()
    {
        key.text = _storage.countKey.ToString();
        coin.text = _storage.countCoin.ToString();
        playerHP.text = playerModel.HP.ToString();
        score.text = _storage.Score.ToString();
    }
}
