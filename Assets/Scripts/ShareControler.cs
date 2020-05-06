using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;

public class ShareControler : MonoBehaviour
{
    public string m_shareMessage;

    public string m_shareURL;

    public eShareOptions[] m_excludedOptions;

    void FinishedSharing(eShareResult _result)
    {
        Debug.Log("Finished sharing");
        Debug.Log("Share Result = " + _result);
    }

    public void ShareURLUsingShareSheet()
    {
        // Create share sheet
        ShareSheet _shareSheet = new ShareSheet();
        _shareSheet.Text = m_shareMessage;
        _shareSheet.URL = m_shareURL;

        // Set this list if you want to exclude any service/application type. Else, ignore.
        _shareSheet.ExcludedShareOptions = m_excludedOptions;

        // Attaching screenshot here
        _shareSheet.AttachScreenShot();

        // Show composer at last touch point
        NPBinding.UI.SetPopoverPointAtLastTouchPosition();
        NPBinding.Sharing.ShowView(_shareSheet, FinishedSharing);
    }
}
