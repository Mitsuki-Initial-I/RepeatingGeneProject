/// <summary>
/// 感情クラス
/// </summary>
public class Emotion
{
    public string Type { get; set; }
    public float Intensity { get; set; }

    public Emotion(string type,float intensity)
    {
        Type = type;
        Intensity = intensity;
    }
}