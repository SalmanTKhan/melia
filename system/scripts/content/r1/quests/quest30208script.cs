//--- Melia Script -----------------------------------------------------------
// Barha Forest's Antidote(4)
//--- Description -----------------------------------------------------------
// Quest to Cure Researcher Adas.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(30208)]
public class Quest30208Script : QuestScript
{
	protected override void Load()
	{
		SetId(30208);
		SetName("Barha Forest's Antidote(4)");
		SetDescription("Cure Researcher Adas");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_3"));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("ORCHARD_34_3_SQ_NPC_2")?.PlayEffectLocal(character.Connection, "F_smoke115_green", 2.0f, "BOT");
		await dialog.Msg("ORCHARD_34_3_SQ_4_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

