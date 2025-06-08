#if UNITY_EDITOR
using System.IO;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour
{
    public KeyCode screenshotKey = KeyCode.Q;
    public string screenshotFolder = "Screenshots";
    public string screenshotPrefix = "Screenshot_";
    public int superSize = 2;

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            CaptureScreenshot();
        }
    }

    private void CaptureScreenshot()
    {
        // Create Screenshots directory if it doesn't exist
        if (!Directory.Exists(screenshotFolder))
        {
            Directory.CreateDirectory(screenshotFolder);
        }

        // Generate filename with timestamp
        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string filename = $"{screenshotFolder}/{screenshotPrefix}{timestamp}.png";

        // Capture screenshot
        ScreenCapture.CaptureScreenshot(filename, superSize);
        Debug.Log($"Screenshot saved: {filename}");
    }

}
#endif