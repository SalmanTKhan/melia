//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60054)]
public class Quest60054Script : QuestScript
{
	protected override void Load()
	{
		SetId(60054);
		SetName("The Journey to Find Myself (3)");
		SetDescription("Talk to Demon Lord Hauberk");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_03"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_04_01", "PILGRIM312_SQ_04", "I will try", "Decline"))
		{
			case 1:
				await dialog.Msg("PILGRIM312_SQ_04_AG");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("PILGRIM312_HAUBERK_01");
				// Func/PILGRIM312_SQ_04_01_ADD;
				dialog.UnHideNPC("PILGRIM312_HAUBERK_02");
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

