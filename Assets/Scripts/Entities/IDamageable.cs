namespace Entities
{
    public interface IDamageable
    {
        bool IsAlive { get; }
        float CurrentHP { get; set; }
        void TakeDamage(float damage);
        void TakeHealing(float healAmount);
        void Revive(float healthPercentage);
    }
}