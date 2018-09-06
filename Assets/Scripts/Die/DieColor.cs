public enum DieColor
{
    Green,
    Red,
    Yellow
};

static class DieColorExtensions
{
    public static DieColor Next(this DieColor myEnum)
    {
        switch (myEnum)
        {
            case DieColor.Green:
                return DieColor.Red;
            case DieColor.Red:
                return DieColor.Yellow;
            case DieColor.Yellow:
                return DieColor.Green;
        }

        return DieColor.Green;
    }
}

