//--- Melia Script -----------------------------------------------------------
// Reclaimed Power Generator
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

[QuestScript(92005)]
public class Quest92005Script : QuestScript
{
	protected override void Load()
	{
		SetId(92005);
		SetName("Reclaimed Power Generator");
		SetDescription("Talk to Mulia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP12_2_D_DCAPITAL_108_MQ06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ05"));

		AddObjective("kill0", "Kill 9 Raganosis Guardian(s) or Raganosis Ram(s) or Raganosis Seeker(s)", new KillObjective(9, 59527, 59530, 59528));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 41));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ06_DLG1", "EP12_2_D_DCAPITAL_108_MQ06", "Follow me, I'll lead the way.", "It would be better to take some rest here."))
		{
			case 1:
				// Func/SCR_DCAPITAL108_GUIDE3;
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ07");
	}
}

