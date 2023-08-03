using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        EventAgregator.playerDead.AddListener(Reload);
    }

    private void Reload()
    {
        SceneManager.LoadScene(0);
    }
    
}
