using UnityEngine;

public class UIQuitBtn : UIButton
{
    public override void Action()
    {
        Application.Quit();
    }
}
