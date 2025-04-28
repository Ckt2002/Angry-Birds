using System;

public interface IUIStar
{
    void Hide();
    void SetStar(EStarType starType);
    void Show(Action action);
}
