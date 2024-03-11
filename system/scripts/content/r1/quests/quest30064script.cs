//--- Melia Script -----------------------------------------------------------
// Forest Corrupted by the Demons
//--- Description -----------------------------------------------------------
// Quest to Speak with Mardas.
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

[QuestScript(30064)]
public class Quest30064Script : QuestScript
{
	protected override void Load()
	{
		SetId(30064);
		SetName("Forest Corrupted by the Demons");
		SetDescription("Speak with Mardas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_04"));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_12_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_12_MQ_05_select", "KATYN_12_MQ_05", "Where is this evil energy?", "That sounds dangerous; I'd rather not."))
		{
			case 1:
				await dialog.Msg("KATYN_12_MQ_05_agree");
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

