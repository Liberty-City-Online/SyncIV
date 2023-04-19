public void PlayerDied()
{
    PlayerDeathData deathData = new PlayerDeathData();
    deathData.PlayerId = this.PlayerId;
    deathData.DeathTime = DateTime.Now;

    NetworkManager.SendDeathData(deathData);
}

public void HandleDeathData(PlayerDeathData deathData)
{
    NetworkManager.BroadcastDeathData(deathData);
}

public void HandleRemoteDeathData(PlayerDeathData deathData)
{
    Player remotePlayer = PlayerList.Find(p => p.PlayerId == deathData.PlayerId);
    if (remotePlayer != null)
    {
        remotePlayer.Die(deathData.DeathTime);
    }
}
