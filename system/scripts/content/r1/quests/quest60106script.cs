//--- Melia Script -----------------------------------------------------------
// The Suspicious Location
//--- Description -----------------------------------------------------------
// Quest to Talk with Agent Orwen.
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

[QuestScript(60106)]
public class Quest60106Script : QuestScript
{
	protected override void Load()
	{
		SetId(60106);
		SetName("The Suspicious Location");
		SetDescription("Talk with Agent Orwen");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_ORWEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_ORWEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_SQ_02_01", "SIAU11RE_SQ_02", "I will get rid of it", "Tell her that there is a more emergent issue"))
		{
			case 1:
				dialog.UnHideNPC("SIAU11RE_SQ_02_NPC");
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

