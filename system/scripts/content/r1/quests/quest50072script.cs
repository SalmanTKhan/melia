//--- Melia Script -----------------------------------------------------------
// The Past of the Spirits (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50072)]
public class Quest50072Script : QuestScript
{
	protected override void Load()
	{
		SetId(50072);
		SetName("The Past of the Spirits (1)");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new LevelPrerequisite(211));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_67_MQ060"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7385));

		AddDialogHook("EMINENT_68_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_68_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER68_MQ010_startnpc01", "UNDERFORTRESS_68_MQ010", "How do you make a symbol of restraint?", "We need to find another way"))
		{
			case 1:
				dialog.HideNPC("EMINENT_67_2");
				dialog.HideNPC("AMANDA_67_2");
				await dialog.Msg("UNDER68_MQ010_startnpc02");
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

		await dialog.Msg("UNDER68_MQ010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

