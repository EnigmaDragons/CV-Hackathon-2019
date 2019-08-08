public static class ZByLane
{
    private const int PerLane = 5;
    private const int BackLane = 20;

    public static int BackOfLane(int lane) => BackLane + lane * PerLane;
    public static int CenterOfLane(int lane) => BackLane + lane + PerLane - 3;
    public static int FrontOfLane(int lane) => BackLane + lane * PerLane + PerLane - 1;
}
