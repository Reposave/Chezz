using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerTimerText;

    private float playerTimer;

    public float PlayerTimer
    {
        get => playerTimer;

        set 
        { 
            SetTimerText(value);
            playerTimer = value;
        }
    }

    public bool PauseTime { get; set; } = true;

    // Update is called once per frame
    void Update()
    {
        if (PauseTime)
        {
            return;
        }

        DecrementTimer(PlayerTimer);
    }

    private void DecrementTimer(float time)
    {
        time -= Time.deltaTime;
        PlayerTimer = time;
    }

    private void SetTimerText(float time)
    {
        if (playerTimerText == null)
        {
            return;
        }

        playerTimerText.text = ((int)time).ToString();
    }
}
