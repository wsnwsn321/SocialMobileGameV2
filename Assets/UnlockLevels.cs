using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels : MonoBehaviour
{
    private static string Target = "Unlock System";
    private UnlockLevel unlockSystem;
    private void Start()
    {
        unlockSystem = GameObject.Find(Target).GetComponent<UnlockLevel>();
    }
    public void callEndOfGame()
    {
        unlockSystem.endlevel();
    }
    public void callStarCollected()
    {
        unlockSystem.addHeartCount();
    }
}
