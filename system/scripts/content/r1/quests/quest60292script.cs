//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60292)]
public class Quest60292Script : QuestScript
{
	protected override void Load()
	{
		SetId(60292);
		SetName("The Downward Spiral (3)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_2"));

		AddObjective("kill0", "Kill 6 Bishop Point(s)", new KillObjective(6, MonsterId.Bishop_Point));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 26000));

		AddDialogHook("DCAPITAL106_GRISIA_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL106_SQ_3_1", "DCAPITAL106_SQ_3", "Alright", "I need to prepare"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("DCAPITAL106_SQ_4");
	}
}

