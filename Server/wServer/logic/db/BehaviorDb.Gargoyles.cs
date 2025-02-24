﻿using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Gargoyles = () => Behav()
			.Init("Lord Stone Gargoyle",
				new State(
                    new ScaleHP2(25000),
                    new State(
					new State(
						new ConditionalEffect(ConditionEffectIndex.Invincible),
					new State("idle",
						new PlayerWithinTransition(3, "wakeup")
					),
					new State("wakeup",
						new Flash(0xFF0000, 1, 1),
						new TimedTransition(4000, "turn")
						),
							new State("turn",
								new SetAltTexture(1),
								new TimedTransition(2000, "alive")
							)
					),
					new State(
						new EntitiesNotExistsTransition(60, "attac1", "Stone Gargoyle"),
						new State("alive",
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
							new Shoot(0, projectileIndex: 5, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 1200, coolDownOffset: 1200),

							new Shoot(10, 3, projectileIndex: 0, coolDown: 1200),
							new Shoot(10, 2, projectileIndex: 0, coolDown: 1200, coolDownOffset: 400),
							new Shoot(10, 1, projectileIndex: 0, coolDown: 1200, coolDownOffset: 800),
							new TimedTransition(24000, "Invulnerable")
						),
						new State("Invulnerable",
							new ConditionalEffect(ConditionEffectIndex.Invulnerable),
							new Flash(0xFF0000, 1, 1),
							new TimedTransition(6000, "Blast")
						),
						new State("Blast",
							new Shoot(10, 8, projectileIndex: 1, coolDown: 1000),
							new TimedTransition(2000, "WaveAttack")
						),
						new State("WaveAttack",
							new Shoot(10, 7, shootAngle: 12, projectileIndex: 5, coolDown: 200),

							new Shoot(10, 8, projectileIndex: 4, fixedAngle: 0, coolDown: 600),
							new Shoot(10, 6, projectileIndex: 4, fixedAngle: 0, coolDown: 600, coolDownOffset: 200),
							new Shoot(10, 4, projectileIndex: 4, fixedAngle: 0, coolDown: 600, coolDownOffset: 400),
							new Shoot(10, 2, projectileIndex: 4, fixedAngle: 0, coolDown: 600, coolDownOffset: 600),

							new Shoot(10, 8, projectileIndex: 4, fixedAngle: 90, coolDown: 600),
							new Shoot(10, 6, projectileIndex: 4, fixedAngle: 90, coolDown: 600, coolDownOffset: 200),
							new Shoot(10, 4, projectileIndex: 4, fixedAngle: 90, coolDown: 600, coolDownOffset: 400),
							new Shoot(10, 2, projectileIndex: 4, fixedAngle: 90, coolDown: 600, coolDownOffset: 600),

							new Shoot(10, 8, projectileIndex: 4, fixedAngle: 180, coolDown: 600),
							new Shoot(10, 6, projectileIndex: 4, fixedAngle: 180, coolDown: 600, coolDownOffset: 200),
							new Shoot(10, 4, projectileIndex: 4, fixedAngle: 180, coolDown: 600, coolDownOffset: 400),
							new Shoot(10, 2, projectileIndex: 4, fixedAngle: 180, coolDown: 600, coolDownOffset: 600),

							new Shoot(10, 8, projectileIndex: 4, fixedAngle: 270, coolDown: 600),
							new Shoot(10, 6, projectileIndex: 4, fixedAngle: 270, coolDown: 600, coolDownOffset: 200),
							new Shoot(10, 4, projectileIndex: 4, fixedAngle: 270, coolDown: 600, coolDownOffset: 400),
							new Shoot(10, 2, projectileIndex: 4, fixedAngle: 270, coolDown: 600, coolDownOffset: 600),
							new TimedTransition(24000, "Invulnerable2")
						),
						new State("Invulnerable2",
							new ConditionalEffect(ConditionEffectIndex.Invulnerable),
							new Flash(0xFF0000, 1, 1),
							new EntitiesNotExistsTransition(60, "Blast2", "Stone of the Gargoyles")
						),
						new State("Blast2",
							new TossObject("Stone of the Gargoyles", range: 9, coolDown: 2999),
							new TimedTransition(2000, "alive")
						)
					),
					new State("attac1",
						new Taunt(true, "Your soul will be crushed, {PLAYER}."),
						new Prioritize(
							new StayCloseToSpawn(0.2, 3),
							new Wander(0.1)
						),
						new Shoot(10, 8,  shootAngle: 8, projectileIndex: 5, predictive: 0.5, coolDownOffset: 1000, coolDown: 2600),
						new Shoot(10, 16, projectileIndex: 1, coolDownOffset: 2000, coolDown: 3000),
						new TimedTransition(9000, "mad")
					),
					new State("mad",
						new Taunt(true, "Stay put you weaklings."),
						new BackAndForth(0.8, 2),
						new ConditionalEffect(ConditionEffectIndex.Armored),
						new Flash(0xFF0000, 1, 3),
						new TimedTransition(4000, "attac2")
					),
					new State("attac2",
						new Prioritize(
							new Follow(0.8, 8, 1),
							new Wander(0.1)
						),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
						new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 1200, coolDownOffset: 1200),

						new Shoot(10, 4, shootAngle: 10, projectileIndex: 2, coolDownOffset: 2000, coolDown: 2000),
						new Shoot(10, 2, projectileIndex: 1, coolDownOffset: 2000, coolDown: 1000),
						new TimedTransition(8000, "ReturnToHome")
					),
					new State("ReturnToHome",
						new Flash(0x0000FF, 2, 2),
						new ConditionalEffect(ConditionEffectIndex.Invincible),
						new ReturnToSpawn(speed: 1.4),
						new TimedTransition(8000, "Petrican")
					),
					new State("Petrican",
						new Grenade(5, 160, range: 9, coolDown: 5000),
						new TossObject("Baby Stone Gargoyle", 4, 0, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 45, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 90, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 135, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 180, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 225, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 270, coolDown: 100000),
						new TossObject("Baby Stone Gargoyle", 4, 315, coolDown: 100000),

						new Shoot(0, projectileIndex: 3, count: 12, shootAngle: 20, fixedAngle: 0, coolDown: 2000, coolDownOffset: 600),
						new Shoot(0, projectileIndex: 3, count: 12, shootAngle: 20, fixedAngle: 90, coolDown: 2000, coolDownOffset: 600),
						new Shoot(0, projectileIndex: 3, count: 12, shootAngle: 20, fixedAngle: 180, coolDown: 2000, coolDownOffset: 600),
						new Shoot(0, projectileIndex: 3, count: 12, shootAngle: 20, fixedAngle: 270, coolDown: 2000, coolDownOffset: 600),

						new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 20, fixedAngle: 0, coolDown: 2000, coolDownOffset: 1200),
						new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 20, fixedAngle: 90, coolDown: 2000, coolDownOffset: 1200),
						new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 20, fixedAngle: 180, coolDown: 2000, coolDownOffset: 1200),
						new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 20, fixedAngle: 270, coolDown: 2000, coolDownOffset: 1200),

						new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 16, fixedAngle: 0, coolDown: 3000),
						new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 16, fixedAngle: 90, coolDown: 3000),
						new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 16, fixedAngle: 180, coolDown: 3000),
						new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 16, fixedAngle: 270, coolDown: 3000),
						new TimedTransition(30000, "Manicles")
					),
					new State("Manicles",

							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
							new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 1200, coolDownOffset: 1200),

							new Shoot(0, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1),
							new Shoot(10, projectileIndex: 2, count: 4, predictive: 2, coolDown: 2000),
							new TimedTransition(20000, "Manicles2")
					),
					new State("Manicles2",
							new Shoot(0, projectileIndex: 1, count: 4, predictive: 0.2, coolDown: 1),
							new Shoot(10, projectileIndex: 2, count: 4, predictive: 2, coolDown: 2000),
							new TimedTransition(20000, "Manicles3")
						),
					new State("Manicles3",
							new TossObject("Stone of the Gargoyles", range: 9, coolDown: 5000),
							new Shoot(10, projectileIndex: 2, count: 10, predictive: 0.2, coolDown: 3600),
							new Shoot(10, projectileIndex: 4, count: 6, shootAngle: 10, coolDown: 1000),
							new TimedTransition(20000, "vulnerable")
						),
				    new State("vulnerable",
							new Taunt("I must rest.."),
							new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
							new Flash(0x000000, 1, 4),
							new TimedTransition(10000, "attac1")
						)
				)
			  ),
                                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.015,
                    new ItemLoot("Potion of Life", 0.5),
                    new ItemLoot("Potion of Mana", 0.5),
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new ItemLoot("Potion of Speed", 0.5),
                    new ItemLoot("Potion of Attack", 0.5),
                    new ItemLoot("Potion of Defense", 0.5),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new ItemLoot("Greater Potion of Life", 0.1),
                    new ItemLoot("Greater Potion of Mana", 0.1),
                    new ItemLoot("Greater Potion of Vitality", 0.1),
                    new ItemLoot("Greater Potion of Dexterity", 0.1),
                    new ItemLoot("Greater Potion of Speed", 0.1),
                    new ItemLoot("Greater Potion of Attack", 0.1),
                    new ItemLoot("Greater Potion of Defense", 0.1),
                    new ItemLoot("Greater Potion of Wisdom", 0.1),
                    new TierLoot(10, ItemType.Weapon, 1),
					new TierLoot(6, ItemType.Ability, 0.5),
					new TierLoot(10, ItemType.Armor, 1),
					new TierLoot(5, ItemType.Ring, 0.5),
					new TierLoot(11, ItemType.Armor, 0.1),
					new TierLoot(11, ItemType.Weapon, 0.1),
					new TierLoot(6, ItemType.Ring, 0.1),
                    new TierLoot(7, ItemType.Ring, 0.01),
                    new ItemLoot("Shard of the Stone Soul", 0.0005),
                    new ItemLoot("Ancient Stone Maul", 0.01),
                    new ItemLoot("Marble Tablet", 0.005),
                    new ItemLoot("Robe of the Gargoyle Summoner", 0.005)
                )
			)
			.Init("Stone Gargoyle",
					new State(
                       // new ScaleHP2(5000),
                        new Grenade(2, 200, coolDown: 5000),
						new HpLessTransition(0.15, "dying"),
                        new HealGroup(60, "LSG Group", coolDown: 6000),
					new State("start"
					),
					new State("swag",
						new SetAltTexture(1),
						new Orbit(0.5, 4, 10, "Lord Stone Gargoyle", speedVariance: 0.1),
						new Taunt(0.25, "We will burn you to ashes!"),
						new Shoot(4, count: 4, shootAngle: 8, projectileIndex: 1, coolDown: 2000),
						new TimedTransition(6000, "swag2")
					),
					new State("swag2",
						new Orbit(0.5, 4, 10, "Lord Stone Gargoyle", speedVariance: 0.1),
						new Shoot(10, count: 4, projectileIndex: 0, coolDown: 2000),
						new TimedTransition(6000, "swag3")
					),
					new State("swag3",
						new Shoot(4, count: 1, shootAngle: 8, projectileIndex: 2, coolDown: 400),
						new TimedTransition(3000, "swag")
					),
					new State("dying",
						new Flash(0xFF0000, 1, 3),
						new Shoot(10, count: 6, projectileIndex: 2, coolDown: 1000),
						new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1)
						)
					)
				)
				.Init("Stone of the Gargoyles",
					new State(
                        new ScaleHP2(1000),
                        new TransformOnDeath("Baby Stone Gargoyle", 1, 3),
						new State("1",
							new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 0, predictive: 1, coolDown: 1000),
							new HpLessTransition(0.15, "2"),
                            new HealSelf(coolDown: 8000)
						),
						new State(
							new ConditionalEffect(ConditionEffectIndex.Invulnerable),
							new State("2",
								new Flash(0xFF0000, 1, 1),
								new TimedTransition(1600, "3")
							),
							new State("3",

								new Shoot(10, count: 8, projectileIndex: 0, coolDown: 9999),
								new Suicide()
							)
						)
					)
				)
				.Init("Baby Stone Gargoyle",
					new State(
                        new ScaleHP2(1000),
                        new Prioritize(
							new Follow(1, 8, 5),
							new Wander(0.25)
						),
						new Shoot(8, 1, projectileIndex: 0, coolDown: 100)
					)
				)
				
				;
    }
}