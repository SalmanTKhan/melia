using System;
using System.Collections.Generic;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Geometry.Shapes;
using Yggdrasil.Logging;

namespace Melia.Zone.World.Actors.Components
{
	public class ActorPositionUpdaterComponent : ActorComponent
	{
		private readonly Dictionary<IActor, float> _attachedActors = new Dictionary<IActor, float>();
		public ActorPositionUpdaterComponent(IActor actor) : base(actor)
		{
		}

		public void AttachActor(IActor attachedActor, float distance)
		{
			_attachedActors.Add(attachedActor, distance);
		}

		public void RemoveActor(IActor actor)
		{
			_attachedActors.Remove(actor);
		}

		public void UpdatePosition()
		{
			foreach (var actor in _attachedActors)
			{
				actor.Key.Position = this.Actor.Position.GetRelative(this.Actor.Direction, actor.Value);
				if (actor.Key is Npc npc && npc.UpdateArea)
				{
					if (npc.Area is CircleF circle)
					{
						npc.SetTriggerArea(new CircleF(actor.Key.Position, circle.Radius), true);
					}
				}
			}
		}
	}
}
