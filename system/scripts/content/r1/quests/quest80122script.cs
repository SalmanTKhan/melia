//--- Melia Script -----------------------------------------------------------
// One Step Closer to the Goddess
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80122)]
public class Quest80122Script : QuestScript
{
	protected override void Load()
	{
		SetId(80122);
		SetName("One Step Closer to the Goddess");
		SetDescription("Talk to Kupole Trija");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_9"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_10_start", "LIMESTONE_52_1_MQ_10", "There's no other way.", "I'll find another way."))
		{
			case 1:
				dialog.HideNPC("LIMSTONE_52_1_CRYSTAL");
				await dialog.Msg("LIMESTONE_52_1_MQ_10_agree_1");
				await dialog.Msg("LIMESTONE_52_1_MQ_10_agree");
				await dialog.Msg("LIMESTONE_52_1_MQ_10_agree_2");
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

		await dialog.Msg("LIMESTONE_52_1_MQ_10_succ");
		dialog.UnHideNPC("LIMESTONECAVE_52_2_MEDENA");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

