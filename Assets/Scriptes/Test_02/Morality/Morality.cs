/// <summary>
/// “¹“¿ƒNƒ‰ƒX
/// </summary>
public class Morality
{
    public float Compassion { get; set; }
    public float Aggression { get; set; }

    public Morality(float compassion,float aggression)
    {
        Compassion = compassion;
        Aggression = aggression;
    }

    public void AdjustBasedOnEmotion(Emotion emotion)
    {
        // ‹°•|
        if (emotion.Type=="Fear")
        {
            Aggression += emotion.Intensity * 0.5f;
        }
        // ‹¤Š´
        else if (emotion.Type=="Empathy")
        {
            Compassion += emotion.Intensity;
        }
    }
}