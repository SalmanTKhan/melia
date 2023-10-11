//--- Melia Script -----------------------------------------------------------
// A Stronger Antidote(3)
//--- Description -----------------------------------------------------------
// Quest to Craft an Enhanced Antidote with Researcher Sireah.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(30214)]
public class Quest30214Script : QuestScript
{
	protected override void Load()
	{
		SetId(30214);
		SetName("A Stronger Antidote(3)");
		SetDescription("Craft an Enhanced Antidote with Researcher Sireah");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_9"));
		AddPrerequisite(new ItemPrerequisite("ORCHARD_34_3_SQ_ITEM3", -100), new ItemPrerequisite("ORCHARD_34_3_SQ_ITEM7", -100));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_10_select", "ORCHARD_34_3_SQ_10", "Give the Antidote and ingredients", "Say that you think it will be fine to eat seperately"))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("ORCHARD_34_3_SQ_NPC_3")?.PlayEffectLocal(character.Connection, "F_spread_in002_green", 0.5f, "MID");
				await dialog.Msg("ORCHARD_34_3_SQ_10_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ORCHARD_34_3_SQ_10_succ");
		dialog.HideNPC("ORCHARD_34_3_SQ_OBJ_9");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

