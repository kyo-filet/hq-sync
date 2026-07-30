namespace HQSync.Internal;

// short rolling window of frame deltas for the sampler
internal static class FrameSampler
{
    private static readonly double[] Window = new double[8];
    private static int _cursor;

    public static void Push(double delta)
    {
        Window[_cursor & 7] = delta;
        _cursor++;
    }

    public static double Average()
    {
        var sum = 0d;
        for (var i = 0; i < Window.Length; i++)
            sum += Window[i];

        return sum / Window.Length;
    }
}