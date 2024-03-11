//--- Melia Script -----------------------------------------------------------
// Deactivate Protection Device of Asmuo Residence
//--- Description -----------------------------------------------------------
// Quest to Talk to Mulia.
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

[QuestScript(92004)]
public class Quest92004Script : QuestScript
{
	protected override void Load()
	{
		SetId(92004);
		SetName("Deactivate Protection Device of Asmuo Residence");
		SetDescription("Talk to Mulia");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP12_2_D_DCAPITAL_108_MQ05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ05_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ05_DLG1", "EP12_2_D_DCAPITAL_108_MQ05", "I seem to remember it.", "Nothing comes to my mind yet."))
		{
			case 1:
				// Func/SCR_DCAPITAL108_GUIDE2;
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

		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_02");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_03");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_04");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_05");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_06");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_07");
		dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ05_AFTER");
		// Func/EP12_2_D_DCAPITAL_108_MQ05_FAIL;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ06");
	}
}

