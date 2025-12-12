using UnityEngine;
using System;
using Unity.Notifications.Android;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 5; // Máximo de cargas de energía
    [SerializeField] private float rechargeTime = 3600f; // 1 hora en segundos
    private int currentEnergy;

    private const string ENERGY_KEY = "Energy";
    private const string LAST_ENERGY_TIME_KEY = "LastEnergyTime";

    void Start()
    {
        LoadEnergy();
        InvokeRepeating("CheckEnergy", 1f, 10f); // Verifica cada 10 segundos
    }

    public void LoadEnergy()
    {
        // Cargar la energía almacenada
        currentEnergy = PlayerPrefs.GetInt(ENERGY_KEY, maxEnergy);

        // Verificar cuánto tiempo ha pasado desde la última carga
        if (currentEnergy < maxEnergy)
        {
            string lastTime = PlayerPrefs.GetString(LAST_ENERGY_TIME_KEY, "");
            if (!string.IsNullOrEmpty(lastTime))
            {
                DateTime lastRecharge = DateTime.Parse(lastTime);
                TimeSpan timePassed = DateTime.Now - lastRecharge;

                int energyToRecover = (int)(timePassed.TotalSeconds / rechargeTime);
                currentEnergy = Mathf.Min(currentEnergy + energyToRecover, maxEnergy);
            }
        }

        SaveEnergy();
    }

    public void CheckEnergy()
    {
        if (currentEnergy < maxEnergy)
        {
            string lastTime = PlayerPrefs.GetString(LAST_ENERGY_TIME_KEY, DateTime.Now.ToString());
            DateTime lastRecharge = DateTime.Parse(lastTime);
            TimeSpan timePassed = DateTime.Now - lastRecharge;

            if (timePassed.TotalSeconds >= rechargeTime)
            {
                currentEnergy++;
                SaveEnergy();
            }
        }
        else if(currentEnergy == maxEnergy)
        {
            EnviarNotificacionCargasCompletas();
        }
    }
    public void EnviarNotificacionCargasCompletas()
    {
        // Crear la notificación
        var notification = new AndroidNotification();
        notification.Title = "¡Permisos de compra al maximo!";
        notification.Text = "Ya podes comprar todo lo que quieras";
        notification.FireTime = System.DateTime.Now; // Enviar inmediatamente

        // Enviar la notificación
        AndroidNotificationCenter.SendNotification(notification, "carga_completa_channel");
    }
    public void UseEnergy()
    {
        if (currentEnergy > 0)
        {
            currentEnergy--; 
            SaveEnergy(); 
        }
        else
        {
            
        }
    }

    void SaveEnergy()
    {
        PlayerPrefs.SetInt(ENERGY_KEY, currentEnergy);
        PlayerPrefs.SetString(LAST_ENERGY_TIME_KEY, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    public void RechargeEnergy()
    {
        currentEnergy = maxEnergy;
        SaveEnergy();
        
    }
}
