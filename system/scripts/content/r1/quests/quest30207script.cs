//--- Melia Script -----------------------------------------------------------
// Barha Forest's Antidote(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Adas.
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

[QuestScript(30207)]
public class Quest30207Script : QuestScript
{
	protected override void Load()
	{
		SetId(30207);
		SetName("Barha Forest's Antidote(3)");
		SetDescription("Talk to Researcher Adas");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_2"));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("ORCHARD_34_3_SQ_ITEM3", 1));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_OBJ_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_3_select", "ORCHARD_34_3_SQ_3", "Say that you will craft the Antidote", "Ask if he isn't faking it"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_3_agree");
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


		return HookResult.Break;
	}
}

