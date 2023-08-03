using UnityEngine.Events;

public class EventAgregator 
{
    public static UnityEvent playerGetDamage = new UnityEvent();
    public static UnityEvent playerGetCoin = new UnityEvent();
    public static UnityEvent playerLostCoin = new UnityEvent();
    public static UnityEvent playerDead = new UnityEvent();
    public static UnityEvent UpdateUI = new UnityEvent();
    public static UnityEvent playerGetKey = new UnityEvent();
    public static UnityEvent playerLostKey = new UnityEvent();
    public static UnityEvent updateStorageUI = new UnityEvent();
    public static UnityEvent isPause = new UnityEvent();
    public static UnityEvent<int> updateScore = new UnityEvent<int>();
}
