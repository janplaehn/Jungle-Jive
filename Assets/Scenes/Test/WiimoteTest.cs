using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class WiimoteTest : MonoBehaviour {
    bool wiimotesInitialized = false;
    static public List<Wiimote> wiimotes = new List<Wiimote>();
    int requestIndex = 0;
    const int requestRate = 4;
    InputCheck inputCheck;

    private void Start()
    {
        //CHANGE THIS LATER!!!!
        inputCheck = GetComponent<InputCheck>();
        WiimoteManager.FindWiimotes();
        int moteIndex = 0;
        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            wiimotes.Add(remote);
            remote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL);
            moteIndex++;
        }
        if (moteIndex > 0)
        {
            wiimotesInitialized = true;
            Wiimote rem = wiimotes[0];
            if(rem.RequestIdentifyWiiMotionPlus())
            rem.ActivateWiiMotionPlus();
            rem.RumbleOn = true;
            rem.SendPlayerLED(true, false, false, false);
            rem.SendStatusInfoRequest(); // Requests Status Report, encodes Rumble into input report
            Invoke("StopRumblePlayer1", 0.5f);
            wiimotesInitialized = true;
        } else
        {
            Debug.LogError("Couldn't find any wiimotes");
        }
    }

    void StopRumblePlayer1()
    {
        Wiimote rem = wiimotes[0];
        rem.RumbleOn = false; // Disabled Rumble
        rem.SendStatusInfoRequest(); // Requests Status Report, encodes Rumble into input report
    }

    
	
	// Update is called once per frame
	void Update ()
    {
        if (wiimotesInitialized)
        {
            requestIndex++;
            if (requestIndex == requestRate)
            {
                int wiiInfo;
                wiimotes[0].SendStatusInfoRequest();
                Debug.Log(wiimotes[0]);
                do
                {
                    wiiInfo = wiimotes[0].ReadWiimoteData();
                    
                } while (wiiInfo > 0);
                float a = wiimotes[0].Accel.GetAccelZeroPoints()[0];
                requestIndex = 0;
            }
        }        
	}

    private void OnApplicationQuit()
    {
        foreach (Wiimote r in wiimotes)
        {
            r.RumbleOn = false;
            r.SendPlayerLED(false, false, false, false);
            r.SendStatusInfoRequest();
        }
    }
}
