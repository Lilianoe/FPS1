using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class DamageEffect : MonoBehaviour
{
    public float intensity = 0f;

    PostProcessVolume _volume;
    Vignette _vignette;

    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if (!_vignette)
        {
            print("erreur : vignette non trouvée");
        }
        else
        {
            _vignette.enabled.Override(false);
        }
    }

    // Rendre cette méthode publique pour qu'elle soit accessible depuis PlayerController
    public IEnumerator TakeDamageEffect()
    {
        intensity = 0.4f; // Intensité initiale de l'effet

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(intensity);
        yield return new WaitForSeconds(0.4f);

        while (intensity > 0f)
        {
            intensity -= 0.01f;
            _vignette.intensity.Override(intensity);
            yield return new WaitForSeconds(0.01f);
        }

        _vignette.enabled.Override(false);
    }
}