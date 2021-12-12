using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    public PostProcessVolume m_volume;

    private Grain m_grain;
    private Vignette m_vignette;

    public void UpdateCameraEffect(float value)
    {
        m_volume.profile.TryGetSettings(out m_grain);
        m_grain.intensity.value = value;

        m_volume.profile.TryGetSettings(out m_vignette);
        m_vignette.intensity.value = (value >= 0.6f) ? 0.6f : value;
    }

    public void OnDamageTaken()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                StartCoroutine(PlayBleedingColors());
                break;

            case 1:
                StartCoroutine(PlayCorruptedVram());
                break;

            case 2:
                StartCoroutine(PlayUnsync());
                break;
        }
    }

    private bool m_bleedingColorsIsPlaying = false;

    private IEnumerator PlayBleedingColors()
    {
        if (!m_bleedingColorsIsPlaying)
        {
            m_bleedingColorsIsPlaying = true;
            GetComponent<ShaderEffect_BleedingColors>().enabled = true;
            GetComponent<ShaderEffect_BleedingColors>().intensity = Random.Range(10f, 100f);

            yield return new WaitForSeconds(Random.Range(0.25f, 1f));

            m_bleedingColorsIsPlaying = false;
            GetComponent<ShaderEffect_BleedingColors>().enabled = false;
        }
    }

    private bool m_corruptedVramIsPlaying = false;

    private IEnumerator PlayCorruptedVram()
    {
        if (!m_corruptedVramIsPlaying)
        {
            m_corruptedVramIsPlaying = true;
            GetComponent<ShaderEffect_CorruptedVram>().enabled = true;
            GetComponent<ShaderEffect_CorruptedVram>().shift = Random.Range(1f, 10f);

            yield return new WaitForSeconds(Random.Range(0.25f, 1f));

            m_corruptedVramIsPlaying = false;
            GetComponent<ShaderEffect_CorruptedVram>().enabled = false;
        }
    }

    private bool m_UnsyncIsPlaying = false;

    private IEnumerator PlayUnsync()
    {
        if (!m_UnsyncIsPlaying)
        {
            m_UnsyncIsPlaying = true;
            GetComponent<ShaderEffect_Unsync>().enabled = true;
            GetComponent<ShaderEffect_Unsync>().speed = -5f;

            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));

            m_UnsyncIsPlaying = false;
            GetComponent<ShaderEffect_Unsync>().enabled = false;
        }
    }
}