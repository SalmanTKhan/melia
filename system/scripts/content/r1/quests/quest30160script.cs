//--- Melia Script -----------------------------------------------------------
// Storage Lamp(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30160)]
public class Quest30160Script : QuestScript
{
	protected override void Load()
	{
		SetId(30160);
		SetName("Storage Lamp(4)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_6"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_OBJ_6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_79_MQ_7_select", "PRISON_79_MQ_7", "Say that you will light the last Lamp", "Say that it is too complicated"))
		{
			case 1:
				await dialog.Msg("PRISON_79_MQ_7_agree");
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

		dialog.UnHideNPC("PRISON_79_OBJ_6_EFFECT");
		// Func/SCR_PRISON_79_MQ_7_SUCC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have lit the Yellow Lamp{nl}Return to Zanas' Spirit");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

