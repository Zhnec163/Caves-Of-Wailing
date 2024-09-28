using System.Collections;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private int _intensity;

    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _intensity;
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        yield return new WaitForSeconds(_duration);
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
    }
}