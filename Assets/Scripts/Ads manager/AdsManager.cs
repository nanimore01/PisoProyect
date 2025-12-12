using UnityEngine;
using UnityEngine.Advertisements;
using System.Threading.Tasks; // Necesario para usar async/await

//public class AdsManager : MonoBehaviour
//{
//    private string gameId = "5788114"; // 🔹 Reemplaza con tu Game ID
//    private bool testMode = true; // 🔹 Ponlo en false para producción

//    void Start()
//    {
//        Advertisement.Initialize(gameId, testMode);
//    }

//    // 📌 Mostrar anuncio intersticial (entre niveles, tras morir, etc.)
//    public async void ShowInterstitialAd()
//    {
//        if (Advertisement.isInitialized && Advertisement.isSupported)
//        {
//            try
//            {
//                await Advertisement.Show("Interstitial_Android");
//                Debug.Log("✅ Anuncio intersticial mostrado.");
//            }
//            catch (System.Exception e)
//            {
//                Debug.LogError($"❌ Error al mostrar el anuncio: {e.Message}");
//            }
//        }
//        else
//        {
//            Debug.LogWarning("❌ Unity Ads no está inicializado o no es compatible.");
//        }
//    }

//    // 📌 Mostrar anuncio recompensado (para obtener monedas, vidas, etc.)
//    public async void ShowRewardedAd()
//    {
//        if (Advertisement.isInitialized && Advertisement.isSupported)
//        {
//            try
//            {
//                var result = await Advertisement.ShowAsync("Rewarded_Android");

//                if (result == Unity.Services.Mediation.ShowResult.Finished)
//                {
//                    Debug.Log("✅ Anuncio recompensado visto. Otorgando recompensa.");
//                    GiveReward();
//                }
//                else if (result == Unity.Services.Mediation.ShowResult.Skipped)
//                {
//                    Debug.Log("⚠️ Anuncio saltado. No se otorga recompensa.");
//                }
//                else
//                {
//                    Debug.LogError("❌ Error al mostrar el anuncio recompensado.");
//                }
//            }
//            catch (System.Exception e)
//            {
//                Debug.LogError($"❌ Error al mostrar el anuncio: {e.Message}");
//            }
//        }
//        else
//        {
//            Debug.LogWarning("❌ Unity Ads no está inicializado o no es compatible.");
//        }
//    }

//    private void GiveReward()
//    {
//        Debug.Log("🎁 +100 monedas otorgadas.");
//        // 🔹 Aquí puedes sumar monedas, energía o vidas al jugador
//    }
//}




