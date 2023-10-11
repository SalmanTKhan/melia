//--- Melia Script -----------------------------------------------------------
// Finding the Model [Dievdirbys Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Klaipeda Item Merchant.
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

[QuestScript(1130)]
public class Quest1130Script : QuestScript
{
	protected override void Load()
	{
		SetId(1130);
		SetName("Finding the Model [Dievdirbys Advancement] (2)");
		SetDescription("Talk to Klaipeda Item Merchant");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARREL3_2_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("JOB_DIEVDIRBYS3_1"));

		AddObjective("collect0", "Collect 1 Cloth Piece with Needlepoint", new CollectItemObjective("JOB_DIEVDIRBYS3_2_ITEM1", 1));
		AddDrop("JOB_DIEVDIRBYS3_2_ITEM1", 10f, "boss_Minotaurs_J1");

		AddDialogHook("EMILIA", "BeforeStart", BeforeStart);
		AddDialogHook("EMILIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DIEVDIRBYS3_2_select1", "JOB_DIEVDIRBYS3_2", "I'll check for traces of your father", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_DIEVDIRBYS3_2_agree1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("JOB_DIEVDIRBYS3_2_ITEM1", 1))
		{
			character.Inventory.RemoveItem("JOB_DIEVDIRBYS3_2_ITEM1", 1);
			await dialog.Msg("JOB_DIEVDIRBYS3_2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_DIEVDIRBYS3_3");
	}
}

