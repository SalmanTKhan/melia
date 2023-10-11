//--- Melia Script -----------------------------------------------------------
// Nobreer Demonic Plague
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugrinas.
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

[QuestScript(30283)]
public class Quest30283Script : QuestScript
{
	protected override void Load()
	{
		SetId(30283);
		SetName("Nobreer Demonic Plague");
		SetDescription("Talk to Jugrinas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES_21_2_SQ_10_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(322));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_9"));

		AddObjective("collect0", "Collect 1 Demonic Plague Core", new CollectItemObjective("WTREES_21_2_SQ_10_ITEM", 1));
		AddDrop("WTREES_21_2_SQ_10_ITEM", 10f, "boss_Grimreaper_Q1");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES_21_2_SQ_10_select", "WTREES_21_2_SQ_10", "I'll go and check, don't worry.", "I say we keep our hands off the situation now."))
		{
			case 1:
				await dialog.Msg("WTREES_21_2_SQ_10_agree");
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

		if (character.Inventory.HasItem("WTREES_21_2_SQ_10_ITEM", 1))
		{
			character.Inventory.RemoveItem("WTREES_21_2_SQ_10_ITEM", 1);
			await dialog.Msg("WTREES_21_2_SQ_10_succ");
			dialog.HideNPC("WTREES_21_2_NPC_1");
			dialog.HideNPC("WTREES_21_2_NPC_2");
			dialog.HideNPC("WTREES_21_2_NPC_3");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

