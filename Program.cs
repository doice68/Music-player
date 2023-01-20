using System.Text;

namespace ImGuiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 720;
            const int screenHeight = 720;
            unsafe
            {
                Raylib.SetTraceLogCallback(&Logging.LogConsole);
            }
            // Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_VSYNC_HINT);
            
            Raylib.InitWindow(screenWidth, screenHeight, "APP");
            Raylib.SetTargetFPS(60);
            Raylib.InitAudioDevice();

            ImguiController controller = new ImguiController();
            var path = @"Chickenic.ttf";
            ImGui.GetIO().Fonts.AddFontFromFileTTF(path, 17);
            MyStyle.SetupImGuiStyle();
            ImGui.GetStyle().ScaleAllSizes(1.5f);
            controller.Load(screenWidth, screenHeight);
            
            var app = new App();

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();

                controller.Update(dt);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(new Color(86, 47, 168, 255));
                app.Update();
                controller.Draw();
                app.LateUpdate();

                Raylib.EndDrawing();
            }
            controller.Dispose();
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
