using System;
using System.Collections.Generic;
using System.Text;

namespace RhythmGame
{
    /// <summary>
    /// Called by EntityManager whenever the game instance calls to spawn an entity
    /// </summary>
    static class EntSpawner
    {
        // Systems to be given to each respective entity type
        static EntManager.System[] bulletSystems = { new BulletMovement(), new BulletSelfDestruct()};
        static EntManager.System[] playerSystems = { new RhythmGame.EntManager.Systems.PlayerMovement(), new RhythmGame.EntManager.Systems.PlayerCollision() };
        static EntManager.System[] spawnerSystems = { new RhythmGame.EntManager.Systems.SpawnerFire(), 
                                                      new RhythmGame.EntManager.Systems.SpawnerRotation(), 
                                                      new RhythmGame.EntManager.Systems.SpawnerSelfDestruct() }; 

        /// <summary>
        /// Returns an entity given a definition
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public static Entity CreateEnt(EntDef def)
        {
            switch (def.entName)
            {
                case "bullet":
                    Bullet newBullet = new Bullet(bulletSystems, def);
                    return newBullet;
                case "bulletspawner":
                    BulletSpawner newSpawner = new BulletSpawner(spawnerSystems, def);
                    return newSpawner;
                case "bulletwave":
                    break;
                case "background":
                    break;
                case "player":
                    Player player = new Player(playerSystems, def);
                    return player;
            }
            // Throws if given EntDef doesn't exist
            throw new NotImplementedException();
        }
    }
}
