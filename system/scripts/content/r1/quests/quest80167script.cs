//--- Melia Script -----------------------------------------------------------
// Unexpected Weapon
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

[QuestScript(80167)]
public class Quest80167Script : QuestScript
{
	protected override void Load()
	{
		SetId(80167);
		SetName("Unexpected Weapon");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_5"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 13846));

		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_5_MQ_6_ANTIEVIL_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_6_start", "LIMESTONE_52_5_MQ_6", "Let's activate them.", "I don't know"))
		{
			case 1:
				// Func/LIMESTONE_52_5_REENTER_RUN;
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

		ZoneServer.Instance.World.FindNPC("LIMESTONE_52_5_MQ_6_ANTIEVIL_2")?.PlayEffectLocal(character.Connection, "F_explosion004_yellow2", 1f, "BOT");
		await dialog.Msg("CameraShockWaveLocal/2/99999/50/2/50/0");
		// Func/SCR_LIMESTONE_52_5_MQ_6_SUCC;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Activating the exorcising device dealt a great amount of damage to the demons!");
		await dialog.Msg("LIMESTONE_52_5_MQ_6_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

