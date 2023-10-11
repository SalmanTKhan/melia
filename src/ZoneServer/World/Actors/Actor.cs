using System.Collections.Concurrent;
using System.Collections.Generic;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Components;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Actors.Prerequisites;
using Melia.Zone.World.Maps;
using Yggdrasil.Composition;

namespace Melia.Zone.World.Actors
{
	/// <summary>
	/// An object that can be placed on a map.
	/// </summary>
	public interface IActor
	{
		/// <summary>
		/// Returns the actor's unique handle.
		/// </summary>
		int Handle { get; }

		/// <summary>
		/// Returns the actor's display name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Returns the map the actor is currently on.
		/// </summary>
		Map Map { get; set; }

		/// <summary>
		/// Returns the actor's position on its current map.
		/// </summary>
		Position Position { get; set; }

		/// <summary>
		/// Returns the direction the actor is facing.
		/// </summary>
		Direction Direction { get; set; }

		/// <summary>
		/// Returns the actor's track layer.
		/// </summary>
		public int Layer { get; set; }

		/// <summary>
		/// Returns the actor's visibility.
		/// </summary>
		public ActorVisibility Visibility { get; set; }

		/// <summary>
		/// Returns a list of effects that are attached to the actor.
		/// </summary>
		ConcurrentBag<AttachableEffect> AttachableEffects { get; }

		/// <summary>
		/// Returns the components the actor has.
		/// </summary>
		ComponentCollection Components { get; }

		/// <summary>
		/// Returns if an actor is visible.
		/// </summary>
		/// <param name="actor"></param>
		/// <returns></returns>
		bool IsVisible(IActor actor);
	}

	/// <summary>
	/// An actor that can be owned or associated with.
	/// </summary>
	public interface ISubActor : IActor
	{
		int OwnerHandle { get; }
		int AssociatedHandle { get; }
	}

	/// <summary>
	/// An actor that has a guild.
	/// </summary>
	public interface IGuildMember : IActor
	{
		Guild Guild { get; }
	}

	/// <summary>
	/// Represents a spawnable
	/// </summary>
	public interface ISpawn
	{
		/// <summary>
		/// Spawn location
		/// </summary>
		Location SpawnLocation { get; set; }
	}

	/// <summary>
	/// An object that can be placed on a map.
	/// </summary>
	public abstract class Actor : IActor
	{
		/// <summary>
		/// Returns a list of effects that are attached to the actor.
		/// </summary>
		public ConcurrentBag<AttachableEffect> AttachableEffects { get; } = new ConcurrentBag<AttachableEffect>();

		/// <summary>
		/// Returns the actor's unique handle.
		/// </summary>
		public int Handle { get; } = ZoneServer.Instance.World.CreateHandle();

		/// <summary>
		/// Returns the actor's display name.
		/// </summary>
		public abstract string Name { get; set; }

		/// <summary>
		/// Returns the map the actor is currently on.
		/// </summary>
		public Map Map
		{
			get => _map;
			set => _map = value ?? Map.Limbo;
		}
		private Map _map = Map.Limbo;

		/// <summary>
		/// Returns the actor's position on its current map.
		/// </summary>
		public Position Position { get; set; }

		/// <summary>
		/// Returns the direction the actor is facing.
		/// </summary>
		public Direction Direction { get; set; }

		/// <summary>
		/// Returns the components the actor has.
		/// </summary>
		public ComponentCollection Components { get; set; } = new ComponentCollection();

		/// <summary>
		/// Returns the actor's visibility.
		/// </summary>
		public ActorVisibility Visibility { get; set; } = ActorVisibility.Everyone;

		/// <summary>
		/// Returns a specific visibility id (Character, Party)
		/// </summary>
		public long VisibilityId { get; set; }

		/// <summary>
		/// Returns a list of the visibility prerequisites, that need to be
		/// met to for the entity to be visible.
		/// </summary>
		public List<Prerequisite> VisibilityPrerequisites { get; } = new List<Prerequisite>();

		/// <summary>
		/// Returns the layer on which this actor exists.
		/// </summary>
		public int Layer { get; set; } = 0;

		/// <summary>
		/// Set a specific visibilty limiter.
		/// </summary>
		/// <param name="visibility"></param>
		/// <param name="id"></param>
		public void SetVisibilty(ActorVisibility visibility, long id)
		{
			this.Visibility = visibility;
			this.VisibilityId = id;
		}

		/// <summary>
		/// Attaches an effect to the actor that is displayed alongside it.
		/// </summary>
		/// <param name="packetString"></param>
		/// <param name="scale"></param>
		public void AttachEffect(string packetString, float scale = 1)
		{
			var effect = new AttachableEffect(packetString, scale);
			this.AttachableEffects.Add(effect);

			if (this.Map != Map.Limbo)
				Send.ZC_NORMAL.AttachEffect(this, effect.PacketString, effect.Scale);
		}

		/// <summary>
		/// Add an effect to an actor.
		/// </summary>
		/// <param name="effect"></param>
		public void AddEffect(Effect effect)
		{
			this.Components ??= new ComponentCollection();
			if (!this.Components.Has<EffectsComponent>())
				this.Components.Add(new EffectsComponent(this));
			this.Components.Get<EffectsComponent>()?.AddEffect(effect);
		}

		public bool CanSee(IActor actor)
		{
			if (actor == null)
				return false;
			if (!this.Position.InRange2D(actor.Position, Map.VisibleRange))
				return false;
			if (!actor.IsVisible(this))
				return false;
			return true;
		}

		/// <summary>
		/// Adds prerequisite to the entity.
		/// </summary>
		/// <param name="prerequisites"></param>
		public void AddVisibilityPrerequisite(params Prerequisite[] prerequisites)
		{
			foreach (var prerequisite in prerequisites)
				this.VisibilityPrerequisites.Add(prerequisite);
		}

		/// <summary>
		/// Plays effect for the character.
		/// </summary>
		/// <param name="packetString"></param>
		public void PlayEffect(string packetString, float scale = 1, byte b1 = 1, string heightOffset = "BOT", byte b2 = 0)
		{
			Send.ZC_NORMAL.PlayEffect(this, b1, heightOffset, b2, scale, packetString, 0, 0);
		}

		/// <summary>
		/// Plays effect for the character.
		/// </summary>
		/// <param name="packetString"></param>
		public void PlayEffectLocal(IZoneConnection conn, string packetString, float scale = 1, string heightOffset = "BOT", byte b1 = 0)
		{
			Send.ZC_NORMAL.PlayEffect(conn, this, b1, heightOffset, 1, scale, packetString, 0, 0);
		}

		public bool IsVisible(IActor actor)
		{
			for (var i = 0; i < this.VisibilityPrerequisites.Count; ++i)
			{
				var prerequisite = this.VisibilityPrerequisites[i];
				if (!prerequisite.Met(actor))
					return false;
			}

			if (this.Layer != actor.Layer)
				return false;

			if (actor is Character character)
			{
				switch (actor.Visibility)
				{
					case ActorVisibility.Individual:
						if (this.VisibilityId == character.ObjectId)
							return true;
						break;
					case ActorVisibility.Party:
						if (character.Connection.Party != null)
							return this.VisibilityId == character.Connection.Party.ObjectId;
						break;
					case ActorVisibility.Track:
						if (character.Tracks != null && character.Tracks.ActiveTrack != null)
							return this.VisibilityId == character.ObjectId;
						break;
					case ActorVisibility.Everyone:
						return true;
					default:
						return false;
				}
			}
			return true;
		}
	}

	/// <summary>
	/// Defines an actor's visibility.
	/// </summary>
	public enum ActorVisibility
	{
		NoOne,
		Individual,
		Party,
		Track,
		Everyone,
	}

	/// <summary>
	/// An effect that can be attached to an actor.
	/// </summary>
	public class AttachableEffect
	{
		/// <summary>
		/// Returns the name of the effect in form of a packet string.
		/// </summary>
		public string PacketString { get; }

		/// <summary>
		/// Returns the effect's size multiplier.
		/// </summary>
		public float Scale { get; }

		/// <summary>
		/// Creates a new attachable effect.
		/// </summary>
		/// <param name="packetString"></param>
		/// <param name="scale"></param>
		public AttachableEffect(string packetString, float scale)
		{
			this.PacketString = packetString;
			this.Scale = scale;
		}
	}
}
