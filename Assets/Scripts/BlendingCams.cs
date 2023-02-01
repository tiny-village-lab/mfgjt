using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class BlendingCams : MonoBehaviour
{
    public GameObject[] cams;


    public void blendCams(int camOut, int camIn)
    {
        cams[camOut-1].SetActive(false);
        cams[camIn-1].SetActive(true);
    }

    public void ShakeCamera(int cam, float intensity, float duration)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cams[cam - 1].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

        StartCoroutine(ResetAmplitude(cam, duration));
    }

    IEnumerator ResetAmplitude(int cam, float duration)
    {
        yield return new WaitForSeconds(duration);
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cams[cam - 1].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        yield return null;
    }

}
