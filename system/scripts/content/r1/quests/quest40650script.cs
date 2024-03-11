//--- Melia Script -----------------------------------------------------------
// Interpreting the Tombstone's Story
//--- Description -----------------------------------------------------------
// Quest to Meet the Wings of Vaivora in Klaipeda.
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

[QuestScript(40650)]
public class Quest40650Script : QuestScript
{
	protected override void Load()
	{
		SetId(40650);
		SetName("Interpreting the Tombstone's Story");
		SetDescription("Meet the Wings of Vaivora in Klaipeda");

		AddPrerequisite(new LevelPrerequisite(172));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_2_SQ_020"), new CompletedPrerequisite("REMAINS37_2_SQ_040"), new CompletedPrerequisite("REMAINS37_2_SQ_060"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("REMAINS37_2_SQ_070_ITEM_1", 1));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5160));

		AddDialogHook("JOURNEY_SHOP", "BeforeStart", BeforeStart);
		AddDialogHook("JOURNEY_SHOP", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("REMAINS37_2_SQ_070_COMP");
		await dialog.Msg("PCAin/TALK/1");
		await Task.Delay(1500);
		await dialog.Msg("REMAINS37_2_SQ_070_COMP_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You are unsure of what was written on the tombstone.{nl}Go to the Wings of Vaivora in Klaipeda and ask.");
	}
}

