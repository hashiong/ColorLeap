using UnityEngine;

public class ColorEntity : MonoBehaviour
{
    public enum EntityColor
    {
        Red,
        Blue,
        Green // Add as many colors as needed
    }

    public EntityColor currentColor;
}