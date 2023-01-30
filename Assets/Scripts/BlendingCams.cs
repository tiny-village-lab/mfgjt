using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendingCams : MonoBehaviour
{
    public GameObject[] cams;

    private void Start()
    {
        cams = new GameObject[2];
    }
    public void blendCams(int camOut, int camIn)
    {
        cams[camOut-1].SetActive(false);
        cams[camIn-1].SetActive(true);
    }
}
