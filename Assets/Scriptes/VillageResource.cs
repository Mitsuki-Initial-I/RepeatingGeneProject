/// <summary>
/// ƒŠƒ\[ƒXŠÇ—
/// </summary>

public class VillageResource
{
    public int Food { get; set; }
    public int Wood { get; set; }
    public int Stone { get; set; }

    public VillageResource(int food,int wood, int stone)
    {
        Food = food;
        Wood = wood;
        Stone = stone;
    }

    public void ConsumeResources(Villager villager )
    {
        if (villager.Hunger>50)
        {
            Food -= 1;
            villager.Hunger = 0;
        }
    }
}