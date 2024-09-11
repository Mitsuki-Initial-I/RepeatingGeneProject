/// <summary>
/// 捕食管理システム
/// </summary>
public class FoodChain
{
    public static bool CanEat(Creature predator, Creature prey)
    {
        // 肉食は草食動物や雑食動物を食べる
        if(predator.dietType==DietType.Carnivore&&(prey.dietType != DietType.Carnivore))
        {
            return true;
        }
        // 雑食は草食動物を食べて、肉食動物に食べられる
        if (predator.dietType == DietType.Omnivore && (prey.dietType != DietType.Herbivore))
        {
            return true;
        }
        // 草食は他の動物を食べない
        return false;
    }
}