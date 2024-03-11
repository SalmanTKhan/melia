//--- Melia Script -----------------------------------------------------------
// Destruction of the Workshop
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Spirit in the Supply Room.
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

[QuestScript(30181)]
public class Quest30181Script : QuestScript
{
	protected override void Load()
	{
		SetId(30181);
		SetName("Destruction of the Workshop");
		SetDescription("Talk to Zanas' Spirit in the Supply Room");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_7"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_81_OBJ_6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_8_select", "PRISON_81_MQ_8", "Say that there are instructions", "Ponder on how to proceed together"))
		{
			case 1:
				await dialog.Msg("PRISON_81_MQ_8_agree");
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

		ZoneServer.Instance.World.FindNPC("PRISON_81_OBJ_6")?.PlayEffectLocal(character.Connection, "F_light082_line_red", 1.8f, "MID");
		await dialog.Msg("NPCAin/PRISON_81_OBJ_6/STD/1");
		await dialog.Msg("CameraShockWaveLocal/2/99999/50/2/50/0");
		// Func/SCR_PRISON_81_MQ_8_SUCC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Demons in the workshop have suffered greatly{nl}Return to Zanas' Spirit");
		dialog.HideNPC("PRISON_81_OBJ_2");
		dialog.HideNPC("PRISON_81_OBJ_INFOR");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

