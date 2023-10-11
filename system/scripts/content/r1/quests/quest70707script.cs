//--- Melia Script -----------------------------------------------------------
// Proof of Innocence (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Soul of Hayatin.
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

[QuestScript(70707)]
public class Quest70707Script : QuestScript
{
	protected override void Load()
	{
		SetId(70707);
		SetName("Proof of Innocence (1)");
		SetDescription("Talk to the Soul of Hayatin");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ07"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_08_start", "BRACKEN42_1_SQ08", "How can I know the exact location?", "That complicates things. I'm out."))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_08_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("BRACKEN42_1_SQ09");
	}
}

