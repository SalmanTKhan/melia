//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
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

[QuestScript(30235)]
public class Quest30235Script : QuestScript
{
	protected override void Load()
	{
		SetId(30235);
		SetName("Inspect Inner Wall District 9 (5)");
		SetDescription("Talk to Kupole Liepa");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_4"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_2_SQ_5_select", "CASTLE_20_2_SQ_5", "I will pack up and go.", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("CASTLE_20_2_SQ_5_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

