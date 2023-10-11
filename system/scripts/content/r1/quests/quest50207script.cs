//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (6)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50207)]
public class Quest50207Script : QuestScript
{
	protected override void Load()
	{
		SetId(50207);
		SetName("Danger the Lurks in the Forest (6)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ5"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14260));

		AddDialogHook("BRACKEN432_SUBQ_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ6_START1", "BRACKEN43_2_SQ6", "Where can I obtain vink flowers?", "Tell him to do it himself"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ6_AGREE1");
				await dialog.Msg("BalloonText/BRACKEN432_SUBQ6_DLG1/7");
				dialog.HideNPC("BRACKEN432_SUBQ_NPC1");
				await dialog.Msg("FadeOutIN/1000");
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

		if (character.Inventory.HasItem("BRACKEN432_SUBQ6_ITEM2", 5))
		{
			character.Inventory.RemoveItem("BRACKEN432_SUBQ6_ITEM2", 5);
			await dialog.Msg("BalloonText/BRACKEN432_SUBQ6_DLG2/7");
			dialog.UnHideNPC("BRACKEN432_SUBQ_NPC2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("BRACKEN43_2_SQ7");
	}
}

