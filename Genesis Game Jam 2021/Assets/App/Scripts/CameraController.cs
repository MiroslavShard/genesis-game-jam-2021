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
}