//--- Melia Script -----------------------------------------------------------
// True Nature of Sarma's Research (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Sarma.
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

[QuestScript(30140)]
public class Quest30140Script : QuestScript
{
	protected override void Load()
	{
		SetId(30140);
		SetName("True Nature of Sarma's Research (1)");
		SetDescription("Talk with Sarma");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_10"));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_2", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_11_select", "ORCHARD_34_1_SQ_11", "Why can't you do it yourself", "Since you've helped him a lot already, tell him to do it alone"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_11_agree");
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

		await dialog.Msg("ORCHARD_34_1_SQ_11_succ");
		dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_7_1_EFFECT");
		dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_7_2_EFFECT");
		dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_7_3_EFFECT");
		dialog.HideNPC("ORCHARD_34_1_SQ_2_OBJ_7_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

