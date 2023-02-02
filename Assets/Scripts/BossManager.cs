using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    public ShellController shell;
    public BrainController brain;

    public void ShellHasBeenHit()
    {
        brain.SetAsVulnerable();
    }
}
