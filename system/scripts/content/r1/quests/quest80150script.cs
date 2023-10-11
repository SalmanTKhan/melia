//--- Melia Script -----------------------------------------------------------
// Before It's Too Late (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80150)]
public class Quest80150Script : QuestScript
{
	protected override void Load()
	{
		SetId(80150);
		SetName("Before It's Too Late (2)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_1"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_2_start", "LIMESTONE_52_4_MQ_2", "Let's do it.", "That doesn't sound very useful."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
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

		dialog.HideNPC("LIMESTONE_52_4_PORTAL");
		await dialog.Msg("LIMESTONE_52_4_MQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

