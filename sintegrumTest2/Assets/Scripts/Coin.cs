using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventAgregator.playerGetCoin.Invoke();
            EventAgregator.updateScore.Invoke(50);

            Destroy(this.gameObject);
        }
    }
}
