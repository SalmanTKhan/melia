//--- Melia Script -----------------------------------------------------------
// Carvings on the Pillar
//--- Description -----------------------------------------------------------
// Quest to Look at the pillar.
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

[QuestScript(40980)]
public class Quest40980Script : QuestScript
{
	protected override void Load()
	{
		SetId(40980);
		SetName("Carvings on the Pillar");
		SetDescription("Look at the pillar");

		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("ROKAS_36_1_PILLA04", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_36_1_PILLA04", "BeforeEnd", BeforeEnd);
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

		// Func/ROKAS_36_1_SQ_040_COMP_FUNC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Due to shining moss, you are able to read what the writings say!");
		ZoneServer.Instance.World.FindNPC("ROKAS_36_1_PILLA04")?.PlayEffectLocal(character.Connection, "F_ground139_light_orange", 1f, "BOT");
		await Task.Delay(2000);
		await dialog.Msg("ROKAS_36_1_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

