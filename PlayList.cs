public class PlayList
{
    public string name;
    public List<Song> songs = new();
    public PlayList(string name)
    {
        this.name = name;
    }
}