using System;
using System.Collections.Generic;
using Melia.Shared.Data.Database;
using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Const.Web;
using Melia.Shared.Util;
using Melia.Shared.World;
using Melia.Zone.Network.Helpers;
using Melia.Zone.Skills;
using Melia.Zone.World;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Groups;
using Melia.Zone.World.Items;
using Yggdrasil.Logging;

namespace Melia.Zone.Network
{
	public static partial class Send
	{
		public static class ZC_NORMAL
		{
			/// <summary>
			/// Starts a time action, displaying a progress bar and
			/// potentially putting the character in an animation.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="timeAction"></param>
			public static void TimeActionStart(Character character, TimeAction timeAction)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionStart);

				packet.PutInt(character.Handle);
				packet.PutLpString(timeAction.DisplayText);
				packet.PutLpString(timeAction.AnimationName);
				packet.PutFloat((float)timeAction.Duration.TotalSeconds);
				packet.PutByte(1);
				packet.PutLpString(timeAction.ButtonText);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Stops a time action, hiding the progress bar and reverting
			/// to the default animation.
			/// </summary>
			/// <param name="character"></param>
			public static void TimeActionEnd(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionEnd);

				packet.PutInt(character.Handle);
				packet.PutByte(0);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Timed Action (Worship, Talk)
			/// </summary>
			/// <param name="character"></param>
			/// <param name="dialog"></param>
			/// <param name="type"></param>
			/// <param name="duration"></param>
			/// <param name="isOn"></param>
			/// <param name="buttonText"></param>
			public static void TimeAction(Character character, string dialog, string type, float duration, bool isOn = true, string buttonText = "None")
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionStart);

				packet.PutInt(character.Handle);
				packet.PutLpString(dialog);
				packet.PutLpString(type);
				packet.PutFloat(duration);
				packet.PutByte(isOn);
				packet.PutLpString(buttonText);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Timed Action State (Worship, Talk)
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="isCompleted"></param>
			public static void TimeActionState(IActor actor, bool isCompleted)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionEnd);

				packet.PutInt(actor.Handle);
				packet.PutByte(isCompleted);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Plays an animation of an effect getting thrown from the
			/// entity to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="packetString1"></param>
			/// <param name="duration1"></param>
			/// <param name="packetString2"></param>
			/// <param name="duration2"></param>
			/// <param name="position"></param>
			public static void SkillProjectile(ICombatEntity entity, string packetString1, TimeSpan duration1, string packetString2, TimeSpan duration2, Position position)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString1, out var packetStringData1))
					throw new ArgumentException($"Packet string '{packetString1}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString2, out var packetStringData2))
					throw new ArgumentException($"Packet string '{packetString2}' not found.");

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillProjectile);

				packet.PutInt(entity.Handle);
				packet.PutInt(packetStringData1.Id);
				packet.PutFloat((float)duration1.TotalSeconds);
				packet.PutInt(packetStringData2.Id);
				packet.PutFloat((float)duration2.TotalSeconds);
				packet.PutPosition(position);
				packet.PutFloat(30);
				packet.PutFloat(0.2f);
				packet.PutFloat(0);
				packet.PutFloat(0);
				packet.PutFloat(1);
				packet.PutLong(0);
				packet.PutLpString("None");

				entity.Map.Broadcast(packet, entity);
			}

			/// <summary>
			/// Plays an animation of an effect getting thrown from the
			/// entity to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="position"></param>
			/// <param name="animationName1"></param>
			/// <param name="duration1"></param>
			/// <param name="animationName2"></param>
			/// <param name="duration2"></param>
			/// <param name="size"></param>
			/// <param name="scale"></param>
			public static void Skill_MissileThrow(IActor actor, Position position, string animationName1, float duration1, string animationName2, float duration2, float size, float scale)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString1) ||
					!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName2, out var packetString2))
				{
					Log.Warning("Skill_MissileThrow: Unable to find packet string {0} or {1}", animationName1, animationName2);
					return;
				}
				Skill_MissileThrow(actor, position, packetString1.Id, duration1, packetString2.Id, duration2, size, scale);
			}

			/// <summary>
			/// Plays an animation of an effect getting thrown from the
			/// entity to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="position"></param>
			/// <param name="animationId1"></param>
			/// <param name="duration1"></param>
			/// <param name="animationId2"></param>
			/// <param name="duration2"></param>
			/// <param name="count"></param>
			/// <param name="scale"></param>
			public static void Skill_MissileThrow(IActor actor, Position position, int animationId1, float duration1, int animationId2, float duration2, float count, float scale)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_MissileThrow);

				packet.PutInt(actor.Handle);
				packet.PutInt(animationId1);
				packet.PutFloat(duration1);
				packet.PutInt(animationId2);
				packet.PutFloat(duration2);
				packet.PutFloat(position.X);
				packet.PutFloat(position.Y);
				packet.PutFloat(position.Z);
				packet.PutFloat(count);
				packet.PutFloat(scale);
				packet.PutFloat(0);
				packet.PutFloat(0);
				packet.PutFloat(1);
				packet.PutLong(0);
				packet.PutLpString("None");

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Plays an animation of an effect falling from the
			/// sky to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skillClassName"></param>
			/// <param name="fallingEffectName"></param>
			/// <param name="duration1"></param>
			/// <param name="groundEffectName"></param>
			/// <param name="duration2"></param>
			/// <param name="position"></param>
			/// <exception cref="ArgumentException"></exception>
			public static void SkillFallingProjectile(IActor actor, string skillClassName, string fallingEffectName, float fallingEffectSize,
				string groundEffectName, float groundEffectSize, Position position, float f1, TimeSpan startDelay, float fallSpeed, float fallHeight, float f5, float f6)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(fallingEffectName, out var packetStringData1))
					throw new ArgumentException($"Packet string '{fallingEffectName}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(groundEffectName, out var packetStringData2))
					throw new ArgumentException($"Packet string '{groundEffectName}' not found.");

				SkillFallingProjectile(actor, skillClassName, packetStringData1.Id, fallingEffectSize, packetStringData2.Id, groundEffectSize, position, f1, startDelay, fallSpeed, fallHeight, f5, f6);
			}

			/// <summary>
			/// Plays an animation of an effect falling from the
			/// sky to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="skillClassName"></param>
			/// <param name="fallingEffectId"></param>
			/// <param name="fallingEffectSize"></param>
			/// <param name="groundEffectId"></param>
			/// <param name="groundEffectSize"></param>
			/// <param name="position"></param>
			/// <param name="f1"></param>
			/// <param name="startDelay"></param>
			/// <param name="fallSpeed"></param>
			/// <param name="fallHeight"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			public static void SkillFallingProjectile(IActor entity, string skillClassName, int fallingEffectId, float fallingEffectSize,
				int groundEffectId, float groundEffectSize, Position position, float f1, TimeSpan startDelay, float fallSpeed, float fallHeight, float f5, float f6)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillFallingProjectile);

				packet.PutInt(entity.Handle);
				packet.PutLpString(skillClassName);
				packet.PutInt(fallingEffectId);
				packet.PutFloat(fallingEffectSize);
				packet.PutInt(groundEffectId);
				packet.PutFloat(groundEffectSize);
				packet.PutPosition(position);
				packet.PutFloat(f1);
				packet.PutFloat((float)startDelay.TotalSeconds);
				packet.PutFloat(fallSpeed);
				packet.PutFloat(fallHeight);
				packet.PutFloat(f5);
				packet.PutFloat(f6);

				entity.Map.Broadcast(packet, entity);
			}

			/// <summary>
			/// Plays an animation of an item getting thrown from the
			/// entity to the position, where a second effect is played
			/// for the impact.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="str"></param>
			/// <param name="str2"></param>
			/// <param name="position"></param>
			/// <param name="animationName"></param>
			/// <param name="scale"></param>
			/// <param name="tossScale"></param>
			/// <param name="hangScale"></param>
			/// <param name="speed"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			/// <param name="f7"></param>
			/// <param name="itemScale"></param>
			/// <param name="itemAppearOnFloorDuration"></param>
			public static void Skill_ItemToss(IActor actor, string str, string str2, Position position, string animationName,
				float scale, float tossScale, float hangScale, float speed, float f5, float f6, float f7, float itemScale = 0, float itemAppearOnFloorDuration = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var packetString))
				{
					Log.Warning("Skill_ItemToss: Unable to find packet string {0}", animationName);
					return;
				}
				Skill_ItemToss(actor, str, str2, position, packetString.Id, scale, tossScale, hangScale, speed, f5, f6, f7, itemScale, itemAppearOnFloorDuration);
			}

			/// <summary>
			/// Skill Related ZC_Normal Packet
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="str"></param>
			/// <param name="str2"></param>
			/// <param name="position"></param>
			/// <param name="animationId"></param>
			/// <param name="scale"></param>
			/// <param name="tossScale"></param>
			/// <param name="hangScale"></param>
			/// <param name="speed"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			/// <param name="f7"></param>
			/// <param name="itemScale"></param>
			/// <param name="itemAppearOnFloorDuration"></param>
			public static void Skill_ItemToss(IActor actor, string str, string str2, Position position, int animationId,
				float scale, float tossScale, float hangScale, float speed, float f5, float f6, float f7, float itemScale = 0, float itemAppearOnFloorDuration = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Skill_ItemToss);
				packet.PutInt(actor.Handle);
				packet.PutLpString(str);
				packet.PutLpString(str2);
				packet.PutPosition(position);
				packet.PutInt(animationId);
				packet.PutFloat(scale);
				packet.PutFloat(tossScale);
				packet.PutFloat(hangScale);
				packet.PutFloat(speed);
				packet.PutFloat(f5);
				packet.PutFloat(f6);
				packet.PutFloat(f7);
				packet.PutFloat(itemScale);
				packet.PutFloat(itemAppearOnFloorDuration);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Skill Related ZC_Normal Packet
			/// </summary>
			/// <param name="character"></param>
			/// <param name="str"></param>
			/// <param name="str2"></param>
			/// <param name="position"></param>
			/// <param name="animationId1"></param>
			/// <param name="scale"></param>
			/// <param name="tossScale"></param>
			/// <param name="hangScale"></param>
			/// <param name="speed"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			/// <param name="f7"></param>
			/// <param name="itemScale"></param>
			/// <param name="itemAppearOnFloorDuration"></param>
			public static void Skill_ItemToss(Character character, string str, string str2, Position position, int animationId1,
				float scale, float tossScale, float hangScale, float speed, float f5, float f6, float f7, float itemScale = 0, float itemAppearOnFloorDuration = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Skill_ItemToss);
				packet.PutInt(character.Handle);
				packet.PutLpString(str);
				packet.PutLpString(str2);
				packet.PutPosition(position);
				packet.PutInt(animationId1);
				packet.PutFloat(scale);
				packet.PutFloat(tossScale);
				packet.PutFloat(hangScale);
				packet.PutFloat(speed);
				packet.PutFloat(f5);
				packet.PutFloat(f6);
				packet.PutFloat(f7);
				packet.PutFloat(itemScale);
				packet.PutFloat(itemAppearOnFloorDuration);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Play an effect/animation at a position
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="effectHandle"></param>
			/// <param name="animationId">Refer to packetstrings db</param>
			/// <param name="position">Effect's position</param>
			/// <param name="scale">Effect's scale</param>
			/// <param name="duration">Effect's maximum duration, some animations end before this</param>
			public static void PlayEffectAtPosition(IZoneConnection conn, int effectHandle, int animationId, Position position, float scale, float duration)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayEffectAtPosition);

				packet.PutInt(animationId);
				packet.PutPosition(position);
				packet.PutFloat(scale); // Scale ?
				packet.PutInt(effectHandle);
				packet.PutFloat(duration); // Duration ?

				conn.Send(packet);
			}

			/// <summary>
			/// Attaches effect to actor on client.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="animationName"></param>
			/// <param name="scale"></param>
			/// <param name="heightOffset">0 - Top, 1 - Mid, 2 - Bot</param>
			/// <param name="effectRelativeX">Offsets the effect's X position relative to the actor</param>
			/// <param name="effectRelativeY">Offsets the effect's Y position relative to the actor</param>
			/// <param name="effectRelativeZ">Offsets the effect's Z position relative to the actor</param>
			public static void AttachEffect(IActor actor, string animationName, float scale, HeightOffset heightOffset = HeightOffset.UNK, float effectRelativeX = 0, float effectRelativeY = 0, float effectRelativeZ = 0, byte b1 = 0, byte b2 = 0, byte b3 = 0, byte b4 = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var animation))
				{
					Log.Warning("AttachEffect: Unable to find animationName: {0}", animationName);
					return;
				}
				AttachEffect(actor, animation.Id, scale, heightOffset, effectRelativeX, effectRelativeY, effectRelativeZ, b1, b2, b3, b4);
			}

			/// <summary>
			/// Attaches effect to actor on client.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="packetString"></param>
			/// <param name="scale"></param>
			/// <param name="heightOffset">0 - Top, 1 - Mid, 2 - Bot</param>
			/// <param name="effectRelativeX">Offsets the effect's X position relative to the actor</param>
			/// <param name="effectRelativeY">Offsets the effect's Y position relative to the actor</param>
			/// <param name="effectRelativeZ">Offsets the effect's Z position relative to the actor</param>
			/// <param name="f4"></param>
			public static void AttachEffect(IActor actor, int packetString, float scale, HeightOffset heightOffset = HeightOffset.UNK, float effectRelativeX = 0, float effectRelativeY = 0, float effectRelativeZ = 0, byte b1 = 0, byte b2 = 0, byte b3 = 0, byte b4 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.AttachEffect);

				packet.PutInt(actor.Handle);
				packet.PutInt(packetString);
				packet.PutFloat(scale);
				packet.PutInt((int)heightOffset);
				packet.PutFloat(effectRelativeX);
				packet.PutFloat(effectRelativeY);
				packet.PutFloat(effectRelativeZ);
				packet.PutByte(b1);
				packet.PutByte(b2);
				packet.PutByte(b3);
				packet.PutByte(b4);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Attaches effect to actor on client.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="animationName"></param>
			/// <param name="scale"></param>
			/// <param name="heightOffset">0 - Top, 1 - Mid, 2 - Bot</param>
			/// <param name="effectRelativeX">Offsets the effect's X position relative to the actor</param>
			/// <param name="effectRelativeY">Offsets the effect's Y position relative to the actor</param>
			/// <param name="effectRelativeZ">Offsets the effect's Z position relative to the actor</param>
			public static void AttachEffect(IZoneConnection conn, IActor actor, string animationName, float scale, HeightOffset heightOffset = HeightOffset.UNK, float effectRelativeX = 0, float effectRelativeY = 0, float effectRelativeZ = 0, byte b1 = 0, byte b2 = 0, byte b3 = 0, byte b4 = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var animation))
				{
					Log.Warning("AttachEffect: Unable to find animationName: {0}", animationName);
					return;
				}
				AttachEffect(actor, animation.Id, scale, heightOffset, effectRelativeX, effectRelativeY, effectRelativeZ, b1, b2, b3, b4);
			}

			/// <summary>
			/// Originally LevelUp but renamed for general purpose
			/// Plays an effect used in certain situations like camp fire
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="packetString"></param>
			/// <param name="scale"></param>
			/// <param name="heightOffset">0 - Top, 1 - Mid, 2 - Bot</param>
			/// <param name="effectRelativeX">Offsets the effect's X position relative to the actor</param>
			/// <param name="effectRelativeY">Offsets the effect's Y position relative to the actor</param>
			/// <param name="effectRelativeZ">Offsets the effect's Z position relative to the actor</param>
			/// <param name="f4"></param>
			public static void AttachEffect(IZoneConnection conn, IActor actor, int packetString, float scale, HeightOffset heightOffset = HeightOffset.UNK, float effectRelativeX = 0, float effectRelativeY = 0, float effectRelativeZ = 0, byte b1 = 0, byte b2 = 0, byte b3 = 0, byte b4 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.AttachEffect);

				packet.PutInt(actor.Handle);
				packet.PutInt(packetString);
				packet.PutFloat(scale);
				packet.PutInt((int)heightOffset);
				packet.PutFloat(effectRelativeX);
				packet.PutFloat(effectRelativeY);
				packet.PutFloat(effectRelativeZ);
				packet.PutByte(b1);
				packet.PutByte(b2);
				packet.PutByte(b3);
				packet.PutByte(b4);

				conn.Send(packet);
			}

			/// <summary>
			/// Plays an animation effect.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			/// <param name="heightOffset"></param>
			/// <param name="b2"></param>
			/// <param name="scale"></param>
			/// <param name="animationName"></param>
			public static void PlayEffect(IZoneConnection conn, IActor actor, byte b1 = 1, string heightOffset = "BOT", byte b2 = 1, float scale = 1, string animationName = "F_pc_class_change", float f1 = 0, int associatedHandle = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var animation))
				{
					Log.Warning("PlayAnimation: Packet String not found with id {0}.", animationName);
					return;
				}

				if (!Enum.TryParse<HeightOffset>(heightOffset, out var hOffset))
					throw new ArgumentException($"Height offset '{heightOffset}' not found.");

				PlayEffect(conn, actor, b1, (int)hOffset, b2, scale, animation.Id, f1, associatedHandle);
			}

			/// <summary>
			/// Plays an animation effect.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			/// <param name="heightOffset"></param>
			/// <param name="b2"></param>
			/// <param name="scale"></param>
			/// <param name="animationId"></param>
			public static void PlayEffect(IZoneConnection conn, IActor actor, byte b1, int heightOffset, byte b2, float scale, int animationId, float f1 = 0, int associatedHandle = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayEffect);

				packet.PutInt(actor.Handle);
				packet.PutByte(b1); // Prev: 0
				packet.PutInt(heightOffset);
				packet.PutByte(b2); // Prev: 0
				packet.PutFloat(scale); // Effect size Prev: 6
				packet.PutInt(animationId);
				packet.PutFloat(f1);
				packet.PutInt(associatedHandle);

				conn.Send(packet);
			}

			/// <summary>
			/// Plays an animation effect.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			/// <param name="heightOffset"></param>
			/// <param name="b2"></param>
			/// <param name="scale"></param>
			/// <param name="animationName"></param>
			public static void PlayEffect(IActor actor, byte b1 = 1, string heightOffset = "BOT", byte b2 = 1, float scale = 1, string animationName = "F_pc_class_change", float f1 = 0, int associatedHandle = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var animation))
				{
					Log.Warning("PlayAnimation: Packet String not found with id {0}.", animationName);
					return;
				}

				if (!Enum.TryParse<HeightOffset>(heightOffset, out var hOffset))
					throw new ArgumentException($"Height offset '{heightOffset}' not found.");

				PlayEffect(actor, b1, (int)hOffset, b2, scale, animation.Id, f1, associatedHandle);
			}

			/// <summary>
			/// Plays an animation effect.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			/// <param name="heightOffset"></param>
			/// <param name="b2"></param>
			/// <param name="scale"></param>
			/// <param name="animationId"></param>
			public static void PlayEffect(IActor actor, byte b1, int heightOffset, byte b2, float scale, int animationId, float f1 = 0, int associatedHandle = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayEffect);

				packet.PutInt(actor.Handle);
				packet.PutByte(b1); // Prev: 0
				packet.PutInt(heightOffset);
				packet.PutByte(b2); // Prev: 0
				packet.PutFloat(scale); // Effect size Prev: 6
				packet.PutInt(animationId);
				packet.PutFloat(f1);
				packet.PutInt(associatedHandle);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Removes all effects from actor.
			/// </summary>
			/// <param name="actor"></param>
			public static void ClearEffects(IActor actor)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ClearEffects);

				packet.PutInt(actor.Handle);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Skill effect
			/// </summary>
			/// <param name="character"></param>
			/// <param name="packetString"></param>
			/// <param name="time"></param>
			/// <param name="str1"></param>
			/// <param name="str2"></param>
			public static void SkillEffect_14(Character character, int packetString, float time, string str1, string str2)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillEffect_14);

				packet.PutInt(character.Handle);
				packet.PutInt(packetString);
				packet.PutFloat(time);
				packet.PutLpString(str1);
				packet.PutLpString(str2);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Controls a skill's visual effects.
			/// </summary>
			/// <param name="forceId"></param>
			/// <param name="caster"></param>
			/// <param name="source"></param>
			/// <param name="target"></param>
			/// <param name="effect1PacketString"></param>
			/// <param name="effect1Scale"></param>
			/// <param name="effect2PacketString"></param>
			/// <param name="effect3PacketString"></param>
			/// <param name="effect3Scale"></param>
			/// <param name="effect4PacketString"></param>
			/// <param name="effect5PacketString"></param>
			/// <param name="speed"></param>
			/// <exception cref="ArgumentException">
			/// Thrown if any of the packet strings are not found.
			/// </exception>
			public static void PlayForceEffect(int forceId, IActor caster, IActor source, IActor target, string effect1PacketString, float effect1Scale, string effect2PacketString, string effect3PacketString, float effect3Scale, string effect4PacketString, string effect5PacketString, float speed)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(effect1PacketString, out var packetStringData1))
					throw new ArgumentException($"Packet string '{effect1PacketString}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(effect2PacketString, out var packetStringData2))
					throw new ArgumentException($"Packet string '{effect2PacketString}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(effect3PacketString, out var packetStringData3))
					throw new ArgumentException($"Packet string '{effect3PacketString}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(effect4PacketString, out var packetStringData4))
					throw new ArgumentException($"Packet string '{effect4PacketString}' not found.");

				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(effect5PacketString, out var packetStringData5))
					throw new ArgumentException($"Packet string '{effect5PacketString}' not found.");

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayForceEffect);

				packet.PutInt(forceId);

				packet.PutInt(caster.Handle);
				packet.PutInt(source.Handle);
				packet.PutInt(target.Handle);

				packet.PutInt(packetStringData1.Id);
				packet.PutFloat(effect1Scale);
				packet.PutInt(packetStringData2.Id);
				packet.PutInt(packetStringData3.Id);
				packet.PutFloat(effect3Scale);
				packet.PutInt(packetStringData4.Id);
				packet.PutInt(packetStringData5.Id);

				packet.PutFloat(speed);
				packet.PutFloat(0);
				packet.PutFloat(0);
				packet.PutFloat(0);
				packet.PutInt(0);
				packet.PutFloat(5);
				packet.PutFloat(5);
				packet.PutFloat(2);
				packet.PutInt(0);

				source.Map.Broadcast(packet, target);
			}

			/// <summary>
			/// Skill splash effects
			/// </summary>
			/// <param name="character"></param>
			/// <param name="target1"></param>
			/// <param name="target2"></param>
			/// <param name="animationName1"></param>
			/// <param name="f1"></param>
			/// <param name="animationName2"></param>
			/// <param name="animationName3"></param>
			/// <param name="f2"></param>
			/// <param name="animationName4"></param>
			/// <param name="animationName5"></param>
			/// <param name="f3"></param>
			/// <param name="f4"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			/// <param name="f7"></param>
			public static void SkillEffectSplash(IActor character, IActor target1, IActor target2,
			int effectHandle, string animationName1, float f1, string animationName2, string animationName3, float f2,
			string animationName4, string animationName5, float f3, float f4, float f5, float f6, float f7)
			{
				var animationId1 = 0;
				var animationId2 = 0;
				var animationId3 = 0;
				var animationId4 = 0;
				var animationId5 = 0;
				if (animationName1 != null && ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString1))
					animationId1 = packetString1.Id;
				if (animationName2 != null && ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString2))
					animationId2 = packetString2.Id;
				if (animationName3 != null && ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString3))
					animationId3 = packetString3.Id;
				if (animationName4 != null && ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString4))
					animationId4 = packetString4.Id;
				if (animationName5 != null && ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName1, out var packetString5))
					animationId5 = packetString5.Id;
				// Check for null values and replace with 0
				{
					//Log.Warning("SkillEffectSplash: Unable to find packet string id from name: {0}, {1}, {2}, {3}, {4}", animationName1, animationName2, animationName3, animationName4, animationName5);
				}
				SkillEffectSplash(character, target1, target2, effectHandle, animationId1, f1, animationId2,
					animationId3, f2, animationId4, animationId5, f3, f4, f5, f6, f7);
			}

			/// <summary>
			/// Skill splash effects
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="target1"></param>
			/// <param name="target2"></param>
			/// <param name="animationId1"></param>
			/// <param name="f1"></param>
			/// <param name="animationId2"></param>
			/// <param name="animationId3"></param>
			/// <param name="f2"></param>
			/// <param name="animationId4"></param>
			/// <param name="animationId5"></param>
			/// <param name="f3"></param>
			/// <param name="f4"></param>
			/// <param name="f5"></param>
			/// <param name="f6"></param>
			/// <param name="f7"></param>
			public static void SkillEffectSplash(IActor caster, IActor target1, IActor target2,
			int effectHandle, int animationId1, float f1, int animationId2, int animationId3, float f2,
			int animationId4, int animationId5, float f3, float f4, float f5, float f6, float f7)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayForceEffect);

				packet.PutInt(effectHandle);
				packet.PutInt(caster.Handle);
				packet.PutInt(target1.Handle);
				packet.PutInt(target2.Handle);
				packet.PutInt(animationId1);
				packet.PutFloat(f1);
				packet.PutInt(animationId2);
				packet.PutInt(animationId3);
				packet.PutFloat(f2);
				packet.PutInt(animationId4);
				packet.PutInt(animationId5);
				packet.PutFloat(f3);
				packet.PutFloat(f4);
				packet.PutEmptyBin(12);
				packet.PutFloat(f5);
				packet.PutFloat(f6);
				packet.PutFloat(f7);
				packet.PutInt(0);

				caster.Map.Broadcast(packet, caster);
			}

			/// <summary>
			/// Seen with 
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			/// <param name="i1"></param>
			public static void Unknown_1B(IActor actor, byte b1, int i1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_1B);

				packet.PutByte(b1);
				packet.PutInt(i1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Appears to update information about a skill effect on the
			/// clients in range of entity.
			/// </summary>
			/// <remarks>
			/// Observed updating the origin position of the Earthquake
			/// effect. Once the packet was sent once, the dust cloud
			/// effect would always appear at the same location, even
			/// when the packet was no longer sent. Only if it was
			/// sent did the location update and the effect appeared
			/// in the right place.
			/// </remarks>
			/// <param name="entity"></param>
			/// <param name="targetHandle"></param>
			/// <param name="originPos"></param>
			/// <param name="direction"></param>
			/// <param name="farPos"></param>
			public static void UpdateSkillEffect(ICombatEntity entity, int targetHandle, Position originPos, Direction direction, Position farPos)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.UpdateSkillEffect);

				packet.PutInt(entity.Handle);
				packet.PutInt(0);
				packet.PutInt(0);
				packet.PutInt(targetHandle);
				packet.PutPosition(originPos);
				packet.PutDirection(direction);
				packet.PutPosition(farPos);

				entity.Map.Broadcast(packet, entity);
			}

			/// <summary>
			/// Set an Actor's Color (Yellow, Magenta, Cyan, Alpha)
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="yellow"></param>
			/// <param name="magenta"></param>
			/// <param name="cyan"></param>
			/// <param name="alpha"></param>
			/// <param name="transitionDuration"></param>
			/// <param name="b6"></param>
			public static void SetActorColor(IActor actor,
				byte yellow, byte magenta, byte cyan,
				byte alpha, float transitionDuration, byte b6)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetEntityColor);

				packet.PutInt(actor.Handle);
				packet.PutByte(yellow);
				packet.PutByte(magenta);
				packet.PutByte(cyan);
				packet.PutByte(alpha);
				packet.PutByte(1);
				packet.PutFloat(transitionDuration);
				packet.PutByte(b6);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Set Entity's Color (Yellow, Magenta, Cyan, Alpha)
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="actor"></param>
			/// <param name="yellow"></param>
			/// <param name="magenta"></param>
			/// <param name="cyan"></param>
			/// <param name="alpha"></param>
			/// <param name="transitionDuration"></param>
			/// <param name="b6"></param>
			public static void SetActorColor(IZoneConnection conn, IActor actor,
				byte yellow, byte magenta, byte cyan,
				byte alpha, float transitionDuration, byte b6)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetEntityColor);

				packet.PutInt(actor.Handle);
				packet.PutByte(yellow);
				packet.PutByte(magenta);
				packet.PutByte(cyan);
				packet.PutByte(alpha);
				packet.PutByte(1);
				packet.PutFloat(transitionDuration);
				packet.PutByte(b6);

				conn.Send(packet);
			}

			/// <summary>
			/// Call a lua func
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="animationName"></param>
			/// <param name="i1"></param>
			/// <param name="i2"></param>
			/// <param name="b1"></param>
			/// <param name="b2"></param>
			/// <param name="f1"></param>
			public static void Skill_CallLuaFunc(IActor actor, string animationName, int i1, int i2, byte b1, byte b2, float f1)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var animation))
				{
					Log.Warning("Skill_CallLuaFunc: Unable to find animationName: {0}", animationName);
					return;
				}
				Skill_CallLuaFunc(actor, animation.Id, i1, i2, b1, b2, f1);
			}

			/// <summary>
			/// Call a lua func
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="luaFuncPacketString"></param>
			/// <param name="i1"></param>
			/// <param name="i2"></param>
			/// <param name="b1"></param>
			/// <param name="b2"></param>
			/// <param name="f1"></param>
			public static void Skill_CallLuaFunc(IActor actor, int luaFuncPacketString, int i1, int i2, byte b1, byte b2, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_CallLuaFunc);

				packet.PutInt(actor.Handle);
				packet.PutInt(luaFuncPacketString);
				packet.PutInt(i1);
				packet.PutInt(i2);
				packet.PutByte(b1);
				packet.PutByte(b2);
				packet.PutFloat(f1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Skill Properties
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="b1"></param>
			/// <param name="skill"></param>
			/// <param name="propertyIds"></param>
			public static void SkillProperties(IZoneConnection conn, byte b1, Skill skill, params string[] propertyIds)
			{
				var properties = skill.Properties.GetSelect(propertyIds);
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSkillProperties);

				packet.PutByte(b1);
				packet.PutInt((int)skill.Id);
				packet.PutShort(properties.GetByteCount());
				packet.AddProperties(properties);

				conn.Send(packet);
			}

			/// <summary>
			/// Dummy (Unknown Purpose)
			/// Assister Summon Skill Related?
			/// </summary>
			/// <param name="actor"></param>
			public static void SetScale(Actor actor, string animationName, float animationScale, float animationSpeed = 0, byte b1 = 0, short s1 = 0)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var packetString))
					throw new ArgumentException($"Packet string '{animationName}' not found.");
				SetScale(actor, packetString.Id, animationScale, animationSpeed, b1, s1);
			}

			/// <summary>
			/// Dummy (Unknown Purpose)
			/// Assister Summon Skill Related?
			/// </summary>
			/// <param name="actor"></param>
			public static void SetScale(Actor actor, int animationType, float animationScale, float animationSpeed = 0, byte b1 = 0, short s1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetScale);

				packet.PutInt(actor.Handle);
				packet.PutInt(animationType);
				packet.PutFloat(animationScale);
				packet.PutFloat(animationSpeed);
				packet.PutByte(b1);
				packet.PutShort(s1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Dummy (Unknown Purpose)
			/// </summary>
			/// <param name="entity"></param>
			public static void PlaySound(Character entity)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlaySound);

				packet.PutInt(entity.Handle);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Dummy (Unknown Purpose)
			/// </summary>
			/// <param name="entity"></param>
			public static void Knockback(Character entity, Position pos1, Position pos2, Direction direction, float f1, float f2, float f3, float f4, byte b1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Knockback);

				packet.PutPosition(pos1);
				packet.PutPosition(pos2);
				packet.PutDirection(direction);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutFloat(f3);
				packet.PutFloat(f4);
				packet.PutInt(entity.Handle);
				packet.PutByte(b1);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Makes monster fade out over the given amount of time.
			/// </summary>
			/// <param name="monster"></param>
			/// <param name="duration"></param>
			public static void FadeOut(IMonster monster, TimeSpan duration)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.FadeOut);

				packet.PutInt(monster.Map.Id);
				packet.PutInt(monster.GenType);
				packet.PutFloat((float)duration.TotalSeconds);

				monster.Map.Broadcast(packet, monster, false);
			}

			/// <summary>
			/// Unknown effect currently works with I_SYS_heal2 as message and a number as parameter
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="message"></param>
			/// <param name="parameter"></param>
			public static void TextEffect(IActor actor, string message, string parameter)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TextEffect);

				packet.PutInt(actor.Handle);
				packet.PutLpString(message);
				packet.PutLpString(parameter);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Unknown effect currently works with I_SYS_heal2 as message and a number as parameter
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="message"></param>
			/// <param name="parameter"></param>
			public static void TextEffect(Character entity, string message, string parameter)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TextEffect);

				packet.PutInt(entity.Handle);
				packet.PutLpString(message);
				packet.PutLpString(parameter);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Updates the number of purchased character slots.
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="count"></param>
			public static void BarrackSlotCount(IZoneConnection conn, int count)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.BarrackSlotCount);

				packet.PutInt(count);

				conn.Send(packet);
			}

			/// <summary>
			/// Modify attack stance
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="stanceName"></param>
			/// <param name="i1"></param>
			public static void Skill_ModifyAttackStance(Character entity, string stanceName, int i1 = 1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_ModifyAttackStance);

				packet.PutInt(entity.Handle);
				packet.PutInt(i1);
				packet.PutLpString(stanceName);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Unknown purpose yet. It could be a "target" packet. (this actor is targeting "id" actor
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skill"></param>
			/// <param name="direction"></param>
			public static void Skill_40(IActor actor, Skill skill, Direction direction, int i1,
				float f1, float f2, float f3, int i2, float f4, int i3, int i4, float f5, int i5)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_40);

				packet.PutInt(actor.Handle);
				packet.PutInt((int)skill.Id);
				packet.PutInt(actor.Handle);
				packet.PutDirection(actor.Direction);
				packet.PutInt(i1);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutFloat(f3);
				packet.PutInt(i2);
				packet.PutFloat(f4);
				packet.PutInt(i3);
				packet.PutInt(i4);
				packet.PutFloat(f5);
				packet.PutInt(i5);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Attack broadcast?
			/// </summary>
			/// <param name="actor"></param>
			public static void AttackCancel(IActor actor)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.AttackCancel);

				packet.PutInt(actor.Handle);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Usually after a skill has finished casting, might clean up animation?
			/// </summary>
			/// <remarks>
			/// i1 seems to be always 0
			/// </remarks>
			/// <param name="source"></param>
			/// <param name="i1"></param>
			public static void Skill_45(IActor source, int i1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_45);
				packet.PutInt(i1);

				source.Map.Broadcast(packet, source);
			}

			/// <summary>
			/// Skill cancel
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skillId"></param>
			public static void SkillCancel(IActor actor, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillCancel);

				packet.PutInt(actor.Handle);
				packet.PutInt((int)skillId);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Sends account properties to character's client.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="propertyNames"></param>
			public static void AccountProperties(Character character, params string[] propertyNames)
			{
				var account = character.Connection.Account;
				var properties = propertyNames != null ? account.Properties.GetSelect(propertyNames) : account.Properties.GetAll();
				var propertySize = properties.GetByteCount();

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.AccountProperties);

				packet.PutLong(account.Id);
				packet.PutShort(propertySize);
				packet.AddProperties(properties);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Starts an effect associated with dynamic casted skill.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="skillId"></param>
			public static void Skill_DynamicCastStart(Character character, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_DynamicCastStart);

				packet.PutInt(character.Handle);
				packet.PutInt((int)skillId);

				character.Map.Broadcast(packet, character);
			}

			/// <summary>
			/// Ends an effect associated with dynamic casted skill.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="skillId"></param>
			/// <param name="value"></param>
			public static void Skill_DynamicCastEnd(Character character, SkillId skillId, float value)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_DynamicCastEnd);

				packet.PutInt(character.Handle);
				packet.PutInt((int)skillId);
				packet.PutFloat(value);
				packet.PutByte(0);

				character.Map.Broadcast(packet, character);
			}

			/// <summary>
			/// NPC Play a Track (Client side direction)
			/// </summary>
			public static void NPC_PlayTrack(Character entity, string trackName, int i1, int i2, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.NPC_PlayTrack);
				packet.PutInt(entity.Handle);
				packet.PutLpString(trackName);
				packet.PutInt(i1);
				packet.PutInt(i2);
				packet.PutFloat(f1);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// NPC Play a Track (Client side direction)
			/// </summary>
			public static void NPC_PlayTrack(Character character, Character entity, string trackName, int i1, int i2, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.NPC_PlayTrack);

				packet.PutInt(entity.Handle);
				packet.PutLpString(trackName);
				packet.PutInt(i1);
				packet.PutInt(i2);
				packet.PutFloat(f1);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// NPC Position For a script?
			/// </summary>
			/// <param name="character"></param>
			/// <param name="entity"></param>
			public static void SetNPCTrackPosition(Character character, Character entity)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetNPCTrackPosition);

				packet.PutInt(entity.Handle);
				packet.PutPosition(entity.Position);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Client cutscene to play
			/// </summary>
			/// <param name="character"></param>
			/// <param name="cutSceneType"></param>
			/// <param name="b"></param>
			/// <param name="trackOrCharacter"></param>
			public static void LoadCutscene(Character character, int cutSceneType, bool b, string trackOrCharacter)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.LoadCutscene);

				packet.PutInt(cutSceneType);
				packet.PutByte(b);
				packet.PutLpString(trackOrCharacter);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Creates a skill in client (MONSKL_CRE_PAD)
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="skill"></param>
			/// <param name="animationName"></param>
			/// <param name="position"></param>
			/// <param name="direction"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			/// <param name="skillHandle"></param>
			/// <param name="f3"></param>
			public static void SkillPad(ICombatEntity caster, Skill skill, string animationName,
				Position position, Direction direction, float f1, float f2, int skillHandle,
				float f3, bool isVisible = true)
			{
				if (ZoneServer.Instance.Data.PacketStringDb.TryFind(animationName, out var packetString))
					SkillPad(caster, skill, packetString.Id, position, direction, f1, f2, skillHandle, f3, isVisible);
			}

			/// <summary>
			/// Creates a pad in client (MONSKL_CRE_PAD)
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="skill"></param>
			/// <param name="packetStringId"></param>
			/// <param name="position"></param>
			/// <param name="direction"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			/// <param name="skillHandle"></param>
			/// <param name="f3"></param>
			public static void SkillPad(ICombatEntity caster, Skill skill, int packetStringId,
				Position position, Direction direction, float f1, float f2, int skillHandle,
				float f3, bool isVisible = true)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillRunScript);

				packet.PutInt(caster.Handle);
				packet.PutInt(packetStringId);
				packet.PutInt((int)skill.Id);
				packet.PutInt(skill.Level); // Skill Level ?
				packet.PutPosition(position);
				packet.PutDirection(direction);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutInt(skillHandle);
				packet.PutInt(isVisible ? 1 : 0);
				packet.PutEmptyBin(13); // Unknown Bytes
				packet.PutFloat(f3);
				packet.PutEmptyBin(16); // Unknown Bytes

				caster.Map.Broadcast(packet, caster);
			}

			/// <summary>
			/// Set actor's height
			/// Used in Shield Lob
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skillHandle"></param>
			/// <param name="height"></param>
			/// <param name="b1">Doesn't seem to do anything</param>
			public static void Skill_SetActorHeight(IActor actor, int skillHandle, float height, byte b1 = 1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_SetActorHeight);

				packet.PutInt(skillHandle);
				packet.PutInt(actor.Handle);
				packet.PutFloat(height);
				packet.PutByte(b1);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Creates a particle effect (or set desired animation)
			/// </summary>
			/// <param name="character"></param>
			/// <param name="actorId"></param>
			/// <param name="enable"></param>
			public static void ParticleEffect(Character character, int actorId, int enable)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ParticleEffect);

				packet.PutInt(actorId);
				packet.PutInt(enable);

				character.Map.Broadcast(packet);
			}

			/// <summary>
			/// A "skill" created via (Skill) is moved in a certain direction
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="skillHandle"></param>
			/// <param name="position"></param>
			/// <param name="b1"></param>
			/// <param name="movementSpeed"></param>
			/// <param name="f2"></param>
			public static void Skill_EffectMovement(IActor caster, int skillHandle, Position position, float movementSpeed, byte b1 = 1, float f2 = 1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_EffectMovement);

				packet.PutInt(skillHandle);
				packet.PutPosition(position);
				packet.PutByte(b1);
				packet.PutFloat(movementSpeed);
				packet.PutFloat(f2);

				caster.Map.Broadcast(packet, caster);
			}

			/// <summary>
			/// A "skill" created via (Skill) is moved in a certain direction
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skillHandle"></param>
			/// <param name="i1"></param>
			public static void Skill_Unknown_64(IActor actor, int skillHandle, int i1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_64);

				packet.PutInt(skillHandle);
				packet.PutInt(i1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Changes character behavior for a cutscene.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="active">Whether the cutscene is active.</param>
			/// <param name="movable">Whether the client can still move the character. If not, the server can control it.</param>
			/// <param name="hideUi">Whether to hide the UI while active.</param>
			public static void SetupCutscene(Character character, bool active, bool movable, bool hideUi)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetupCutscene);

				packet.PutByte(active);
				packet.PutByte(movable);
				packet.PutByte(hideUi);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Client cutscene to play
			/// </summary>
			/// <param name="character"></param>
			/// <param name="trackName"></param>
			/// <param name="actors"></param>
			public static void StartCutscene(Character character, string trackName, params IActor[] actors)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.CutsceneTrack);

				packet.PutLpString(trackName);
				packet.PutLong(1);
				packet.PutInt(actors.Length + 2);
				packet.PutInt(0);
				packet.PutInt(0);
				for (var i = 0; i < actors.Length; i++)
					packet.PutInt(actors[i].Handle);
				packet.PutInt(1);
				packet.PutInt(character.Handle);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Client cutscene to play
			/// </summary>
			/// <param name="character"></param>
			/// <param name="trackName"></param>
			/// <param name="actors"></param>
			public static void StartCutscene(Character character, string trackName, params int[] actors)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.CutsceneTrack);

				packet.PutLpString(trackName);
				packet.PutLong(1);
				packet.PutInt(actors.Length);
				packet.PutInt(0);
				packet.PutInt(0);
				//packet.PutInt(character.Handle);
				for (var i = 0; i < actors.Length; i++)
					packet.PutInt(actors[i]);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Set's the track frame to advance to.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="frame"></param>
			public static void SetTrackFrame(Character character, int frame)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetTrackFrame);

				packet.PutInt(frame);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Hide a NPC until track starts
			/// </summary>
			/// <param name="character"></param>
			/// <param name="actor"></param>
			public static void SetInvisible(Character character, IActor actor, float f1 = 0)
				=> SetInvisible(character.Connection, actor, f1);

			/// <summary>
			/// Hide a NPC until track starts
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="actor"></param>
			public static void SetInvisible(IZoneConnection conn, IActor actor, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetInvisible);

				packet.PutInt(actor.Handle);
				packet.PutFloat(f1);

				conn.Send(packet);
			}

			/// <summary>
			/// Hide a NPC until track starts
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="f1">Could be transition duration</param>
			public static void SetInvisible(IActor actor, float f1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetInvisible);

				packet.PutInt(actor.Handle);
				packet.PutFloat(f1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Adjusts the skill speed for a skill.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="skillId"></param>
			/// <param name="value"></param>
			public static void SetSkillSpeed(Character character, int skillId, float value)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSkillSpeed);

				packet.PutInt(skillId);
				packet.PutFloat(value);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Adjusts the hit delay for a skill.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="skillId"></param>
			public static void SetHitDelay(Character character, int skillId, float value)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetHitDelay);

				packet.PutInt(skillId);
				packet.PutFloat(value);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Adjusts the hit delay for a skill.
			/// </summary>
			/// <param name="character"></param>
			/// <param name="skillId"></param>
			public static void SetSkillUseOverHeat(Character character, int skillId, float value)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSkillUseOverHeat);

				packet.PutInt(skillId);
				packet.PutFloat(value);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Reset skill ?
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="skillId"></param>
			public static void SetSkill_7B(IActor actor, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSkill_7B);

				packet.PutInt(actor.Handle);
				packet.PutInt((int)skillId);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Sent with Ice Wall
			/// </summary>
			/// <remarks>
			/// Originally using Character sent to a single connection
			/// now broadcasted with an IActor.
			/// </remarks>
			/// <param name="actor"></param>
			/// <param name="skillHandle"></param>
			/// <param name="f1"></param>
			public static void Skill_7F(IActor actor, int skillHandle, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_7F);

				packet.PutInt(skillHandle);
				packet.PutFloat(f1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Set the main attack skill (access by Z key).
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="skillId"></param>
			public static void SetMainAttackSkill(Character entity, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetMainAttackSkill);

				packet.PutInt(entity.Handle);
				packet.PutInt((int)skillId);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Used for toggling a skill?
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="skillId"></param>
			public static void SkillToggle(Character entity, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SkillToggle);

				packet.PutInt(entity.Handle);
				packet.PutInt((int)skillId);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Unknown Skill related packet
			/// Sent during Shield Lob
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			/// <param name="f3"></param>
			/// <param name="f4"></param>
			public static void Skill_88(IActor actor, float f1 = 0, float f2 = -1, float f3 = 0.2f, float f4 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_88);

				packet.PutInt(actor.Handle);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutFloat(f3);
				packet.PutFloat(f4);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Pet play animation/state?
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="companion"></param>
			public static void PetPlayAnimation(IZoneConnection conn, Companion companion, int animationId = 8576, int i1 = 1, byte b1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PetPlayAnimation);

				packet.PutInt(companion.Handle);
				packet.PutInt(animationId);
				packet.PutInt(i1);
				packet.PutByte(b1);

				conn.Send(packet);
			}

			/// <summary>
			/// Show UI Effect
			/// </summary>
			/// <param name="character"></param>
			/// <param name="item"></param>
			/// <param name="style"></param>
			/// <param name="type"></param>
			public static void ShowItemBalloon(Character character, Item item = null, string type = "reward_itembox", string style = "{@st43}", string systemMsg = "AppraisalSuccess", float duration = 3)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(style, out var styleData))
				{
					throw new ArgumentException($"Packet string '{style}' not found.");
				}
				if (!ZoneServer.Instance.Data.SystemMessageDb.TryFind(systemMsg, out var systemMsgData))
				{
					throw new ArgumentException($"System message '{systemMsg}' not found.");
				}
				ShowItemBalloon(character, item, type, styleData.Id, systemMsgData.ClassId, duration);
			}

			/// <summary>
			/// Show UI Effect
			/// </summary>
			/// <param name="character"></param>
			/// <param name="item"></param>
			/// <param name="type"></param>
			/// <param name="style"></param>
			/// <param name="systemMsg"></param>
			/// <param name="duration"></param>
			public static void ShowItemBalloon(Character character, Item item, string type, int style, int systemMsg, float duration)
			{
				var properties = item.Properties.GetAll();
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ShowItemBalloon);

				packet.PutByte(1);
				packet.PutInt(character.Handle);
				packet.PutByte((byte)(item != null ? 0 : 1));
				if (item != null)
				{
					packet.PutInt(style);
					packet.PutInt(systemMsg);
					packet.PutShort(1);
					packet.PutByte(0);
					packet.PutFloat(duration);
					packet.PutFloat(0);
					packet.PutLpString(type);
					packet.PutInt(item.Amount);
					packet.PutInt(item.Id);
					packet.PutShort(properties.GetByteCount());
					packet.AddProperties(properties);
				}

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Show book with text
			/// </summary>
			/// <param name="entity"></param>
			public static void ShowBook(Character entity, string text)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.ShowBook);
				packet.PutInt(entity.Handle);
				packet.PutLpString(text);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Show scroll background with text
			/// </summary>
			/// <param name="entity"></param>
			public static void ShowScroll(Character entity, string text)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.ShowScroll);
				packet.PutInt(entity.Handle);
				packet.PutLpString(text);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Sends associated pets for a character.
			/// </summary>
			/// <param name="character"></param>
			public static void PetInfo(Character character)
			{
				var companions = character.GetCompanions();

				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.PetInfo);
				packet.PutInt(4); // 3 or 4
				packet.PutInt(companions.Length);
				foreach (var companion in companions)
					packet.AddCompanion(companion);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Pet Unknown?
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="companion"></param>
			public static void Pet_AssociateWorldId(IZoneConnection conn, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Pet_AssociateWorldId);
				packet.PutInt(companion.Handle);
				packet.PutLong(companion.ObjectId); // ?
				packet.PutShort(0); // 0
				packet.PutByte(0); // 0

				conn.Send(packet);
			}

			/// <summary>
			/// Pet Associate World Id and Handle
			/// </summary>
			/// <param name="character"></param>
			/// <param name="companion"></param>
			public static void Pet_AssociateHandleWorldId(Character character, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Pet_AssociateHandleWorldId);
				packet.PutInt(companion.Handle);
				packet.PutLong(companion.ObjectId);
				packet.PutByte(1);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Pet Unknown?
			/// </summary>
			/// <param name="character"></param>
			/// <param name="companion"></param>
			public static void PetExpUpdate(Character character, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PetExpUp);
				packet.PutLong(companion.ObjectId);
				packet.PutLong(companion.Experience);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Buff from Riding an entity
			/// </summary>
			/// <param name="owner"></param>
			/// <param name="subActor"></param>
			/// <param name="b1"></param>
			/// <param name="b2"></param>
			/// <param name="b3"></param>
			/// <param name="packetString"></param>
			/// <param name="b4"></param>
			public static void PetBuff(IActor owner, IActor subActor, byte b1, byte b2, byte b3, string packetString, byte b4)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString, out var data))
				{
					Log.Warning("PetBuff: Unknown packet string {0}.", packetString);
					return;
				}
				PetBuff(owner, subActor, b1, b2, b3, data.Id, b4);
			}

			/// <summary>
			/// Buff from Riding an entity
			/// </summary>
			/// <param name="owner"></param>
			/// <param name="subActor"></param>
			/// <param name="b1"></param>
			/// <param name="b2"></param>
			/// <param name="b3"></param>
			/// <param name="packetString"></param>
			/// <param name="b4"></param>
			public static void PetBuff(IActor owner, IActor subActor, byte b1, byte b2, byte b3, int packetString, byte b4)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PetBuff);

				packet.PutInt(owner.Handle);
				packet.PutInt(subActor.Handle);
				packet.PutByte(b1);
				packet.PutByte(b2);
				packet.PutByte(b3);
				packet.PutInt(packetString);
				packet.PutByte(b4);

				subActor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Ride Pet
			/// </summary>
			/// <param name="character"></param>
			/// <param name="companion"></param>
			public static void RidePet(Character character, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.RidePet);

				packet.PutInt(character.Handle);
				packet.PutInt(companion.Handle);
				packet.PutByte(companion.IsRiding);
				packet.PutByte(companion.IsRiding);
				packet.PutLpString(companion.Data.ClassName);

				character.Map.Broadcast(packet);
			}

			/// <summary>
			/// Pet handle association?
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="companion"></param>
			public static void PetOwner(IZoneConnection conn, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PetOwner);

				packet.PutInt(companion.Handle);
				packet.PutInt(companion.OwnerHandle);

				conn.Send(packet);
			}

			/// <summary>
			/// Offset Y an entity's position from "Ground"
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="yOffset"></param>
			public static void Skill_OffsetY(IActor actor, float yOffset)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.OffsetY);
				packet.PutInt(actor.Handle);
				packet.PutFloat(yOffset);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Related to pet flying?
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="yOffset"></param>
			public static void PetFlying(Character entity, float yOffset)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetPetDefaultAnimation);
				packet.PutInt(entity.Handle);
				packet.PutFloat(yOffset);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Offset Y an entity's position from "Ground"
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="yOffset"></param>
			public static void SetPetDefaultAnimation(Character entity, int defaultAnimationId)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetPetDefaultAnimation);
				packet.PutInt(entity.Handle);
				packet.PutInt(defaultAnimationId);

				entity.Map.Broadcast(packet);
			}


			/// <summary>
			/// Skill Jump/Knockback?
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="position"></param>
			/// <param name="height"></param>
			/// <param name="angle"></param>
			/// <param name="time1"></param>
			/// <param name="easeIn"></param>
			/// <param name="time2"></param>
			/// <param name="easeOut"></param>
			public static void LeapJump(IActor actor, Position position,
				float height, float angle, float time1, float easeIn, float time2, float easeOut)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_MoveJump);

				packet.PutInt(actor.Handle);
				packet.PutPosition(position);
				packet.PutFloat(height);
				packet.PutFloat(angle);
				packet.PutFloat(time1);
				packet.PutFloat(easeIn);
				packet.PutFloat(time2);
				packet.PutFloat(easeOut);

				actor.Map.Broadcast(packet, actor);
			}


			/// <summary>
			/// Unknown Purpose Yet.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			public static void Skill_Unknown_C6(IActor actor, byte b1 = 1)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_Unknown_C6);
				packet.PutInt(actor.Handle);
				packet.PutByte(b1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Skill Related - Krivis Divine Stigma
			/// Unknown Purpose Yet.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="b1"></param>
			public static void Skill_Unknown_C7(IActor actor, IActor target,
				float f1 = 0.25f, float f2 = 1f, int packetString = 350005,
				int i1 = 0, int i2 = 2, int i3 = 0, float f3 = 1f)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_Unknown_C7);
				packet.PutInt(actor.Handle);
				packet.PutInt(target.Handle);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutInt(packetString);
				packet.PutInt(i1);
				packet.PutInt(i2);
				packet.PutInt(i3);
				packet.PutFloat(f3);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// List of item collection an account has.
			/// </summary>
			/// <param name="character"></param>
			public static void ItemCollectionList(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.ItemCollectionList);
				packet.Zlib(true, zpacket =>
				{
					zpacket.PutLong(character.ObjectId);
					zpacket.PutInt(0);
					/**
					zpacket.PutInt(character.ItemCollections.Count);
					foreach (var collection in character.ItemCollections)
					{
						zpacket.PutShort(collection.Id);
						zpacket.PutInt(collection.Items.Count);
						foreach (var collectionItem in collection.Items)
						{
							zpacket.PutInt(collectionItem.Id);
							zpacket.PutLong(collectionItem.Id);
							zpacket.PutShort(0); // Not too sure what this is.
						}
					}
					**/
				});

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Sent after unlocking a collection
			/// </summary>
			/// <param name="character"></param>
			public static void UnlockCollection(Character character, int collectionId)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.UnlockCollection);
				packet.PutLong(character.ObjectId);
				packet.PutInt(collectionId);

				character.Connection.Send(packet);
			}

			public static void Unknown_E0(Character entity)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_E0);

				packet.PutInt(entity.Handle);
				packet.PutByte(0);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Plays a text effect on actor.
			/// </summary>
			/// <param name="character"></param>
			public static void PlayTextEffect(IActor actor, IActor caster, string packetString, float argNum, string argStr = null)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString, out var packetStringData))
					throw new ArgumentException($"Packet string '{packetString}' not found.");
				PlayTextEffect(actor, caster, packetStringData.Id, argNum, argStr);
			}

			/// <summary>
			/// Plays a text effect on actor.
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="caster"></param>
			/// <param name="packetStringId"></param>
			/// <param name="argNum"></param>
			/// <param name="argStr"></param>
			public static void PlayTextEffect(IActor actor, IActor caster, int packetStringId, float argNum, string argStr = null)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayTextEffect);

				packet.PutInt(actor.Handle);
				packet.PutInt(caster.Handle);
				packet.PutInt(packetStringId);
				packet.PutFloat(argNum);

				if (argStr == null)
					packet.PutShort(-1);
				else
					packet.PutLpString(argStr);

				packet.PutInt(0);
				packet.PutInt(0);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Sent during login for unknown purpose
			/// </summary>
			/// <param name="character"></param>
			public static void Unknown_E4(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Unknown_E5);
				packet.PutInt(0);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// NPC Dialog in Floating Gold Text
			/// </summary>
			/// <param name="character"></param>
			/// <param name="dialogKey"></param>
			/// <param name="duration"></param>
			public static void Notice(Character character, string dialogKey, float duration)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Notice);
				packet.PutLpString(dialogKey);
				packet.PutFloat(duration);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Sends the total amount of players with each job
			/// </summary>
			/// <param name="character"></param>
			public static void JobCount(Character character)
			{
				var jobDictionary = ZoneServer.Instance.Database.GetGlobalJobCount();
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.GlobalJobCount);

				packet.PutLong(character.ObjectId);
				packet.PutInt(jobDictionary.Count);
				foreach (var job in jobDictionary)
				{
					var jobData = ZoneServer.Instance.Data.JobDb.Find((JobId)job.Key);
					packet.PutLpString(jobData.ClassName);
					packet.PutInt(job.Value);
				}

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Broadcast party member data
			/// </summary>
			/// <param name="party"></param>
			/// <param name="member"></param>
			public static void PartyMemberData(PartyMember member, Party party)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.PartyMemberData);
				packet.PutByte(member.IsOnline);
				packet.PutByte((byte)party.Type);
				packet.PutLong(party.ObjectId);
				packet.PutLong(member.AccountObjectId);
				packet.AddPartyMember(member);

				party.Broadcast(packet);
			}

			/// <summary>
			/// Server response on Party Property Change
			/// </summary>
			/// <param name="party"></param>
			public static void PartyNameChange(Party party)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PartyNameChange);
				packet.PutByte((byte)party.Type);
				packet.PutLong(party.ObjectId);
				packet.PutInt(0);
				packet.PutLong(party.Owner.ObjectId);
				packet.PutLpString(party.Name);
				packet.PutInt(1);
				packet.PutByte(1);

				party.Broadcast(packet);
			}

			/// <summary>
			/// Sends Party Invite UI to player
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="sender"></param>
			public static void PartyInvite(Character character, Character sender, PartyType partyType)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.PartyInvite);
				packet.PutByte((byte)partyType);
				packet.PutLong(sender.AccountObjectId);
				packet.PutLpString(sender.TeamName);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Server response on Party Property Change
			/// </summary>
			/// <param name="party"></param>
			/// <param name="property"></param>
			public static void PartyPropertyUpdate(Party party, PropertyList properties)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PartyPropertyChange);
				packet.PutByte((byte)party.Type);
				packet.PutLong(party.ObjectId);
				packet.AddProperties(properties);

				party.Broadcast(packet);
			}

			/// <summary>
			/// Server response on Party Member Property Change
			/// </summary>
			/// <param name="party"></param>
			/// <param name="property"></param>
			public static void PartyMemberPropertyUpdate(Party party, Character entity, PropertyList properties)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.PartyMemberPropertyChange);
				packet.PutByte((byte)party.Type);
				packet.PutLong(party.ObjectId);
				packet.PutLong(entity.ObjectId);
				packet.AddProperties(properties);

				party.Broadcast(packet);
			}

			/// <summary>
			/// Send list of items that are retrievable from the Market
			/// </summary>
			/// <param name="character"></param>
			public static void MarketRetrievalItems(Character character, List<ItemList> items)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.MarketRetrievalItems);
				packet.Zlib(true, zpacket =>
				{
					// TODO: Market Items
					zpacket.PutInt(items.Count);
					foreach (var item in items)
					{
						var itemId = item.GetItemId(character.ObjectId);
						var itemCount = itemId == ItemId.Silver ? item.SellPrice : item.Count;
						zpacket.PutLong(item.ItemGuid);
						zpacket.PutInt(itemId);
						zpacket.PutInt(0);
						zpacket.PutInt(itemCount);
						zpacket.PutEmptyBin(33);
						zpacket.PutLong(item.RegTime.ToUnixTimeSeconds() * 1000);

						zpacket.PutLpString(item.GetMarketStatus(character.ObjectId));
						zpacket.PutShort(0); // item properties size
											 // Add properties here
						zpacket.PutInt(0);
					}
				});

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Register an item on the market
			/// </summary>
			/// <param name="character"></param>
			/// <param name="itemWorldId"></param>
			public static void MarketRetrieveItem(Character character, long itemWorldId)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.MarketRegisterItem);
				packet.PutLong(itemWorldId);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Register an item on the market
			/// </summary>
			/// <param name="character"></param>
			/// <param name="marketWorldId"></param>
			public static void MarketBuyItem(Character character, long marketWorldId, int itemRemainingAmount, short s1 = 1)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.MarketBuyItem);
				packet.PutLong(marketWorldId);
				packet.PutInt(itemRemainingAmount);
				packet.PutShort(s1);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Cancel an item market registration
			/// </summary>
			/// <param name="character"></param>
			/// <param name="marketWorldId"></param>
			public static void MarketCancelItem(Character character, long marketWorldId)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.MarketCancelItem);
				packet.PutLpString(marketWorldId.ToString());
				packet.PutInt(0);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Summon (Monster) plays an animation
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="packetString"></param>
			/// <param name="f1"></param>
			public static void SummonPlayAnimation(IActor actor, string packetString, float f1)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString, out var packetStr1))
					Log.Warning("SummonPlayAnimation: Unknown packet string {0}", packetString);
				SummonPlayAnimation(actor, packetStr1.Id, f1);
			}

			/// <summary>
			/// Summon (Monster) plays an animation
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="playAnimation"></param>
			/// <param name="f1"></param>
			public static void SummonPlayAnimation(IActor actor, int playAnimation, float f1)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.SummonPlayAnimation);
				packet.PutInt(actor.Handle);
				packet.PutInt(playAnimation);
				packet.PutFloat(f1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Disables Hotkeys.
			/// </summary>
			/// <remarks>
			/// Only used for specific buffs?
			/// </remarks>
			/// <param name="actor"></param>
			/// <param name="buffName"></param>
			/// <param name="skillId"></param>
			/// <param name="b1"></param>
			public static void ApplyBuff(IActor actor, string buffName, SkillId skillId, byte b1)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.ApplyBuff);
				packet.PutInt(actor.Handle);
				packet.PutLpString(buffName);
				packet.PutInt((int)skillId);
				packet.PutByte(b1);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Enables Hotkeys.
			/// </summary>
			/// <remarks>
			/// Only used for specific buffs?
			/// </remarks>
			/// <param name="entity"></param>
			/// <param name="buffName"></param>
			public static void RemoveBuff(Character entity, string buffName)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.RemoveBuff);
				packet.PutInt(entity.Handle);
				packet.PutLpString(buffName);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Unknown use but related to Hoplite Stabbing Skill
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="skillId"></param>
			public static void Skill_10B(Character entity, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Skill_10B);
				packet.PutInt(entity.Handle);
				packet.PutInt((int)skillId);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Unknown purpose yet.
			/// </summary>
			/// <remarks>Sent when using barbarian stomping kick skill</remarks>
			/// <param name="caster"></param>
			public static void Unknown_10F(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Unknown_10F);
				packet.PutInt(character.Handle);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Sent for unknown purpose related to skill (Hwarang PyeonJeon)
			/// Might be related to canceling dynamic cast.
			/// </summary>
			/// <param name="actor"></param>
			public static void CancelDynamicCast(IActor actor)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.CancelDynamicCast);
				packet.PutInt(actor.Handle);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Dummy (Unknown Purpose)
			/// </summary>
			/// <param name="character"></param>
			public static void Unknown_11A(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Unknown_11A);
				packet.PutInt(0); // ?

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Unknown Purpose
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="packetString"></param>
			/// <param name="shopType"></param>
			/// <param name="i1"></param>
			public static void Shop_Unknown11C(IZoneConnection conn, int packetString, int shopType, int i1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Shop_Unknown11C);

				packet.PutInt(packetString);
				packet.PutInt(shopType);
				packet.PutInt(i1);

				conn.Send(packet);
			}

			/// <summary>
			/// Seen with Lightning Tower Skill
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="packetString"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			/// <param name="tuple"></param>
			public static void Skill_125(IActor actor, string packetString, float f1, float f2, params (int, int)[] tuple)
			{
				if (!ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString, out var packetStr))
					throw new ArgumentException($"Packet string '{packetString}' not found.");
				Skill_125(actor, packetStr.Id, f1, f2, tuple);
			}

			/// <summary>
			/// Seen with Lightning Tower Skill
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="packetString"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			/// <param name="tuple"></param>
			public static void Skill_125(IActor actor, int packetString, float f1, float f2, params (int, int)[] tuple)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_125);

				packet.PutInt(actor.Handle);
				packet.PutInt(packetString);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutInt(tuple?.Length ?? 0);

				if (tuple?.Length > 0)
				{
					foreach (var (handle, syncKey) in tuple)
					{
						packet.PutInt(handle);
						packet.PutInt(syncKey);
					}
				}

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// Used with Pyromancer's Prominence Skill
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="effectHandle"></param>
			/// <param name="packetString1"></param>
			/// <param name="f1"></param>
			/// <param name="packetString2"></param>
			/// <param name="f2"></param>
			/// <param name="f3"></param>
			/// <param name="i2"></param>
			/// <param name="f4"></param>
			/// <param name="f5"></param>
			/// <param name="i3"></param>
			/// <param name="f6"></param>
			/// <param name="position"></param>
			/// <param name="i4"></param>
			/// <remarks>
			/// PAD_SET_PROMINENCE(self, skl, pad, eft, eftScale, maxHeight, coreCount, hitRange, onGroundTime, prominenceCount, moveCount, attackTime, jumpMin, jumpMax, maxMoveRange, preEft, preEftScale, preEftSecond)
			/// </remarks>
			public static void Skill_124(IActor entity, int effectHandle, string packetString1, float f1, string packetString2,
				float f2, float f3, int i2, float f4, float f5, int i3, float f6, Position position, int i4)
			{
				if (ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString1, out var packetStr1) &&
					ZoneServer.Instance.Data.PacketStringDb.TryFind(packetString2, out var packetStr2))
					Skill_124(entity, effectHandle, packetStr1.Id, f1, packetStr2.Id, f2, f3, i2, f4, f5, i3, f6, position, i4);
			}

			/// <summary>
			/// Used with Pyromancer's Prominence Skill
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="effectHandle"></param>
			/// <param name="packetString1"></param>
			/// <param name="f1"></param>
			/// <param name="packetString2"></param>
			/// <param name="f2"></param>
			/// <param name="f3"></param>
			/// <param name="i2"></param>
			/// <param name="f4"></param>
			/// <param name="f5"></param>
			/// <param name="i3"></param>
			/// <param name="f6"></param>
			/// <param name="position"></param>
			/// <param name="i4"></param>
			/// <remarks>
			/// PAD_SET_PROMINENCE(self, skl, pad, eft, eftScale, maxHeight, coreCount, hitRange, onGroundTime, 
			/// prominenceCount, moveCount, attackTime, jumpMin, jumpMax, maxMoveRange, preEft, preEftScale, preEftSecond)
			/// </remarks>
			public static void Skill_124(IActor entity, int effectHandle, int packetString1, float f1, int packetString2,
				float f2, float f3, int i2, float f4, float f5, int i3, float f6, Position position, int i4)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_124);

				packet.PutInt(effectHandle);
				packet.PutByte(0);
				packet.PutInt(entity.Handle);
				packet.PutInt(packetString1);
				packet.PutFloat(f1);
				packet.PutInt(packetString2);
				packet.PutFloat(f2);
				packet.PutFloat(f3);
				packet.PutInt(i2);
				packet.PutFloat(f4);
				packet.PutFloat(f5);
				packet.PutInt(i3);
				packet.PutFloat(f6);
				packet.PutFloat(position.X);
				packet.PutFloat(0);
				packet.PutFloat(position.Z);
				packet.PutInt(i4);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Used with Pyromancer's Prominence Skill
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="effectHandle"></param>
			public static void Skill_124(IActor actor, int effectHandle)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_124);

				packet.PutInt(effectHandle);
				packet.PutByte(1);

				actor.Map.Broadcast(packet);
			}


			/// <summary>
			/// Used with Pyromancer's Prominence Skill
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="effectHandle"></param>
			/// <param name="position1"></param>
			/// <param name="position2"></param>
			public static void Skill_124(IActor entity, int effectHandle, Position position1, Position position2)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_124);

				packet.PutInt(effectHandle);
				packet.PutByte(2);
				packet.PutFloat(position1.X);
				packet.PutFloat(0);
				packet.PutFloat(position1.Z);
				packet.PutFloat(position2.X);
				packet.PutFloat(0);
				packet.PutFloat(position2.Z);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Used with Hunter's Coursing Skill
			/// </summary>
			/// <param name="actor"></param>
			/// <param name=""></param>
			public static void Skill_127(IActor actor, int targetHandle, int effectHandle, Position position)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_127);

				packet.PutInt(actor.Handle);
				packet.PutInt(targetHandle);
				if (targetHandle != 0)
				{
					packet.PutInt(effectHandle);
					packet.PutFloat(position.X);
					packet.PutFloat(0);
					packet.PutFloat(position.Z);
				}

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Unknown purpose yet.
			/// </summary>
			/// <param name="character"></param>
			public static void ChannelTraffic(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ChannelTraffic);

				packet.Zlib(true, zpacket =>
				{
					var availableZoneServers = ZoneServer.Instance.ServerList.GetZoneServers(character.MapId);

					zpacket.PutShort(character.MapId);
					zpacket.PutShort(availableZoneServers.Length);

					for (var channelId = 0; channelId < availableZoneServers.Length; ++channelId)
					{
						var zoneServerInfo = availableZoneServers[channelId];

						// The client uses the "channelId" as part of the
						// channel name. For example, id 0 becomes "Ch 1",
						// id 1 becomes "Ch 2", etc. Because of this we
						// can't just send anything here, it needs to be
						// a sequential number starting from 0 to match
						// official behavior.

						zpacket.PutShort(channelId);
						zpacket.PutShort(zoneServerInfo.CurrentPlayers);
						zpacket.PutShort(zoneServerInfo.MaxPlayers);
					}
				});
			}

			/// <summary>
			/// Set's a label on an Actor.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="label"></param>
			public static void ActorLabel(Character entity, string label)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetActorLabel);

				packet.PutInt(entity.Handle);
				packet.PutLpString(label);

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Sent on login.
			/// Unknown purpose, could be old Greeting Message Packet?
			/// </summary>
			/// <param name="character"></param>
			public static void Unknown_134(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_134);

				packet.Zlib(true, zpacket =>
				{
					zpacket.PutLong(character.ObjectId);
					zpacket.PutByte(1);
					zpacket.PutEmptyBin(6);
				});

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Displays guild name under player and party name?
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="character"></param>
			public static void ShowParty(IZoneConnection conn, Character character)
			{
				var party = character.Connection.Party;
				var guild = character.Connection.Guild;
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ShowParty);

				packet.PutInt(character.Handle);
				if (party != null && guild != null)
				{
					packet.PutByte(1);
					packet.PutLpString(party.Name);
					packet.PutByte(0);
					packet.PutLpString(guild.Name);
				}
				else if (party != null)
				{
					packet.PutByte(1);
					packet.PutLpString(party.Name);
					packet.PutByte(3);
				}
				else if (guild != null)
				{
					packet.PutByte(3);
					packet.PutLpString(guild.Name);
				}

				conn.Send(packet);
			}

			/// <summary>
			/// Displays guild name under player and party name?
			/// </summary>
			/// <param name="character"></param>
			public static void ShowParty(Character character)
			{
				var party = character.Connection.Party;
				var guild = character.Connection.Guild;

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ShowParty);

				packet.PutInt(character.Handle);
				if (party != null && guild != null)
				{
					packet.PutByte(1);
					packet.PutLpString(party.Name);
					packet.PutByte(0);
					packet.PutLpString(guild.Name);
				}
				else if (party != null)
				{
					packet.PutByte(1);
					packet.PutLpString(party.Name);
					packet.PutByte(3);
				}
				else if (guild != null)
				{
					packet.PutByte(3);
					packet.PutLpString(guild.Name);
				}

				character.Map.Broadcast(packet);
			}

			/// <summary>
			/// Sent with Resurrect Packets?
			/// </summary>
			/// <param name="character"></param>
			public static void Revive(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Revive);

				packet.PutInt(character.Handle);
				packet.PutByte(0);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Shows shop setup/closing animation 
			/// eg: Blacksmith Iron appears/disappears in client
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="entity"></param>
			/// <param name="scriptFunc"></param>
			/// <param name="b1"></param>
			/// <param name="b2">If set to 0, animation plays in reverse? Used to close shop.</param>
			public static void ShopAnimation(IZoneConnection conn, Character entity, string scriptFunc, byte b1 = 1, byte b2 = 2)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ShopAnimation);

				packet.PutInt(entity.Handle);
				packet.PutLpString(scriptFunc);
				packet.PutByte(b1);
				packet.PutByte(b2);

				conn.Send(packet);
			}

			/// <summary>
			/// Sends the session key to the client.
			/// </summary>
			/// <param name="conn"></param>
			public static void SetSessionKey(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSessionKey);

				packet.PutLpString(conn.SessionKey);
				packet.PutByte(1);

				conn.Send(packet);
			}

			/// <summary>
			/// Status Effect
			/// </summary>
			/// <param name="actor"></param>
			/// <param name="duration"></param>
			/// <param name="effectName"></param>
			/// <param name="effectType"></param>
			public static void StatusEffect(IActor actor, float duration, string effectName, string effectType)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.StatusEffect);

				packet.PutInt(actor.Handle);
				packet.PutFloat(duration);
				packet.PutLpString(effectName);
				packet.PutLpString(effectType);

				actor.Map.Broadcast(packet);
			}

			/// <summary>
			/// Sent when there is a double log-in.
			/// </summary>
			/// <param name="character"></param>
			public static void DisconnectError(IZoneConnection conn, string msg)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.DisconnectError);
				packet.PutLpString(msg);
				packet.PutInt(0);
				packet.PutByte(0);

				conn.Send(packet);
			}

			/// <summary>
			/// Makes item monster appear to drop, by "throwing" it a certain
			/// distance from its current position.
			/// </summary>
			/// <param name="monster"></param>
			/// <param name="direction"></param>
			/// <param name="distance"></param>
			public static void ItemDrop(IMonster monster, Direction direction, float distance)
			{
				// The distance might be more like a force, since items fly
				// farther than they should with high distances. Whether this
				// is a problem, depends on the used distance and the pick up
				// range. With a very small pick up range, like 10, and a high
				// distance, like 110, there will be a slight desync, and you
				// might not get the item, even if you're right on top of it.
				// But since we won't usually use such small and high values,
				// it will probably be fine.

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.ItemDrop);

				packet.PutInt(monster.Handle);
				packet.PutInt((int)direction.NormalDegreeAngle);
				packet.PutFloat(distance);

				monster.Map.Broadcast(packet, monster, false);
			}

			/// <summary>
			/// Set a character's state.
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="character"></param>
			/// <param name="isHostile"></param>
			public static void FightState(IZoneConnection conn, Character character, bool isHostile)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.FightState);
				packet.PutInt(character.Handle);
				packet.PutPosition(character.Position);
				packet.PutByte(isHostile);

				conn.Send(packet);
			}

			public static void StorageSilverTransactions(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.StorageSilverTransaction);

				packet.Zlib(true, zpacket =>
				{
					var transactions = 1;
					zpacket.PutByte(0);
					zpacket.PutInt(transactions);
					for (var i = 0; i < transactions; i++)
					{
						zpacket.PutByte(0); // Deposit
						zpacket.PutLong(100); // Silver Transaction
						zpacket.PutLong(1000); // Silver Total
						zpacket.PutDate(DateTime.Now.AddDays(-1));
					}
				});

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Market Item Minimum/Maximum Prices
			/// </summary>
			/// <param name="character"></param>
			/// <param name="b1"></param>
			/// <param name="l1"></param>
			/// <param name="minPrice"></param>
			/// <param name="l2"></param>
			/// <param name="maxPrice"></param>
			/// <param name="unitPrice"></param>
			public static void MarketMinMaxInfo(Character character, bool b1, long l1, long minPrice, long l2, long maxPrice, long unitPrice)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.MarketMinMaxInfo);

				packet.PutByte(b1);
				packet.PutLong(l1);
				packet.PutLong(minPrice);
				packet.PutLong(l2);
				packet.PutLong(maxPrice);
				packet.PutLong(unitPrice);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Updates which headgears are visible for the character on
			/// clients in range.
			/// </summary>
			/// <param name="character"></param>
			public static void HeadgearVisibilityUpdate(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.HeadgearVisibilityUpdate);

				packet.PutInt(character.Handle);
				packet.PutByte((character.VisibleEquip & VisibleEquip.Headgear1) != 0);
				packet.PutByte((character.VisibleEquip & VisibleEquip.Headgear2) != 0);
				packet.PutByte((character.VisibleEquip & VisibleEquip.Headgear3) != 0);
				packet.PutByte((character.VisibleEquip & VisibleEquip.Wig) != 0);

				character.Map.Broadcast(packet, character);
			}

			/// <summary>
			/// Send all skills and their properties a character has.
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="propertyIds"></param>
			public static void SetSkillsProperties(IZoneConnection conn, params string[] propertyIds)
			{
				var skills = conn.SelectedCharacter.Skills.GetList();
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SetSkillsProperties);

				packet.PutInt(skills.Length);
				foreach (var skill in skills)
				{
					var properties = skill.Properties.GetSelect(propertyIds);

					packet.PutInt((int)skill.Id);
					packet.PutShort(properties.GetByteCount());
					packet.AddProperties(properties);
				}

				conn.Send(packet);
			}

			/// <summary>
			/// Updates the skill UI with character job data.
			/// </summary>
			/// <param name="character"></param>
			public static void UpdateSkillUI(Character character)
			{
				// While the client will apparently gladly accept any combination
				// of jobs, the skill UI will only appear correctly if job
				// data for the character's current "display job" is sent.
				// For example, if the display job is Archer, data for *that*
				// job must be sent. Other base classes or higher jobs in the
				// same class do not work. Same thing for when the display
				// job is a higher job.
				// If data for the base job is sent though, other jobs will
				// appears as well. So it seems like you can create a Wizard/
				// Archer hybrid for example.

				var jobs = character.Jobs.GetList();

				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.UpdateSkillUI);

				packet.PutLong(character.ObjectId);
				packet.PutInt(jobs.Length);
				foreach (var job in jobs)
				{
					packet.PutShort((short)job.Id);
					packet.PutShort((short)job.Level);
					packet.PutInt(0);
					packet.PutLong(job.TotalExp);
					packet.PutByte((byte)job.SkillPoints);
					packet.PutShort(41857);
					packet.PutEmptyBin(5);
					// Job Advancement Date
					//packet.PutLong(job.AdvancementDate.ToUnixTimeSeconds() * 1000);
					packet.PutLong(132735996030000000);
					packet.PutLong(0);
				}

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Show Instance Dungeon Match Making UI
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="instanceDungeonId"></param>
			/// <param name="allowAutoMatchReenter"></param>
			/// <param name="allowAutoMatch"></param>
			/// <param name="allowEnterNow"></param>
			/// <param name="allowAutoMatchParty"></param>
			/// <param name="b1"></param>
			public static void InstanceDungeonMatchMaking(Character entity, int instanceDungeonId, int allowAutoMatchReenter, int allowAutoMatch, int allowEnterNow, int allowAutoMatchParty, byte b1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.InstanceDungeonMatchMaking);

				packet.PutInt(instanceDungeonId);
				packet.PutInt(allowAutoMatchReenter);
				packet.PutInt(allowAutoMatch);
				packet.PutInt(allowEnterNow);
				packet.PutInt(allowAutoMatchParty);
				packet.PutByte(b1);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Send fishing rank data
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="type"></param>
			public static void FishingRankData(IZoneConnection conn, string type)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				var rankingCount = 1;

				packet.PutInt(NormalOp.Zone.FishingRankData);
				packet.PutLpString("Fishing");
				packet.PutLpString(type);
				packet.PutInt(0);
				packet.PutInt(0);
				packet.PutInt(0);
				if (rankingCount > 0)
				{
					packet.PutLong(conn.Account.ObjectId);
					packet.PutInt(100);
					packet.PutLpString(conn.SelectedCharacter.Name);
				}

				conn.Send(packet);
			}

			/// <summary>
			/// Initializing the adventure book
			/// </summary>
			/// <param name="conn"></param>
			public static void AdventureBook(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.AdventureBook);

				packet.PutLpString("AdventureBook");
				packet.PutLpString("Initialization_point");
				packet.PutInt(-1);
				packet.PutInt(0);
				packet.PutInt(0);
				packet.PutByte(1);

				conn.Send(packet);
			}

			/// <summary>
			/// Unknown purpose, sent on login
			/// </summary>
			/// <param name="conn"></param>
			public static void Unknown198(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_198);

				packet.PutInt(0);
				packet.PutInt(0);

				conn.Send(packet);
			}

			/// <summary>
			/// Unknown purpose yet. (Dummy)
			/// </summary>
			/// <param name="character"></param>
			public static void Unknown_19B(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_19B);
				packet.PutLong(1);
				packet.PutByte(0);

				conn.Send(packet);
			}

			/// <summary>
			/// Unknown purpose yet. (Dummy)
			/// Set's the time for something.
			/// </summary>
			/// <remarks>
			/// 05/31/23 (Showed DateTime for 06/04/23 21:00)
			/// </remarks>
			/// <param name="conn"></param>
			public static void Unknown_19D_SetTime(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_19D_SetTime);

				packet.PutByte(0);
				packet.PutDate(DateTime.Now.AddHours(2));

				conn.Send(packet);
			}

			/// <summary>
			/// Sent when Pet is activated or disabled
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="companion"></param>
			/// <param name="isInActive"></param>
			public static void PetIsInactive(IZoneConnection conn, Companion companion)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PetIsInactive);

				packet.PutInt(companion.Handle);
				packet.PutInt(companion.IsActivated ? 0 : 1); // Inverse of active

				conn.Send(packet);
			}

			/// <summary>
			/// Set the sub attack skill (access by C key).
			/// </summary>
			/// <param name="character"></param>
			public static void SetSubAttackSkill(Character character, SkillId skillId)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.SetSubAttackSkill);
				packet.PutInt(character.Handle);
				packet.PutInt((int)skillId);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Unknown purpose yet.
			/// </summary>
			/// <param name="character"></param>
			public static void Unknown_1A6(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_1A6);

				packet.PutShort(1);
				packet.PutInt(50);
				packet.PutInt(50);
				packet.PutInt(100);
				packet.PutInt(100);
				packet.PutFloat(0.3f);
				packet.PutFloat(3f);
				packet.PutInt(5000);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Seen during Spear Throw (Hoplite) skill.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="str"></param>
			/// <param name="itemId"></param>
			public static void Skill_1A9(IActor entity, string str, int itemId = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Skill_1A9);
				packet.PutInt(entity.Handle);
				packet.PutLpString(str);
				packet.PutInt(itemId);

				if (entity is Character character)
					character.Connection.Send(packet);
			}

			/// <summary>
			/// Updates weather wig eequipment is visible for the character
			/// on clients in range.
			/// </summary>
			/// <param name="character"></param>
			public static void WigVisibilityUpdate(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.WigVisibilityUpdate);

				packet.PutInt(character.Handle);
				packet.PutByte((character.VisibleEquip & VisibleEquip.Wig) != 0);

				character.Map.Broadcast(packet, character);
			}

			/// <summary>
			/// Used Medal Total
			/// </summary>
			/// <param name="conn"></param>
			/// <param name="medals"></param>
			public static void UsedMedalTotal(IZoneConnection conn, int medals)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.UsedMedalTotal);

				packet.PutInt(medals);

				conn.Send(packet);
			}

			/// <summary>
			/// Unknown purpose yet.
			/// Sent on logging in
			/// </summary>
			/// <param name="conn"></param>
			public static void Unknown_1B6(IZoneConnection conn)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Unknown_1B6);

				packet.PutInt(0);
				packet.PutInt(0);
				packet.PutInt(0);

				conn.Send(packet);
			}

			/// <summary>
			/// Send client ToS Steam Achievement
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="achievement"></param>
			public static void SteamAchievement(Character entity, string achievement)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SteamAchievement);
				packet.PutLpString(achievement);

				entity.Connection.Send(packet);
			}

			/// <summary>
			/// Rotate an Item (Monster)
			/// Used in Shield Lob Skill
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="direction"></param>
			/// <param name="f1"></param>
			/// <param name="f2"></param>
			public static void Skill_ItemRotate(Character entity, float direction, float f1 = 0, float f2 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);

				packet.PutInt(NormalOp.Zone.Skill_ItemRotate);
				packet.PutInt(entity.Handle);
				packet.PutFloat(direction);
				packet.PutFloat(f1); // Haven't seen other values yet other than 0
				packet.PutFloat(f2); // Haven't seen other values yet other than 0

				entity.Map.Broadcast(packet);
			}

			/// <summary>
			/// Updates weather wig eequipment is visible for the character
			/// on clients in range.
			/// </summary>
			/// <param name="character"></param>
			public static void SubWeaponVisibilityUpdate(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.SubWeaponVisibilityUpdate);

				packet.PutInt(character.Handle);
				packet.PutByte((character.VisibleEquip & VisibleEquip.SubWeapon) != 0);

				character.Map.Broadcast(packet, character);
			}

			public static void Skill_5F(Character character, int i1, float f1, float f2 = 0, byte b1 = 0)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.Skill_5F);

				packet.PutInt(i1);
				packet.PutFloat(f1);
				packet.PutFloat(f2);
				packet.PutByte(b1);

				character.Map.Broadcast(packet);
			}

			//
			public static void PlayGatherCorpseParts(IActor caster, IActor corpse)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayGatherCorpseParts);

				packet.PutInt(caster.Handle);
				packet.PutInt(corpse.Handle);

				caster.Map.Broadcast(packet, caster);
			}

			/// <summary>
			/// Create a ring of corpse parts
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="effectHandle"></param>
			/// <param name="ringExpansionDuration"></param>
			/// <param name="ringRadius"></param>
			/// <param name="ringPartsRotationSpeed"></param>
			/// <param name="corpsePartCount"></param>
			/// <param name="monsterIds"></param>
			public static void PlayCorpsePartsRing(IActor caster, int effectHandle, float ringExpansionDuration, float ringRadius, float ringPartsRotationSpeed, int corpsePartCount, params int[] monsterIds)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayCorpsePartsRing);

				packet.PutInt(caster.Handle);
				packet.PutInt(effectHandle);
				packet.PutFloat(ringExpansionDuration);
				packet.PutFloat(ringRadius);
				packet.PutFloat(ringPartsRotationSpeed);
				packet.PutInt(monsterIds.Length);
				for (var i = 0; i < monsterIds.Length; i++)
				{
					packet.PutInt(monsterIds[i]);
					packet.PutByte((byte)i);
					packet.PutInt(corpsePartCount);
					packet.PutInt(corpsePartCount);
				}

				caster.Map.Broadcast(packet, caster);
			}

			/// <summary>
			/// Remove effect
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="effectHandle"></param>
			public static void RemoveEffect(IActor caster, int effectHandle)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.RemoveEffect);

				packet.PutInt(caster.Handle);
				packet.PutInt(effectHandle);

				caster.Map.Broadcast(packet, caster);
			}

			public static void Skill_DB(IActor actor, int effectHandle, byte b1, int monsterId, byte b2, int i3, int i4)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.DropCorpseParts);

				packet.PutInt(actor.Handle);
				packet.PutInt(effectHandle);
				packet.PutByte(b1);
				packet.PutInt(monsterId);
				packet.PutByte(b2);
				packet.PutInt(i3);
				packet.PutInt(i4);

				actor.Map.Broadcast(packet, actor);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="caster"></param>
			/// <param name="effectHandle"></param>
			/// <param name="position"></param>
			/// <param name="particleSpread"></param>
			/// <param name="startDelay"></param>
			/// <param name="particleSpeed"></param>
			/// <param name="f4"></param>
			/// <param name="animationDuration"></param>
			/// <param name="i2"></param>
			public static void PlayThrowCorpseParts(IActor caster, int effectHandle, Position position, float particleSpread, float startDelay, float particleSpeed, float f4, float animationDuration, int i2)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.PlayThrowCorpseParts);

				packet.PutInt(effectHandle);
				packet.PutPosition(position);
				packet.PutFloat(particleSpread);
				packet.PutFloat(startDelay);
				packet.PutFloat(particleSpeed);
				packet.PutFloat(f4);
				packet.PutFloat(animationDuration);
				packet.PutInt(i2);

				caster.Map.Broadcast(packet, caster);
			}
		}

		public static class ZC_TO_CLIENT
		{
			/// <summary>
			/// Guild/Party Event Related?
			/// </summary>
			/// <remarks>Maybe like a trick packet or ZC_NORMAL </remarks>
			/// <param name="character"></param>
			public static void MessageParameter(Character character, string message, string parameter = "", int duration = 0)
			{
				var packet = new Packet(Op.ZC_TO_CLIENT);
				packet.PutInt(NormalOp.GuildOp.MessageParameter);

				packet.PutLong(character.Connection.Account.ObjectId);
				packet.PutLpString(message);
				packet.PutLpString(parameter);
				packet.PutInt(duration);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Guild/Party Event Related?
			/// </summary>
			/// <remarks>Maybe like a trick packet or ZC_NORMAL </remarks>
			/// <param name="character"></param>
			public static void PartyMessage(Party party, Character character, string message, string parameter = "")
			{
				var packet = new Packet(Op.ZC_TO_CLIENT);
				packet.PutInt(NormalOp.GuildOp.GuildMessage);

				packet.PutLong(character.AccountDbId);
				packet.PutByte((byte)party.Type);
				packet.PutLong(party.ObjectId);
				packet.PutLpString(message);

				party.Broadcast(packet);
				packet.PutLong(character.ObjectId);
			}

			/// <summary>
			/// Starts a time action, displaying a progress bar and
			/// potentially putting the character in an animation.
			/// </summary>
			/// <param name="entity"></param>
			/// <param name="timeAction"></param>
			public static void TimeActionStart(Character character, TimeAction timeAction)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionStart);

				packet.PutInt(character.Handle);
				packet.PutLpString(timeAction.DisplayText);
				packet.PutLpString(timeAction.AnimationName);
				packet.PutFloat((float)timeAction.Duration.TotalSeconds);
				packet.PutByte(1);
				packet.PutLpString(timeAction.ButtonText);

				character.Connection.Send(packet);
			}

			/// <summary>
			/// Stops a time action, hiding the progress bar and reverting
			/// to the default animation.
			/// </summary>
			/// <param name="character"></param>
			public static void TimeActionEnd(Character character)
			{
				var packet = new Packet(Op.ZC_NORMAL);
				packet.PutInt(NormalOp.Zone.TimeActionEnd);

				packet.PutInt(character.Handle);
				packet.PutByte(0);

				character.Connection.Send(packet);
			}
		}
	}
}
