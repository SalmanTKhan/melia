//--- Melia Script -----------------------------------------------------------
// Unidentified Package (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Daramaus.
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

[QuestScript(60124)]
public class Quest60124Script : QuestScript
{
	protected override void Load()
	{
		SetId(60124);
		SetName("Unidentified Package (1)");
		SetDescription("Talk with Chaser Daramaus");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 7 Unidentified Package(s)", new CollectItemObjective("PRISON621_SQ_04_ITEM", 7));
		AddDrop("PRISON621_SQ_04_ITEM", 10f, 57991, 58002);

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_DARAMAUS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_SQ_03_01", "PRISON621_SQ_03", "I will collect them", "I won't do anything that's not necessary"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PRISON621_SQ_04");
	}
}

