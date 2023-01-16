using System;
#if UNITY_EDITOR // Note that without this pre-processors any build will fail
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

// ExecuteInEditMode makes this component also execute if not in PlayMode
[ExecuteInEditMode]
public class timeLogger : MonoBehaviour
{

    //public void Start()
    //{
    //    Debug.Log(Time.timeSinceLevelLoad);
    //}
    // public only for debugging
    public long playButtonTime;
    public long startTime;

#if UNITY_EDITOR

    private void OnEnable()
    {
        // Register to the playModestaeChanged event
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private void OnDisable()
    {
        // Unregister from the playModeStateChanged event
        EditorApplication.playModeStateChanged -= OnPlayModeChanged;
    }

    private void OnPlayModeChanged(PlayModeStateChange stateChange)//uses switch case to turn on or off relevent time counters for 
    {
        switch (stateChange)
        {
            case PlayModeStateChange.ExitingEditMode:
                // save the system time when leaving the edit mode
                playButtonTime = DateTime.Now.Ticks;
                break;

            case PlayModeStateChange.EnteredPlayMode:
                // save and compare the system time when entering play mode
                startTime = DateTime.Now.Ticks;
                var difference = (startTime - playButtonTime) / TimeSpan.TicksPerMillisecond;

                Debug.Log("Load Time for " + SceneManager.GetActiveScene().name + " was: " + difference + "ms", this);
                break;
        }
    }

#endif
}

