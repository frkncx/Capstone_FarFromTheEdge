using Unity.Cinemachine;
using UnityEngine;

public class CinemachineCamera : MonoBehaviour
{
    [Header("CAMERA")]
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startIntensity;


    #region Camera
    private void Awake()
    {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;

        startIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;

    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
                Mathf.Lerp(startIntensity, 0f, (1 - (shakeTimer / shakeTimerTotal)));
            }
        }
    }
}
