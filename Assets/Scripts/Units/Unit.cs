public abstract class Unit
{
    public abstract string Resource { get; }
    public abstract int MaxHealth { get; }
    public abstract int AttackDamage { get; }
    public bool IsAlive { get { return _currentHealth > 0; } }
    public int CurrentHealth { get { return _currentHealth; } }
    public float CurrentHealthPercentage { get { return (float)_currentHealth / MaxHealth ; } }

    private int _currentHealth;

    public Unit()
    {
        _currentHealth = MaxHealth;
    }
    
    public void Damage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > MaxHealth)
        {
            _currentHealth = MaxHealth;
        }
    }
}
