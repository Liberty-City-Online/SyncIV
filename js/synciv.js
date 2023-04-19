// pdied func
function playerDied() {
    // data
    var deathData = {
        playerId: this.playerId,
        deathTime: new Date()
    };

    // sending data to server
    NetworkManager.sendDeathData(deathData);
}

// handler
function handleDeathData(deathData) {
    // sync
    NetworkManager.broadcastDeathData(deathData);
}

// handler again
function handleRemoteDeathData(deathData) {
    // sync2
    var remotePlayer = PlayerList.find(function(p) {
        return p.playerId === deathData.playerId;
    });
    if (remotePlayer) {
        remotePlayer.die(deathData.deathTime);
    }
}
