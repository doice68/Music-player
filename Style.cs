using System.Numerics;
using ImGuiNET;

public static class MyStyle
{
public static void SetupImGuiStyle()
{
	// v style from ImThemes
	var style = ImGuiNET.ImGui.GetStyle();
	
	style.Alpha = 1f;
	style.DisabledAlpha = 0.300000011920929f;
	style.WindowPadding = new Vector2(7.199999809265137f, 8.0f);
	style.WindowRounding = 12f;
	style.WindowBorderSize = 0.0f;
	style.WindowMinSize = new Vector2(32.0f, 32.0f);
	style.WindowTitleAlign = new Vector2(0.0f, 0.5f);
	style.WindowMenuButtonPosition = ImGuiDir.Left;
	style.ChildRounding = 6.5f;
	style.ChildBorderSize = 1.0f;
	style.PopupRounding = 0.0f;
	style.PopupBorderSize = 0.0f;
	style.FramePadding = new Vector2(14.0f, 5.900000095367432f);
	style.FrameRounding = 5.0f;
	style.FrameBorderSize = 0.0f;
	style.ItemSpacing = new Vector2(3.799999952316284f, 4.599999904632568f);
	style.ItemInnerSpacing = new Vector2(4.0f, 4.0f);
	style.CellPadding = new Vector2(4.0f, 2.0f);
	style.IndentSpacing = 21.0f;
	style.ColumnsMinSpacing = 6.0f;
	style.ScrollbarSize = 10.0f;
	style.ScrollbarRounding = 3.099999904632568f;
	style.GrabMinSize = 10.60000038146973f;
	style.GrabRounding = 2.599999904632568f;
	style.TabRounding = 8.100000381469727f;
	style.TabBorderSize = 0.0f;
	style.TabMinWidthForCloseButton = 0.0f;
	style.ColorButtonPosition = ImGuiDir.Right;
	style.ButtonTextAlign = new Vector2(0.5f, 0.5f);
	style.SelectableTextAlign = new Vector2(0.0f, 0.0f);
	
	style.Colors[(int)ImGuiCol.Text] = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
	style.Colors[(int)ImGuiCol.TextDisabled] = new Vector4(0.4980392158031464f, 0.4980392158031464f, 0.4980392158031464f, 1.0f);
	style.Colors[(int)ImGuiCol.WindowBg] = new Vector4(9.999899930335232e-07f, 9.999919257097645e-07f, 9.999999974752427e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.ChildBg] = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
	style.Colors[(int)ImGuiCol.PopupBg] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.Border] = new Vector4(0.06089630350470543f, 0.0663527324795723f, 0.1244634985923767f, 1.0f);
	style.Colors[(int)ImGuiCol.BorderShadow] = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
	style.Colors[(int)ImGuiCol.FrameBg] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 0.3175965547561646f);
	style.Colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 0.3176470696926117f);
	style.Colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 0.7682403326034546f);
	style.Colors[(int)ImGuiCol.TitleBg] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.TitleBgActive] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999946541938698e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.TitleBgCollapsed] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999899930335232e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.MenuBarBg] = new Vector4(9.999999974752427e-07f, 9.999899930335232e-07f, 9.999960184359225e-07f, 1.0f);
	style.Colors[(int)ImGuiCol.ScrollbarBg] = new Vector4(0.06089630350470543f, 0.0663527324795723f, 0.1244634985923767f, 1.0f);
	style.Colors[(int)ImGuiCol.ScrollbarGrab] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.ScrollbarGrabHovered] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 1.0f);
	style.Colors[(int)ImGuiCol.ScrollbarGrabActive] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.CheckMark] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 1.0f);
	style.Colors[(int)ImGuiCol.SliderGrab] = new Vector4(0.407843142747879f, 0.3098039329051971f, 1.0f, 1.0f);
	style.Colors[(int)ImGuiCol.SliderGrabActive] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 1.0f);
	style.Colors[(int)ImGuiCol.Button] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 1.0f);
	style.Colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.Header] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.HeaderHovered] = new Vector4(0.4235294163227081f, 0.2196078449487686f, 0.9647058844566345f, 1.0f);
	style.Colors[(int)ImGuiCol.HeaderActive] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.Separator] = new Vector4(0.09442061185836792f, 0.09441966563463211f, 0.09442023187875748f, 1.0f);
	style.Colors[(int)ImGuiCol.SeparatorHovered] = new Vector4(0.09442061185836792f, 0.09441966563463211f, 0.09442023187875748f, 1.0f);
	style.Colors[(int)ImGuiCol.SeparatorActive] = new Vector4(0.09442061185836792f, 0.09441966563463211f, 0.09442023187875748f, 1.0f);
	style.Colors[(int)ImGuiCol.ResizeGrip] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.ResizeGripHovered] = new Vector4(0.4245694577693939f, 0.2196577787399292f, 0.9656652212142944f, 1.0f);
	style.Colors[(int)ImGuiCol.ResizeGripActive] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.Tab] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.TabHovered] = new Vector4(0.4245694577693939f, 0.2196577787399292f, 0.9656652212142944f, 1.0f);
	style.Colors[(int)ImGuiCol.TabActive] = new Vector4(0.4245694577693939f, 0.2196577787399292f, 0.9656652212142944f, 1.0f);
	style.Colors[(int)ImGuiCol.TabUnfocused] = new Vector4(0.06666667014360428f, 0.1019607856869698f, 0.1450980454683304f, 0.9724000096321106f);
	style.Colors[(int)ImGuiCol.TabUnfocusedActive] = new Vector4(0.1333333402872086f, 0.2588235437870026f, 0.4235294163227081f, 1.0f);
	style.Colors[(int)ImGuiCol.PlotLines] = new Vector4(0.6078431606292725f, 0.6078431606292725f, 0.6078431606292725f, 1.0f);
	style.Colors[(int)ImGuiCol.PlotLinesHovered] = new Vector4(1.0f, 0.4274509847164154f, 0.3490196168422699f, 1.0f);
	style.Colors[(int)ImGuiCol.PlotHistogram] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.PlotHistogramHovered] = new Vector4(0.4245694577693939f, 0.2196577787399292f, 0.9656652212142944f, 1.0f);
	style.Colors[(int)ImGuiCol.TableHeaderBg] = new Vector4(0.1882352977991104f, 0.1882352977991104f, 0.2000000029802322f, 1.0f);
	style.Colors[(int)ImGuiCol.TableBorderStrong] = new Vector4(0.3098039329051971f, 0.3098039329051971f, 0.3490196168422699f, 1.0f);
	style.Colors[(int)ImGuiCol.TableBorderLight] = new Vector4(0.2274509817361832f, 0.2274509817361832f, 0.2470588237047195f, 1.0f);
	style.Colors[(int)ImGuiCol.TableRowBg] = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
	style.Colors[(int)ImGuiCol.TableRowBgAlt] = new Vector4(1.0f, 1.0f, 1.0f, 0.05999999865889549f);
	style.Colors[(int)ImGuiCol.TextSelectedBg] = new Vector4(0.2745098173618317f, 0.125490203499794f, 0.8039215803146362f, 1.0f);
	style.Colors[(int)ImGuiCol.DragDropTarget] = new Vector4(0.4245694577693939f, 0.2196577787399292f, 0.9656652212142944f, 1.0f);
	style.Colors[(int)ImGuiCol.NavHighlight] = new Vector4(0.2588235437870026f, 0.5882353186607361f, 0.9764705896377563f, 1.0f);
	style.Colors[(int)ImGuiCol.NavWindowingHighlight] = new Vector4(1.0f, 1.0f, 1.0f, 0.699999988079071f);
	style.Colors[(int)ImGuiCol.NavWindowingDimBg] = new Vector4(0.800000011920929f, 0.800000011920929f, 0.800000011920929f, 0.2000000029802322f);
	style.Colors[(int)ImGuiCol.ModalWindowDimBg] = new Vector4(0.800000011920929f, 0.800000011920929f, 0.800000011920929f, 0.3499999940395355f);
}
} 