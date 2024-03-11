//--- Melia Script -----------------------------------------------------------
// Sentinel's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Listen to the Sentinel's Chupacabra extermination plan..
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

[QuestScript(1033)]
public class Quest1033Script : QuestScript
{
	protected override void Load()
	{
		SetId(1033);
		SetName("Sentinel's Favor (1)");
		SetDescription("Listen to the Sentinel's Chupacabra extermination plan.");

		AddPrerequisite(new LevelPrerequisite(6));

		AddObjective("kill0", "Kill 7 Chupacabra(s)", new KillObjective(7, MonsterId.Chupacabra_Blue));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 78));

		AddDialogHook("SIAUL_EAST_SOLDIER9", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SOLDIER9", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_RECLAIM2_dlg1", "SIAUL_EAST_RECLAIM2", "I'll defeat the Chupacabra", "The role of Aras' Troops", "You should take care of it yourself"))
		{
			case 1:
				dialog.ShowHelp("TUTO_QUEST");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAUL_EAST_RECLAIM2_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAUL_EAST_RECLAIM2_dlg3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_EAST_RECLAIM3");
	}
}

