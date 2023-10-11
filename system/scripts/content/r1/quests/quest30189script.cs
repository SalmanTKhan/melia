//--- Melia Script -----------------------------------------------------------
// What Must Be Done (2)
//--- Description -----------------------------------------------------------
// Quest to Activate the Magical Device at the Tower of Discipline.
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

[QuestScript(30189)]
public class Quest30189Script : QuestScript
{
	protected override void Load()
	{
		SetId(30189);
		SetName("What Must Be Done (2)");
		SetDescription("Activate the Magical Device at the Tower of Discipline");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_5"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_OBJ_5", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_OBJ_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("NPCAin/PRISON_82_OBJ_5/STD/1");
		dialog.HideNPC("PRISON_82_OBJ_5_1");
		dialog.HideNPC("PRISON_82_OBJ_5_2");
		dialog.HideNPC("PRISON_82_OBJ_5_3");
		dialog.HideNPC("PRISON_82_OBJ_5_4");
		// Func/SCR_PRISON_82_MQ_6_SUCC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Illusions have been summoned in the Interrogation Room after the Magic Device was activated");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

