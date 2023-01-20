using TagLib;
class App
{
    bool isPlaying;
    bool repeat;
    int time;
    int currentSong;
    Music currentMusic;
    float volume = 0.5f;
    float pitch = 1;
    float pan = 0.5f;
    int contextMenuIndex = 2;
    string playListName = "";
    List<PlayList> playLists = new();
    int currentPlayList;
    bool songsTabOpen = true;
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

        //bottom section
        ImGui.Begin("Now Playing..", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoCollapse);
        ImGui.SetWindowPos(new Vector2(GetScreenWidth() / 2 - 200, GetScreenHeight() - 200));
        ImGui.SetWindowSize(new Vector2(400, 160));
        
        Helpers.CenteredText(playLists[0].songs[currentSong].name);

        Helpers.WithText("vol   ", "volume", () => 
        {
            ImGui.SetNextItemWidth(40);
            ImGui.DragFloat("", ref volume, 0.002f, 0, 1, Math.Round(volume, 2).ToString());
        });
        
        ImGui.SameLine();
        if (ImGui.Button("<<"))
        {
            if (playLists[currentPlayList].songs.Count != 0)
            {
                if (currentSong == 0) 
                    SetCurrentSong(playLists[0].songs.Count - 1);
                else
                    SetCurrentSong(currentSong - 1);
            }

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
            if (playLists[currentPlayList].songs.Count != 0)
            {
                if (currentSong == playLists[0].songs.Count - 1) 
                    SetCurrentSong(0);
                else
                    SetCurrentSong(currentSong + 1);
            }
        }
        
        ImGui.SameLine();
        ImGui.Checkbox("  Repeat", ref repeat);
        
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
                Helpers.CenteredText(playLists[currentPlayList].name);
                ImGui.BeginChild("song child");

                ImGui.BeginListBox("song listbox", new Vector2(375, 360));
                for (int i = 0; i < playLists[currentPlayList].songs.Count; i++)
                {
                    ImGui.Selectable(playLists[currentPlayList].songs[i].name, i == currentSong, ImGuiSelectableFlags.None, new Vector2(0, 30));
                    if (ImGui.IsItemClicked())
                    {
                        SetCurrentSong(i);
                    }
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        contextMenuIndex = i;
                    }

                    if (ImGui.BeginPopupContextItem("context menu"))
                    {
                        if (contextMenuIndex == i)
                        {
                            if(ImGui.MenuItem("Add to PlayList")){}
                            if(ImGui.MenuItem("Show in folder")){}
                            if(ImGui.MenuItem("Delete")){}
                        }
                        ImGui.EndPopup();
                    }
                }
                ImGui.EndListBox();
                ImGui.EndChild();
                ImGui.EndTabItem();
            }
            if (ImGui.BeginTabItem("Playlist"))
            {
                if (ImGui.Button("Add"))
                {
                    playLists.Add(new PlayList(playListName));
                    playListName = "";
                }

                ImGui.SameLine();
                ImGui.SetNextItemWidth(310);
                ImGui.PushID("playlist name");
                ImGui.InputText("", ref playListName, 30);
                ImGui.PopID();
                
                ImGui.BeginChild("playlist child");

                ImGui.BeginListBox("playlist listbox", new Vector2(375, 345));
                for (int i = 0; i < playLists.Count; i++)
                {
                    if (ImGui.Button(playLists[i].name, new Vector2(330, 100)))
                    {
                        currentPlayList = i;
                        currentSong = 0;
                        currentMusic = new Music();
                    }
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        contextMenuIndex = i;
                    }
                    if (ImGui.BeginPopupContextItem("conetxt menu"))
                    {
                        if (contextMenuIndex == i)
                        {
                            if(ImGui.MenuItem("Rename")){}
                            if(ImGui.MenuItem("Delete")){}
                        }
                        ImGui.EndPopup();
                    }
                }
                ImGui.EndListBox();
                ImGui.EndChild();
                ImGui.EndTabItem();
            }
            if (ImGui.BeginTabItem("Setting"))
            {
                Helpers.WithText("Pitch".PadRight(20), "pitch", () => 
                {
                    ImGui.SliderFloat("", ref pitch, 0, 2);
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        pitch = 1f;
                    }
                });

                Helpers.WithText("Pan".PadRight(20), "pan", () => 
                {
                    ImGui.SliderFloat("", ref pan, 1, 0);
                    if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
                    {
                        pan = 0.5f;
                    }
                });
                
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
        currentMusic = LoadMusicStream(playLists[currentPlayList].songs[currentSong].dir);
        PlayMusicStream(currentMusic);
        isPlaying = true;
    }
    void SetCurrentSong(int n)
    {
        currentSong = n;
        SongChanged();
    }
    void LoadSongs()
    {
        var path = @"C:\Users\Meraj\Music";
        playLists.Add(new PlayList("All"));
        foreach (var item in Directory.GetFiles(path))
        {
            if (item.EndsWith(".mp3"))
            {
                var tag = TagLib.File.Create(item);
                playLists[0].songs.Add(new Song(tag.Tag.Title, item));
            }
        } 
    }

}