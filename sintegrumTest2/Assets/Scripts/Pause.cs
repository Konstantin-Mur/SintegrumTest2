using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Awake()
    {
        EventAgregator.isPause.AddListener(OnPause);
    }

    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void OffPause()
    {
        Time.timeScale = 1;
    }
}
