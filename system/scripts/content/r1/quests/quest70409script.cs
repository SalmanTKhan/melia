//--- Melia Script -----------------------------------------------------------
// Reutilizing Resources
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Nuodas.
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

[QuestScript(70409)]
public class Quest70409Script : QuestScript
{
	protected override void Load()
	{
		SetId(70409);
		SetName("Reutilizing Resources");
		SetDescription("Talk to Follower Nuodas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 16 Useful Arrow(s)", new CollectItemObjective("CASTLE65_1_SQ04_ITEM", 16));
		AddDrop("CASTLE65_1_SQ04_ITEM", 7.5f, "charcoal_walker");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("CASTLE651_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE651_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_SQ_04_start", "CASTLE65_1_SQ04", "I'll do it while I hunt some monsters", "Give up everything that's already been used"))
		{
			case 1:
				await dialog.Msg("CASTLE651_SQ_04_agree");
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

