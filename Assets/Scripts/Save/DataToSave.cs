[System.Serializable]
public class DataToSave
{
    public string playerName;
    public int level, maxHP, curHP;
    public float maxExp, curExp;
    public float x, y, z;

    public DataToSave(PlayerManager player)
    {
        playerName = player.playerName;
        level = player.level;
        //maxHP = PlayerManager.maxHP;
        //curHP = PlayerManager.curHP;
        maxExp = PlayerManager.maxXp;
        curExp = PlayerManager.curXP;
        x = player.transform.position.x;
        y = player.transform.position.y;
        z = player.transform.position.z;
    }
}
