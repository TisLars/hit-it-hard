using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour
{
    private Vector3 originPosition;
    private Quaternion originRotation;

    public float originalDecay = 0.006f;
    public float originalIntensity = 0.04f;
    float shakeDecay;
    float shakeIntensity;
    private bool isShaking;
    Transform cameraTransform;

    void OnLevelWasLoaded()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (!isShaking)
            return;

        if (shakeIntensity > 0f)
        {
            cameraTransform.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            cameraTransform.localRotation = new Quaternion(
            originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
            originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
            originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
            originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .2f);
            shakeIntensity -= shakeDecay;
        }

        else
        {
            isShaking = false;
            cameraTransform.localPosition = originPosition;
            cameraTransform.localRotation = originRotation;
        }
    }

    public void Shake()
    {
        if (!isShaking)
        {
            originPosition = cameraTransform.localPosition;
            originRotation = cameraTransform.localRotation;
        }

        isShaking = true;
        shakeIntensity = originalIntensity;
        shakeDecay = originalDecay;
    }
}