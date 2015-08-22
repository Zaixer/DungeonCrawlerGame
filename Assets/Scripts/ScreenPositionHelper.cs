using UnityEngine;

public static class ScreenPositionHelper {
    private const float UNITS_PER_PIXEL = 100f;

    public static Vector3 GetFromPixels(int pixelsX, int pixelsY)
    {
        return new Vector3(pixelsX / UNITS_PER_PIXEL, pixelsY / UNITS_PER_PIXEL);
    }
}
