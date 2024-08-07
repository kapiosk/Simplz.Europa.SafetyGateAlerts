namespace Simplz.Europa.SafetyGateAlerts.Models;

public enum Emojis
{
    PlusOne,
    MinusOne,
    FacePalm,
    Warning,
    NoEntry,
    RotatingLight,
    NoEntrySign,
    CheckMark,
    LoudSpeaker,
    Skull,
    Computer,
}

public static class EmojiHelper
{
    public static string ToTag(this Emojis emoji)
    {
        return emoji switch
        {
            Emojis.PlusOne => "+1",
            Emojis.MinusOne => "-1",
            Emojis.FacePalm => "facepalm",
            Emojis.Warning => "warning",
            Emojis.NoEntry => "no_entry",
            Emojis.RotatingLight => "rotating_light",
            Emojis.NoEntrySign => "no_entry_sign",
            Emojis.CheckMark => "heavy_check_mark",
            Emojis.LoudSpeaker => "loudspeaker",
            Emojis.Skull => "skull",
            Emojis.Computer => "computer",
            _ => throw new ArgumentOutOfRangeException(nameof(emoji), emoji, null),
        };
    }
}
