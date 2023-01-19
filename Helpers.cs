public static class Helpers
{
    static int trimLength = 45;
    public static void WithText(string text, string id, Action action, bool fixedSize = false)
    {
        if (fixedSize == false)
        {
            ImGui.SetNextItemWidth(ImGui.CalcTextSize("xd").X - 17f);
        } 
        ImGui.LabelText(text, "");
        ImGui.SameLine();
        ImGui.PushID(id);
        action();
        ImGui.PopID();
    }
    public static void CenteredText(string text)
    {
        var txt = text.Length > trimLength ? text.Substring(0, trimLength) + "..." : text;
        var WindowW = ImGui.GetWindowWidth();
        var textW = ImGui.CalcTextSize(txt).X;
        ImGui.SetCursorPosX((WindowW - textW) * 0.5f);
        ImGui.Text(txt);
    }
    public static string TimeFormat(int time) {
        string hr, min;
        min = Convert.ToString(time % 60);
        hr = Convert.ToString(time / 60);
        if (hr.Length == 1) hr = "0" + hr;
        if (min.Length == 1) min = "0" + min;
        return hr + ":" + min;
    }
}