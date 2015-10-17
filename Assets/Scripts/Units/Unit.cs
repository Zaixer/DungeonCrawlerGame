using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract string Resource { get; }
    public abstract int MaxHealth { get; }
    public abstract int AttackDamage { get; }
    public bool IsAlive { get { return _currentHealth > 0; } }
    public int CurrentHealth { get { return _currentHealth; } }
    public float CurrentHealthPercentage { get { return (float)_currentHealth / MaxHealth ; } }
    
    private int _currentHealth;    

    void Start()
    {
        _currentHealth = MaxHealth;
        var healthBar = Instantiate(Resources.Load<GameObject>("UI/HealthBarCanvas"));
        var healthBarTransform = healthBar.transform;
        var unitTransform = gameObject.transform;
        var unitBounds = gameObject.GetComponent<Renderer>().bounds;
        healthBarTransform.SetParent(unitTransform);
        healthBarTransform.position = new Vector3(unitBounds.center.x, unitBounds.center.y + unitBounds.size.y / 2);
    }
    
    public void ApplyDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void ApplyHeal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > MaxHealth)
        {
            _currentHealth = MaxHealth;
        }
    }
}
