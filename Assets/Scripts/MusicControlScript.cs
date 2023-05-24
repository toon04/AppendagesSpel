      using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance; // Creates a static varible for a MusicControlScript instance

    private void Awake() // Runs before void Start()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
                   DontDestroyOnLoad(this.gameObject);
    }
}