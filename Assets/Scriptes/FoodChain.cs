/// <summary>
/// �ߐH�Ǘ��V�X�e��
/// </summary>
public class FoodChain
{
    public static bool CanEat(Creature predator, Creature prey)
    {
        // ���H�͑��H������G�H������H�ׂ�
        if(predator.dietType==DietType.Carnivore&&(prey.dietType != DietType.Carnivore))
        {
            return true;
        }
        // �G�H�͑��H������H�ׂāA���H�����ɐH�ׂ���
        if (predator.dietType == DietType.Omnivore && (prey.dietType != DietType.Herbivore))
        {
            return true;
        }
        // ���H�͑��̓�����H�ׂȂ�
        return false;
    }
}