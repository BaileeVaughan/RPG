[System.Serializable]
public class DataToSave
{
    public string playerName;
    public int level, maxHP, curHP;
    public float maxExp, curExp;
    public float x, y, z;

    public DataToSave(PlayerManager player, EXPBar exp)
    {
        playerName = player.playerName;
        level = player.level;
        maxHP = HeartHealth.maxHealth;
        maxExp = exp.maxXp;
        curHP = HeartHealth.curHealth;
        curExp = exp.curXP;
        x = player.savePos.x;
        y = player.savePos.y;
        z = player.savePos.z;
    }
}
