public class KnightUnit : Unit
{
    public override string Resource { get { return "Units/Knight"; } }
    public override int MaxHealth { get { return 100; } }
    public override int AttackDamage { get { return 10; } }
}
