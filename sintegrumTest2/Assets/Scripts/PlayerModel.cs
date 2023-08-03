using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private int _hp = 5;

    public int HP => _hp;

    private void Awake()
    {
        EventAgregator.playerGetDamage.AddListener(PlayerLostHP);
    }

    public void PlayerLostHP()
    {
        _hp--;
        if (_hp <= 0)
        {
            EventAgregator.playerDead.Invoke();
        }
    }
}
