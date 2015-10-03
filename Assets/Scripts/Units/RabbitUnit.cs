public class RabbitUnit : Unit
{
    public override string Resource { get { return "Units/Rabbit"; } }
    public override int MaxHealth { get { return 50; } }
    public override int AttackDamage { get { return 10; } }
}
