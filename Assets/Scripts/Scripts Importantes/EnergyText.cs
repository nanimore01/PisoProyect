using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class EnergyText : MonoBehaviour
{
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text timerText;
    private float rechargeTime = 3600f; // 1 hora

    void Update()
    {
        int energy = PlayerPrefs.GetInt("Energy", 5);
        energyText.text = $"{energy}/5";

        string lastTime = PlayerPrefs.GetString("LastEnergyTime", DateTime.Now.ToString());
        DateTime lastRecharge = DateTime.Parse(lastTime);
        TimeSpan timePassed = DateTime.Now - lastRecharge;
        float timeToNext = rechargeTime - (float)timePassed.TotalSeconds;

        if (energy < 5)
        {
            int minutes = (int)(timeToNext / 60);
            int seconds = (int)(timeToNext % 60);
            timerText.text = $"Próximo Permiso en: {minutes:D2}:{seconds:D2}";
        }
        else
        {
            timerText.text = "-";
        }
    }
}
