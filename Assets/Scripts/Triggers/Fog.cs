using System.Collections;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public Material fogMaterial;
    public float fadeDuration = 4f;
    public GameObject blockPath;

    private bool hasStartedFading = false;

    void Update()
    {
        // Start fade when Sight is unlocked
        if (GameManager.Instance.SightAbilityUnlocked && !hasStartedFading)
        {
            blockPath.SetActive(false);
            hasStartedFading = true;
        }

        if (hasStartedFading)
        {
            Color c = fogMaterial.color;
            float newAlpha = c.a - (Time.deltaTime / fadeDuration);
            c.a = Mathf.Clamp01(newAlpha);
            fogMaterial.color = c;

            // Stop if fully invisible
            if (c.a <= 0f)
                hasStartedFading = false;
        }

        if (!GameManager.Instance.SightAbilityUnlocked)
        {
            Color c = fogMaterial.color;
            float newAlpha = c.a + (Time.deltaTime / fadeDuration);
            c.a = Mathf.Clamp01(newAlpha);
            fogMaterial.color = c;
        }
    }
}
