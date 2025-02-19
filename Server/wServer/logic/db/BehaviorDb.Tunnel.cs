﻿using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Tunnel = () => Behav()
              .Init("Tunnel Fearless Ranger",
                  new State(
                    new State("gitgud",
                        new Follow(0.35, 8, 1),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2550),
                        new Shoot(10, count: 3, shootAngle: 18, projectileIndex: 1, coolDown: 1250),
                        new HpLessTransition(0.35, "gitgud2")
                        ),
                    new State("gitgud2",
                    new Orbit(0.55, 2, target: null),
                     new Shoot(10, count: 2, shootAngle: 18, projectileIndex: 1, coolDown: 650),
                    new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 0, coolDown: 1900)
                       )
                    ),
                new ItemLoot("Magic Potion", 0.25),
                new ItemLoot("Health Potion", 0.25)
              )
        .Init("Tunnel Fearless Archer",
                  new State(
                    new State("gitgud",
                        new Wander(0.3),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 920),
                        new HpLessTransition(0.30, "gitgud2")
                        ),
                    new State("gitgud2",
                    new Follow(0.5, 8, 1),
                    new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 0, coolDown: 1900)
                       )
                    ),
                  new TierLoot(6, ItemType.Weapon, 0.2),
                  new TierLoot(7, ItemType.Weapon, 0.1)
                 )
        .Init("Tunnel Faceless Evil",
                  new State(
                    new State("gitgud",
                        new Follow(0.6, 8, 1),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 90)
               )))
        .Init("Tunnel Armored Mage",
                  new State(
                    new State("ShootStaff",
                        new Wander(0.42),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 550),
                        new TimedTransition(5000, "Ep")
                        ),
                    new State("Ep",
                    new Follow(0.32, 8, 1),
                    new HealSelf(coolDown: 4000, amount: 600),
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1750),
                    new TimedTransition(5000, "ShootStaff2")
                       ),
                   new State("ShootStaff2",
                        new BackAndForth(0.35, 6),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 100),
                        new TimedTransition(5000, "ShootStaff")
                        )
                    ),
                new ItemLoot("Magic Potion", 0.25),
                new ItemLoot("Health Potion", 0.25)
                 )
           .Init("Tunnel Spearman of Pain",
                new State(
                  new State("gitgud",
                      new Wander(0.42),
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 700, coolDownOffset: 900),
                      new TimedTransition(4250, "gitgud2")
                      ),
                  new State("gitgud2",
                  new Follow(0.38, 8, 1),
                  new Shoot(10, count: 2, shootAngle: 1, projectileIndex: 0, coolDown: 400),
                  new TimedTransition(1000, "gitgud")
                     )
                  )
               )
      .Init("Tunnel Mini Eye",
                new State(
                  new State("swag",
                      new Follow(1.25, 8, 1),
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1500),
                       new Shoot(10, count: 1, projectileIndex: 0, predictive: 2.5, coolDown: 525)
             )))
      .Init("Tunnel N",
                new State(
                     new State("waitforaperson",
                      new Wander(0.6),
                      new ConditionalEffect(ConditionEffectIndex.Invincible),
                      new PlayerWithinTransition(7, "RingShotgun")
                      ),
                new State(
                  new Spawn("Tunnel Mini Eye", 1, 2, coolDown: 3000),
                  new State("RingShotgun",
                      new Taunt(0.50, "...."),
                      new Wander(0.4),
                      new Shoot(10, count: 10, projectileIndex: 0, coolDown: 1250),
                      new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 1, coolDown: 1600),
                      new TimedTransition(6000, "Charge&Insta")
                      ),
                 new State("Charge&Insta",
                     new Prioritize(
                       new Charge(0.5, 7, coolDown: 1000),
                       new Follow(0.45, 8, 1)
                     ),
                      new Shoot(10, count: 8, projectileIndex: 0, coolDown: 1250, coolDownOffset: 1300),
                      new Shoot(10, count: 6, shootAngle: 30, projectileIndex: 1, coolDown: 1600),
                      new TimedTransition(3000, "RingShotgun")
                        )
                      )
                    )
                  )
           .Init("Tunnel Hazv Power Thing",
                   new State(
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                     new State("Idle",
                         new EntityExistsTransition("FateT", 9999, "Active")
                         ),
                     new State("Active",
                     new Shoot(10, count: 5, projectileIndex: 0, coolDown: 300),
                     new EntitiesNotExistsTransition(9999, "Idle", "FateT")
                        )
                     )
                  )
        .Init("Tunnel Spike",
               new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("wait",
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "spike")
                    ),
                new State("spike",
                    new SetAltTexture(1),
                    new Shoot(5, 1, projectileIndex: 0, coolDown: 500),
                    new NoPlayerWithinTransition(4,"wait")
                    )
                )
            )
         .Init("Tunnel Arrow Turret1",
                    new State(
                       new SetNoXP(),
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("wait",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedRandomTransition(500, true, "pew pew")
                        ),
                     new State("pew pew",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, 1, fixedAngle: 90, coolDown: 2000)
                        )
            )
            )


            .Init("Tunnel Arrow Turret2",
             new State(
                       new SetNoXP(),
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("wait",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedRandomTransition(600, true, "pew pew")
                        ),
                     new State("pew pew",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, 1, fixedAngle: 270, coolDown: 2000)
                        )
            )
            )
              /*.Init("Varghus Test Chest",
                    new State(
                        new State("Idle",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(5000, "UnsetEffect")
                        ),
                        new State("UnsetEffect")
                    ),
                    new MostDamagers(3,
                        new ItemLoot("Potion of Restoration", 1)
                        ),
                    new Threshold(0.15,
                    new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Potion of Dexterity", 0.8),
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Soulreaper Armor", 0.035),
                    new ItemLoot("Nether Blade", 0.035),
                    new ItemLoot("Staff of Dark Malediction", 0.035)
                    )
                )*/
              .Init("Tunnel Varghus the Eye",
                   new State(
                       new RealmPortalDrop(),
                       //new TransformOnDeath("Varghus Test Chest", 1, 1, 1),
                       new HpLessTransition(0.10, "RemovePowerandDie"),
                       new State("default",
                           new ConditionalEffect(ConditionEffectIndex.Invincible),
                           new PlayerWithinTransition(8, "setthethingies")
                           ),
                         new State("setthethingies",
                              new ConditionalEffect(ConditionEffectIndex.Invincible),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 0, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 45, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 90, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 135, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 180, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 225, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 270, coolDown: 9999999),
                           new InvisiToss("Tunnel Hazv Power Thing", 2, 315, coolDown: 9999999),
                           new TimedTransition(4000, "PurpleShotgunPhase")
                           ),
                       new State("PurpleShotgunPhase",
                           new Shoot(13, count: 6, shootAngle: 8, projectileIndex: 0, coolDown: 10),
                           new Shoot(13, count: 7, projectileIndex: 1, coolDown: 100),
                           new Shoot(13, count: 3, projectileIndex: 2, coolDown: 1000),
                           new TimedTransition(6500, "SpawnNsandRingShotgun")
                           ),
                       new State("SpawnNsandRingShotgun",
                           new Shoot(10, count: 8, projectileIndex: 3, coolDown: 1570),
                           new Shoot(13, count: 2, shootAngle: 2, projectileIndex: 2, coolDown: 750),
                           new TimedTransition(6000, "WarnThePlayer")
                           ),
                       new State("WarnThePlayer",
                           new Taunt(1.00, "BEWARE!"),
                           new Flash(0xFF00FF, 2, 2),
                           new ConditionalEffect(ConditionEffectIndex.Armored),
                           new TimedTransition(3000, "BlastTheMelees")
                           ),
                       new State("BlastTheMelees",
                           new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                           new Spawn("FateT", 1, 1, coolDown: 999999),
                           new TimedTransition(4500, "MoShotguns")
                           ),
                       new State("MoShotguns",
                           new RemoveEntity(9999, "FateT"),
                           new Shoot(10, count: 20, projectileIndex: 0, coolDown: 200),
                           new Shoot(13, count: 1, projectileIndex: 4, coolDown: 1),
                           new Shoot(13, count: 1, projectileIndex: 3, predictive: 5, coolDown: 1000),
                           new TimedTransition(5000, "PurpleShotgunPhase")
                           ),
                       new State("RemovePowerandDie",
                           new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                           new RemoveEntity(9999, "Tunnel Hazv Power Thing"),
                           new Suicide()
                           )
                       ),
                    new MostDamagers(3,
                        LootTemplates.Sor2Perc()
                    ),
                     new MostDamagers(3,
                         new ItemLoot("Potion of Restoration", 1)
                     ),
                     new Threshold(0.15,
                         new TierLoot(10, ItemType.Weapon, 0.1),
                         new TierLoot(4, ItemType.Ability, 0.1),
                         new TierLoot(10, ItemType.Armor, 0.1),
                         new TierLoot(3, ItemType.Ring, 0.05),
                         new TierLoot(10, ItemType.Armor, 0.05),
                         new TierLoot(10, ItemType.Weapon, 0.05),
                         new TierLoot(4, ItemType.Ring, 0.025),
                         new ItemLoot("Greater Potion of Restoration", 0.2),
                         new ItemLoot("Potion of Defense", 0.3),
                         new ItemLoot("Soulreaper Armor", 0.01),
                         new ItemLoot("Nether Blade", 0.002),
                         new ItemLoot("Wand of Obscurity", 0.002),
                         new ItemLoot("Staff of Dark Malediction", 0.002)
                     )
               );
    }
}