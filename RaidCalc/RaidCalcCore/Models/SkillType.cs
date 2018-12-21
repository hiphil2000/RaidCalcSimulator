namespace RaidCalcCore.Models
{
    public enum SkillType
    {
        Basic = 1,
        Offence = 2,
        Defence = 4,
        Heal = 8,
        MobAdd = 16,
        Upgrade = 32,
        Deflect = 64,
        OffenceTick = 128,
        HealTick = 256,
        Ultimate = 512
    }
}