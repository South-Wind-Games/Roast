namespace Roasts.Base
{
    public interface IDamageable
    {
        bool IsAlive { get; }
        float CurrentHP { get; set; }
        float MaxHP { get; }
        void TakeDamage(float damage);
        void TakeHealing(float healAmount);
        void Revive(float healthPercentage);
    }
}