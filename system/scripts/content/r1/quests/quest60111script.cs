//--- Melia Script -----------------------------------------------------------
// While You Were Gone
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Zegaus.
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

[QuestScript(60111)]
public class Quest60111Script : QuestScript
{
	protected override void Load()
	{
		SetId(60111);
		SetName("While You Were Gone");
		SetDescription("Talk with Chaser Zegaus");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_05"));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 2197));

		AddDialogHook("SIAULIAI11RE_JEGAUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_JEGAUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_SQ_08_01", "SIAU11RE_SQ_08", "I will go look for it", "I'm sorry, I have more urgent issues to tend to"))
		{
			case 1:
				dialog.UnHideNPC("SIAU11RE_SQ_08_NPC");
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


		return HookResult.Break;
	}
}

