using UnityEngine;

public class TrapVisuals : MonoBehaviour
{
    [Header("Visual Settings")]
    public ParticleSystem fireEffect; // Reference to the Particle System

    private ParticleSystem.MainModule mainModule;
    private ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        if (fireEffect != null)
        {
            mainModule = fireEffect.main;
            emissionModule = fireEffect.emission;
        }
    }

    public void SetTrapActive(bool isActive)
    {
        if (fireEffect != null)
        {
            if (isActive)
            {
                mainModule = fireEffect.main;
                mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.red, Color.yellow);
                mainModule.startSize = 1.2f;

                emissionModule = fireEffect.emission;
                emissionModule.rateOverTime = 30f;

                fireEffect.Play();

            }
            else
            {
                mainModule = fireEffect.main;
                mainModule.startColor = new ParticleSystem.MinMaxGradient(Color.gray, new Color(0.5f, 0.5f, 0.5f, 0.2f));
                mainModule.startSize = 0.2f;

                emissionModule = fireEffect.emission;
                emissionModule.rateOverTime = 5f;

                fireEffect.Stop();
            }
        }
    }
}
