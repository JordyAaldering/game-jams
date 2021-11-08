public class TextBox
{
    public readonly bool isPositive;
    public readonly Platform platform;

    public TextBox(Platform platform, bool isPositive)
    {
        this.platform = platform;
        this.isPositive = isPositive;
    }
}

public enum Platform
{
    Facebook,
    Reddit,
    Snapchat,
    Twitter
}
