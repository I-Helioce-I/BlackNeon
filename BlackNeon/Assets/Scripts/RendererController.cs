using Cyan;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RendererController : MonoBehaviour
{

    [SerializeField]
    UniversalRendererData rendererData;

    [SerializeField]
    Material[] materials;

    private void Start()
    {
        DisableEffect();
    }

    public void SetUpMaterial(int materialToSet)
    {
        var blit = rendererData.rendererFeatures.OfType<Blit>().FirstOrDefault();
        blit.SetActive(true);

        blit.settings.blitMaterial = materials[materialToSet];

        rendererData.SetDirty();
    }

    public void DisableEffect()
    {
        var blit = rendererData.rendererFeatures.OfType<Blit>().FirstOrDefault();
        blit.SetActive(false);

        rendererData.SetDirty();
    }
}
