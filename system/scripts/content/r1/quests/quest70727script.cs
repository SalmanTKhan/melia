//--- Melia Script -----------------------------------------------------------
// Effect Too Strong (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70727)]
public class Quest70727Script : QuestScript
{
	protected override void Load()
	{
		SetId(70727);
		SetName("Effect Too Strong (1)");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ07"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN422_SQ_08_start", "BRACKEN42_2_SQ08", "Alright", "Let's stop here before something goes wrong."))
		{
			case 1:
				await dialog.Msg("BRACKEN422_SQ_08_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("BRACKEN42_2_SQ09");
	}
}

