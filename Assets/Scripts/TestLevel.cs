public class TestLevel : Level
{
    public override string MusicNormalResource
    {
        get
        {
            return "Audio/MusicNormal";
        }
    }

    public override string MusicBattleResource
    {
        get
        {
            return "Audio/MusicBattle";
        }
    }

    public override string BackgroundBottomResource
    {
        get
        {
            return "Backgrounds/BackgroundBottom";
        }
    }

    public override string BackgroundTopResource
    {
        get
        {
            return "Backgrounds/BackgroundTop";
        }
    }

    public override int Length
    {
        get
        {
            return 200;
        }
    }
}
