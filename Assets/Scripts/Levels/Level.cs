public abstract class Level
{
    public abstract string MusicNormalResource { get; }
    public abstract string MusicBattleResource { get; }
    public abstract string BackgroundBottomResource { get; }
    public abstract string BackgroundTopResource { get; }
    public abstract int Length { get; }
}
