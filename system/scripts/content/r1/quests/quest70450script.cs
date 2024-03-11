//--- Melia Script -----------------------------------------------------------
// Corners Well Polished
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70450)]
public class Quest70450Script : QuestScript
{
	protected override void Load()
	{
		SetId(70450);
		SetName("Corners Well Polished");
		SetDescription("Talk to Mage Melchioras");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_SQ01"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_09", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_09", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_SQ_02_start", "CASTLE65_3_SQ02", "Leave it to me", "Tell her that there is a more emergent issue"))
		{
			case 1:
				await dialog.Msg("CASTLE653_SQ_02_agree");
				dialog.UnHideNPC("CASTLE652_MQ_02_PILLAR");
				dialog.UnHideNPC("CASTLE652_MQ_04_PILLAR");
				dialog.UnHideNPC("CASTLE652_MQ_PILLAR_EX");
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

