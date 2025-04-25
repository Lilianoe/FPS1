using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTIme;
    

    // Update is called once per frame
    void Update()
    {
        if (remainingTIme > 0)
        {
            remainingTIme -= Time.deltaTime;
        }
        else if (remainingTIme < 0)
        {
            remainingTIme = 0;
            //respawn()
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTIme / 60);
        int seconds = Mathf.FloorToInt(remainingTIme % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
