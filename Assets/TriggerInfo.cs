// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System;

using System.Collections;

[RequireComponent(typeof(Collider))]
public class TriggerInfo : MonoBehaviour, IGvrGazeResponder
{
    private Vector3 startingPosition;
    private bool firstEnterS1 = true;
    private bool firstEnterS2 = true;
    private bool firstEnterS3 = true;

    public static bool sd1, sd2, sd3, purchased;

    private DateTime start;

    private bool timerReady = false;
    public CountDown cD;

    public ShowDescription sD1;
    public ShowDescription sD2;
    public ShowDescription sD3;

    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
    }

    void Update()
    {
            if (cD.timeLeft < 6f&&firstEnterS2)
            {
                //Debug.Log("Show second = true");

                sD2.gameObject.SetActive(true);
                sD2.sDShow();
                firstEnterS2 = false;
        }
            if (cD.timeLeft < 3f && firstEnterS3)
            {
               // Debug.Log("Show third = true");
                
                sD3.gameObject.SetActive(true);
                sD3.sDShow();
                firstEnterS3 = false;

        }
    }

    void LateUpdate()
    {
        GvrViewer.Instance.UpdateState();
        if (GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            sD1.gameObject.SetActive(true);
            sD1.sDShow();

            //Debug.Log("gazedAt");


            if (firstEnterS1) {
                cD.Begin();
                firstEnterS1 = false;
            }
        }
        else {
            sD1.sDHide();
            sD2.sDHide();
            sD3.sDHide();
            cD.Stop();
            firstEnterS1 = true;
            firstEnterS2 = true;
            firstEnterS3 = true;

        }

        //if (gazedAt)
        //{

        //    if (firstEnter)
        //    {
        //        cD = new CountDown();
        //        firstEnter = false;
        //        timerReady = true;
        //    }
        //    else if (timerReady) if (cD.isFinished) OnGazeTrigger();
        //}
    }

    public void Reset()
    {
        transform.localPosition = startingPosition;
    }

    public void ToggleVRMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }

    public void ToggleDistortionCorrection()
    {
        switch (GvrViewer.Instance.DistortionCorrection)
        {
            case GvrViewer.DistortionCorrectionMethod.Unity:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Native;
                break;
            case GvrViewer.DistortionCorrectionMethod.Native:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.None;
                break;
            case GvrViewer.DistortionCorrectionMethod.None:
            default:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Unity;
                break;
        }
    }

    public void ToggleDirectRender()
    {
        GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
    }


    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        SetGazedAt(true);

    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {
        //TeleportRandomly();
        start = DateTime.Now;
        purchased = true;
        TriggerInfo.sd1 = false;
        TriggerInfo.sd2 = false;
        TriggerInfo.sd3 = false;
        if (cD.name.Equals("CodeItem1")) TriggerInfo.sd1 = true;
        if (cD.name.Equals("CodeItem2")) TriggerInfo.sd2 = true;
        if (cD.name.Equals("CodeItem3")) TriggerInfo.sd3 = true;

        // set obje
    }

    void OnGUI()
    {

        if (purchased)
        {
            if (DateTime.Now.Subtract(start).TotalSeconds < 10)
            {
                GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 300, 200, 300));
                GUILayout.Label("Purchase successful!");
                GUILayout.Label("Missing items have been added to your list");
                GUILayout.EndArea();

            }

            if (sd1)
            {
                GUILayout.BeginArea(new Rect(0, Screen.height - 150, 200, 300));
                GUILayout.Label("Bamboo skewers");
                GUILayout.Label("1 cucumber");
                GUILayout.Label("1 small onion");
                GUILayout.Label("Oil");
                GUILayout.EndArea();
            }
            if (sd2)
            {
                GUILayout.BeginArea(new Rect(0, Screen.height - 150, 200, 300));
                GUILayout.Label("Butter");
                GUILayout.Label("Garlic");
                GUILayout.Label("Salt");
                GUILayout.Label("Honey");
                GUILayout.Label("Thyme or parsley");
                GUILayout.EndArea();
            }
            if (sd3)
            {
                GUILayout.BeginArea(new Rect(0, Screen.height - 150, 200, 300));
                GUILayout.Label("Small red onion");
                GUILayout.Label("Roasted peanuts");
                GUILayout.Label("Salt");
                GUILayout.Label("Chopped cilantro");
                GUILayout.EndArea();
            }
        }
    }
    #endregion
}
