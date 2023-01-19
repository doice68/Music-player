using TagLib;
class App
{
    bool isPlaying;
    bool repeat;
    int time;
    int _currentSong;
    int currentSong;
    string[] songs = {};
    List<string> dirs = new();
    Music currentMusic;
    float volume = 0.5f;
    float pitch = 1;
    float pan = 0.5f;
    public App()
    {
        LoadSongs();
    }
    public void LateUpdate()
    {

    }
    public void Update()
    {
        currentMusic.looping = repeat;
        time = (int)GetMusicTimePlayed(currentMusic);
        if (time > GetMusicTimeLength(currentMusic))
        {
            time = 0;
        }
        SetMusicVolume(currentMusic, volume);
        SetMusicPan(currentMusic, pan);
        SetMusicPitch(currentMusic, pitch);
        
        if (isPlaying)
            UpdateMusicStream(currentMusic);

        if (_currentSong != currentSong)
        {
            _currentSong = currentSong;
            SongChanged();
        }
        //bottom section
        ImGui.Begin("Now Playing..", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoCollapse);
        ImGui.SetWindowPos(new Vector2(GetScreenWidth() / 2 - 200, GetScreenHeight() - 200));
        ImGui.SetWindowSize(new Vector2(400, 160));
        
        Helpers.CenteredText(songs[currentSong]);

        Helpers.WithText("vol   ", "volume", () => 
        {
            ImGui.SetNextItemWidth(40);
            ImGui.DragFloat("", ref volume, 0.002f, 0, 1, Math.Round(volume, 2).ToString());
        });
        
        ImGui.SameLine();
        if (ImGui.Button("<<"))
        {
            if (currentSong == 0) 
                currentSong = songs.Length - 1;
            else
                currentSong--;
        }
        
        ImGui.SameLine();
        if (isPlaying)
        {
            if (ImGui.Button("| |"))
            {
                isPlaying = false;
            }
        }
        else
        {
            if (ImGui.Button("|>"))
            {
                isPlaying = true;
            }
        }
        
        ImGui.SameLine();
        if (ImGui.Button(">>"))
        {
            if (currentSong == songs.Length - 1) 
                currentSong = 0;
            else
                currentSong++;
        }
        
        ImGui.SameLine();
        ImGui.Checkbox("  Repeat", ref repeat);
        //time slider
        // ImGui.SetNextItemWidth(100);
        
        Helpers.WithText(Helpers.TimeFormat(time), "time", () => 
        {
            ImGui.SetNextItemWidth(280);
            ImGui.SliderInt(
                Helpers.TimeFormat((int)GetMusicTimeLength(currentMusic)), 
                ref time, 
                0, 
                (int)GetMusicTimeLength(currentMusic), 
                "", 
                ImGuiSliderFlags.InvalidMask
            );
        });
        ImGui.End();
        //top section
        ImGui.Begin("x", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        ImGui.SetWindowPos(new Vector2(GetScreenWidth() / 2 - 200, 50));
        ImGui.SetWindowSize(new Vector2(400, 450));
        //tabs
        if (ImGui.BeginTabBar("welcome"))
        {
            if (ImGui.BeginTabItem("Songs"))
            {
                ImGui.BeginChild(".");
                ImGui.SetNextItemWidth(375);
                ImGui.ListBox("", ref currentSong, songs, songs.Length, 18);
                ImGui.EndChild();
                ImGui.EndTabItem();
            }
            if (ImGui.BeginTabItem("Playlist"))
            {
                ImGui.EndTabItem();
            }
            if (ImGui.BeginTabItem("Setting"))
            {
                Helpers.WithText("Pitch  ", "pitch", () => 
                {
                    ImGui.SliderFloat("", ref pitch, 0, 2);
                });
                ImGui.SameLine();
                ImGui.PushID("pitch reset");
                if (ImGui.Button("R")) pitch = 1f;
                ImGui.PopID();
                
                Helpers.WithText("Pan    ", "pan", () => 
                {
                    ImGui.SliderFloat("", ref pan, 0, 1);
                });
                ImGui.SameLine();
                
                ImGui.PushID("pan reset");
                if (ImGui.Button("R")) pan = 0.5f;
                ImGui.PopID();
                
                ImGui.EndTabItem();
            }
            if (ImGui.BeginTabItem("Info"))
            {
                ImGui.Button("Choose file");
                ImGui.EndTabItem();
            }
        }
        ImGui.End();
    }
    void SongChanged()
    {
        currentMusic = LoadMusicStream(dirs[currentSong]);
        PlayMusicStream(currentMusic);
        isPlaying = true;
    }
    void LoadSongs()
    {
        var path = @"C:\Users\Meraj\Music";
        List<string> songsList = new();
        foreach (var item in Directory.GetFiles(path))
        {
            if (item.EndsWith(".mp3"))
            {
                var tag = TagLib.File.Create(item);
                songsList.Add(tag.Tag.Title);
                dirs.Add(item);
            }
        } 
        songs = songsList.ToArray();
    }

}