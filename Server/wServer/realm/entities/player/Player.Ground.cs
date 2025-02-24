﻿using System;
using System.Linq;
using common.resources;
using wServer.networking.packets.outgoing;
using wServer.realm.terrain;

namespace wServer.realm.entities
{
    public partial class Player
    {
        long l;

        private void HandleBastille(RealmTime time)
        {
            try
            {
                if (RageBar > 0)
                {
                    ApplyConditionEffect(ConditionEffectIndex.Weak, 0);
                    ApplyConditionEffect(ConditionEffectIndex.Quiet, 0);
                }
                if (RageBar >= 90)
                {
                    ApplyConditionEffect(ConditionEffectIndex.Empowered, 2000);
                }

                if (HasConditionEffect(ConditionEffects.Hidden)) return;

                if (time.TotalElapsedMs - l <= 100 || Owner?.Name != "SummoningPoint") return;

                if (this.GetNearestEntity(150, 0x63ed) == null)
                {
                    this.GetNearestEntity(999, 0x63e7).ApplyConditionEffect(ConditionEffectIndex.Invulnerable);
                    if (RageBar == 0)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.Weak);
                        ApplyConditionEffect(ConditionEffectIndex.Quiet);
                    }
                    else
                    {
                        RageBar -= 2;
                    }
                }
                else
                {
                    this.GetNearestEntity(999, 0x63e7).ApplyConditionEffect(ConditionEffectIndex.Invulnerable, 0);
                    if (RageBar < 100)
                        RageBar += 1;
                    if (RageBar > 100)
                        RageBar = 100;
                }
                l = time.TotalElapsedMs;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void HandleUltraBastille(RealmTime time)
        {
            try
            {
                if (RageBar > 0)
                {
                    ApplyConditionEffect(ConditionEffectIndex.Weak, 0);
                    ApplyConditionEffect(ConditionEffectIndex.Quiet, 0);
                }
                if (RageBar >= 90)
                {
                    ApplyConditionEffect(ConditionEffectIndex.Empowered, 2000);
                }

                if (HasConditionEffect(ConditionEffects.Hidden)) return;

                if (time.TotalElapsedMs - l <= 100 || Owner?.Name != "UltraSummoningPoint") return;

                if (this.GetNearestEntity(150, 0x63ed) == null)
                {
                    this.GetNearestEntity(999, 0x75f2).ApplyConditionEffect(ConditionEffectIndex.Invulnerable);
                    if (RageBar == 0)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.Weak);
                        ApplyConditionEffect(ConditionEffectIndex.Quiet);
                    }
                    else
                    {
                        RageBar -= 2;
                    }
                }
                else
                {
                    this.GetNearestEntity(999, 0x75f2).ApplyConditionEffect(ConditionEffectIndex.Invulnerable, 0);
                    if (RageBar < 100)
                        RageBar += 1;
                    if (RageBar > 100)
                        RageBar = 100;
                }
                l = time.TotalElapsedMs;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        bool HandleGround(RealmTime time)
        {
            if (time.TotalElapsedMs - l > 500)
            {
                if (HasConditionEffect(ConditionEffects.Paused) ||
                    HasConditionEffect(ConditionEffects.Invincible))
                    return false;

                WmapTile tile = Owner.Map[(int)X, (int)Y];
                ObjectDesc objDesc = tile.ObjType == 0 ? null : Manager.Resources.GameData.ObjectDescs[tile.ObjType];
                TileDesc tileDesc = Manager.Resources.GameData.Tiles[tile.TileId];
                if (tileDesc.Damaging && (objDesc == null || !objDesc.ProtectFromGroundDamage))
                {
                    int dmg = (int)Client.Random.NextIntRange((uint)tileDesc.MinDamage, (uint)tileDesc.MaxDamage);

                    HP -= dmg;

                    Owner.BroadcastPacketNearby(new Damage()
                    {
                        TargetId = Id,
                        DamageAmount = (ushort)dmg,
                        Kill = HP <= 0,
                    }, this, this);

                    if (HP <= 0)
                    {
                        Death(tileDesc.ObjectId, tile:tile);
                        return true;
                    }
                        
                    l = time.TotalElapsedMs;
                }
            }
            return false;
        }

        public void ForceGroundHit(RealmTime time, Position pos, int timeHit)
        {
            if (HasConditionEffect(ConditionEffects.Paused) ||
                HasConditionEffect(ConditionEffects.Invincible))
                return;

            WmapTile tile = Owner.Map[(int) pos.X, (int) pos.Y];
            ObjectDesc objDesc = tile.ObjType == 0 ? null : Manager.Resources.GameData.ObjectDescs[tile.ObjType];
            TileDesc tileDesc = Manager.Resources.GameData.Tiles[tile.TileId];
            if (tileDesc.Damaging && (objDesc == null || !objDesc.ProtectFromGroundDamage))
            {
                int dmg = (int)Client.Random.NextIntRange((uint)tileDesc.MinDamage, (uint)tileDesc.MaxDamage);

                HP -= dmg;

                Owner.BroadcastPacketNearby(new Damage()
                {
                    TargetId = Id,
                    DamageAmount = (ushort)dmg,
                    Kill = HP <= 0,
                }, this, this);

                if (HP <= 0)
                {
                    Death(tileDesc.ObjectId, tile: tile);
                }
            }
        }
    }
}
