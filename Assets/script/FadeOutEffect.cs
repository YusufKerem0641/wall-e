using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // Kaybolma süresi (saniye)

    private Renderer objectRenderer; // Nesnenin Renderer bileþeni

    public void play()
    {
        objectRenderer = GetComponent<Renderer>();

        // FadeOutEffect() metodunu baþlatan fonksiyonu çaðýrýyoruz.
        // Coroutine, nesnenin yavaþ yavaþ kaybolma etkisini oluþturacaktýr.
        StartCoroutine(FadeOutEffectCoroutine());
    }

    // Yavaþ yavaþ kaybolma iþlemini gerçekleþtiren Coroutine
    private IEnumerator FadeOutEffectCoroutine()
    {
        // Baþlangýç rengi ve son renk belirleme
        Color startColor = objectRenderer.material.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float elapsedTime = 0f;

        // Yavaþ yavaþ kaybolma döngüsü
        while (elapsedTime < fadeDuration)
        {
            // Yavaþ yavaþ renk deðiþimini hesapla
            objectRenderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);

            // Bir sonraki frame için bekle
            yield return null;

            // Zamaný güncelle
            elapsedTime += Time.deltaTime;
        }

        // Kaybolma süresi tamamlandýðýnda nesneyi yok et
        Destroy(gameObject);
    }
}
