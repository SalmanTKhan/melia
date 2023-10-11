//--- Melia Script -----------------------------------------------------------
// Mysterious Slate (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(20052)]
public class Quest20052Script : QuestScript
{
	protected override void Load()
	{
		SetId(20052);
		SetName("Mysterious Slate (3)");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(20));
		AddPrerequisite(new CompletedPrerequisite("CMINE6_TO_KATYN7_2"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 107));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CMINE6_TO_KATYN7_3_select1", "CMINE6_TO_KATYN7_3", "I'll go and meet the Paladin Master", "Cancel"))
		{
			case 1:
				await dialog.Msg("CMINE6_TO_KATYN7_3_Q");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Use the Ausrine Sculpture in the Central Square in Klaipeda to move to the Miner's Village");
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

		await dialog.Msg("CMINE6_TO_KATYN7_3_succ1");
		dialog.ShowHelp("TUTO_INCOMPATIBLE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SOUT_Q_41");
	}
}

