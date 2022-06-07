

public class EnemyHealthSystem : HealthSystem
{
    protected override void Death()
    {
        GameController.instance.UpdateKillAmount();
        base.Death();
    }
}
