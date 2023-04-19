void playerDied(int playerId) {
    PlayerDeathData deathData;
    deathData.playerId = playerId;
    deathData.deathTime = std::chrono::system_clock::now();

    NetworkManager::sendDeathData(deathData);
}

void handleDeathData(PlayerDeathData deathData) {
    NetworkManager::broadcastDeathData(deathData);
}

void handleRemoteDeathData(PlayerDeathData deathData) {
    for (auto& remotePlayer : PlayerList) {
        if (remotePlayer.getPlayerId() == deathData.playerId) {
            remotePlayer.die(deathData.deathTime);
        }
    }
}